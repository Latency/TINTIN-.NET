// ****************************************************************************
// * Project:  TinTin
// * File:     CmdParser.cs
// * Author:   Latency McLaughlin
// * Date:     05/22/2014
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AssemblyInfo;
using CSTypes;
using NDesk.Options;
using TinTin.Properties;

namespace TinTin {
  public class CmdParser {
    /// <summary>
    ///  Constructor
    /// </summary>
    public CmdParser() {
      Paths = new List<string>();
      Character = Settings.Default.PromptChar;
    }

    #region Properties

    public string File { get; private set; }
    public List<string> Paths { get; }
    public bool GUI { get; private set; }
    public char Character { get; private set; }
    public bool Verbosity { get; private set; }

    #endregion Properties


    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool Parse(string[] args) {
      var showHelp = false;

      var p = new OptionSet {
        {"c|character=", "Changes the default prompt character.  [Default='" + Character + "']", v => Character = v?[0] ?? Character},
        {"f|file=", "Script file to be processed.  [Default=\"" + File + "\"]", v => File = v},
        {"g|graphic", "Graphic mode.", v => GUI = v != null},
        {"p|path=", "A target directory path of a folder containing the script files to be processed.  Multiple paths are supported & overrides $file switch.", v => Paths.Add(v)},
        {"v|verbose", "Verbose mode.", v => Verbosity = v != null},
        {"?|h|help", "Usage on how to use this program.", v => showHelp = v != null}
      };

      var asm = Assembly.GetExecutingAssembly();
      List<string> extra;
      try {
        extra = p.Parse(args);
      } catch (OptionException e) {
        var tryHelp = @"Try `" + Path.GetFileName(asm.Location) + @" --help' for more information.";
        if (GUI) {
          MessageBox.Show(e.Message + Environment.NewLine + Environment.NewLine + tryHelp, asm.Location, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        } else {
          Console.WriteLine(Environment.NewLine + asm.GetName().Name + @":  " + e.Message);
          Console.WriteLine(tryHelp);
        }
        return false;
      }

      if (showHelp) {
        ShowHelp(p);
        return false;
      }

      if (extra.Count > 0) {
        Display(string.Format("{0}Unknown arguments detected:{0}`{1}'", Environment.NewLine, string.Join(" ", extra.ToArray())));
        return false;
      }

      // Save user settings.
      if (Character != Settings.Default.PromptChar) {
        Settings.Default.PromptChar = Character;
        Settings.Default.Save();
      }

      var x = 0;
      foreach (var path in Paths.Where(path => Verbosity))
        System.Diagnostics.Debug.WriteLine("{0}Using server {1}:  {2}", Character, ++x, path);

      return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    private void Display(string message) {
      if (!string.IsNullOrEmpty(message)) {
        if (GUI)
          // May need to change this to a scrollable textbox pane.
          MessageBox.Show(message, Assembly.GetExecutingAssembly().ProductTitle(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        else
          Console.WriteLine(message);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static string Usage() {
      return $"Usage:  {Path.GetFileName(Assembly.GetExecutingAssembly().Location)} [OPTIONS]";
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    private void ShowHelp(OptionSet p) {
      string message;

      using (TextWriter output = new StringWriter()) {
        p.WriteOptionDescriptions(output);
        message = Usage() + Environment.NewLine + "Options:" + output;
      }

      Display(message);
    }


    /* enum ConsoleColor {
     *   Black
     *   DarkBlue
     *   DarkGreen
     *   DarkCyan
     *   DarkRed
     *   DarkMagenta
     *   DarkYellow
     *   Gray
     *   DarkGray
     *   Blue
     *   Green
     *   Cyan
     *   Red
     *   Magenta
     *   Yellow
     *   White
     * }
     */
    public static int ParseColor(string str, out string temp) {
      // Main buffer.
      temp = string.Empty;
      // Used for &+ &-
      bool verbatim = false,
           isColor = false;
      // Common variable
      var x = 0;

      while (str[x] != '\0') {
        if (str[x] == '\\') {       // Toggle verbatim mode
          verbatim = !verbatim;
          if (str[++x] == '\\') {
            verbatim = !verbatim;
            temp += str[x];
          } else
            x--;
        } else if (!verbatim && str[x] == '&') {
          switch (str[++x]) {
            case '+':
            case '-':
            case '=':
              ushort bit;
              switch (str[x]) {
                case '+':
                  bit = 2;
                  break;
                case '-':
                  bit = 1;
                  break;
                default:
                  bit = 0;
                  break;
              }
              var idx = str.IndexOfAny("01234567".ToCharArray(), ++x, 1);
              if (idx != -1) {
                temp += "\\e[";
                temp += (bit == 2 ? "3" : (bit == 1 ? "4" : string.Empty));
                temp += str[idx];
                temp += 'm';
                isColor = true;
              } else {
                x -= 2;
                temp += str[x];
              }
              break;

            case '~':
              var nibble = str.Substring(++x, 3);
              ushort y;
              if (!Types.IsNumber(nibble) || (y = Convert.ToUInt16(nibble)) > char.MaxValue) {
                x -= 2;
                temp += str[x];
              } else {
                temp += Convert.ToChar(y);
                x += 2;
              }
              break;

            default:
              temp += str[--x];
              break;
          }
        } else if (isColor && str[x].ToString().Equals(Environment.NewLine)) {
          verbatim = false;
          isColor = false;
          temp += "[0m" + Environment.NewLine;
        } else
          temp += str[x];
        x++;
      }
      return temp.Length;
    }
  }
}