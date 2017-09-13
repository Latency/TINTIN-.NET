//  *****************************************************************************
//  File:       ShellSwitchParser.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NDesk.Options;
using TinTin.Properties;
using TinTin.Structs;

namespace TinTin {
  public class ShellSwitchParser {
    private ShellData _sdData;

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="sd"></param>
    public ShellSwitchParser(ref ShellData sd) {
      _sdData = sd;
      _sdData.Paths = new List<string>();
    }

    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool Parse(string[] args) {
      Action<string> writeLine = format => {
        //====================================================================
        var sb = new StringBuilder();
        if (format.Length > 0)
          // ReSharper disable once LocalizableElement
          sb.AppendLine("\r" + format.PadRight(Settings.Default.SCREEN_WIDTH, ' '));
        else
          // ReSharper disable once LocalizableElement
          sb.Append("\r" + format.PadRight(Settings.Default.SCREEN_WIDTH, ' '));
        //====================================================================
        sb.Append("Press any key to continue...");
        Program.Print(sb.ToString());
      };

      // Piped argument for file loading.
      Func<string, List<string>> fileLoader = delegate(string arg) {
        var files = arg.Split(';');
        if (files.Length > 0)
          _sdData.Files = new List<string>();
        foreach (var fileName in files) {
          if (!File.Exists(fileName)) {
            writeLine($"{AppDomain.CurrentDomain.FriendlyName}:  File name `{fileName}' could not be found or does not exist.");
            Environment.Exit(1);
          }
          _sdData.Files.Add(fileName);
        }
        return _sdData.Files;
      };

      //
      // Format the command line arguments to support piping.
      //
      // Delim each filename argument with ';' and prepend the '-f' switch to pass into the delegate.
      if (args.Length > 0) {
        var newArgs = new List<string>();
        var fileList = new List<string>();
        string last = null;
        foreach (var arg in args) {
          if (File.Exists(arg) && !(!string.IsNullOrEmpty(last) && last == "-f"))
            fileList.Add(arg);
          else
            newArgs.Add(arg);
          last = arg;
        }
        if (fileList.Count > 0) {
          newArgs.Add("-f");
          newArgs.Add(string.Join(";", fileList.ToArray()));
        }
        args = newArgs.ToArray();
      }

      #region Options

      // ---------------------------------------------------------------------
      var showHelp = false;
      var p = new OptionSet {
        {
          "f|files=", "Specifies input file(s) for loading.\r\n\tUse ';' for a delimiter", f => fileLoader(f)
        }, {
          "g|graphic", "Graphic mode.", v => _sdData.GUI = v != null
        }, {
          "p|path=", "A target directory path of a folder containing the script files to be processed.  Multiple paths are supported & overrides $file switch.", v => _sdData.Paths.Add(v)
        }, {
          "t|character=", "Changes the default prompt character.  [Default='" + Settings.Default.PromptChar + "']", v => {
            Settings.Default.PromptChar = v?[0] ?? Settings.Default.PromptChar;
            Settings.Default.Save();
          }
        }, {
          "v|verbose", "Verbose mode.", v => _sdData.Verbosity = v != null
        }, {
          "?|h|help", "Usage on how to use this program.", h => showHelp = h != null
        }
      };

      var asm = Assembly.GetExecutingAssembly();
      List<string> extra;

      try {
        extra = p.Parse(args);
      } catch (OptionException e) {
        var tryHelp = @"Try `" + Path.GetFileName(asm.Location) + @" --help' for more information.";
        Program.Print($"{AppDomain.CurrentDomain.FriendlyName}:  {e.Message}{Environment.NewLine}{tryHelp}");
        return false;
      }

      if (showHelp) {
        ShowHelp(p);
        return false;
      }

      if (extra != null && extra.Count > 0) {
        var buf = string.Empty;
        buf = extra.Aggregate(buf, (current, e) => current + (e + ' ')).Trim();
        ShowHelp(p);
        writeLine(string.Format("{3}Invalid switch{0}:  `{1}' in \"{2}\"{3}", buf.Split(' ').Count() == 1 ? string.Empty : "es", buf, string.Join(" ", args), Environment.NewLine));
        return false;
      }

      // ---------------------------------------------------------------------

      #endregion Options

      var x = 0;
      foreach (var path in _sdData.Paths.Where(path => _sdData.Verbosity))
        Program.Print($"Using path {++x}:  {path}");

      return true;
    }


    /// <summary>
    ///   ShowHelp
    /// </summary>
    /// <param name="p"></param>
    private static void ShowHelp(OptionSet p) {
      string message;
      using (TextWriter output = new StringWriter()) {
        p.WriteOptionDescriptions(output);
        message = $"\rUsage:  {Path.GetFileName(Assembly.GetExecutingAssembly().Location)}{Environment.NewLine}Options:  {output}";
      }

      if (string.IsNullOrEmpty(message))
        return;

      Program.Print(message);
    }
  }
}