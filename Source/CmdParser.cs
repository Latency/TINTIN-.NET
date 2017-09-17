//  *****************************************************************************
//  File:       CmdParser.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NDesk.Options;
using TinTin.Properties;
using TinTin.Structs;

namespace TinTin {
  public class CmdParser {
    private readonly ShellData _sdData;

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="sd"></param>
    public CmdParser(ref ShellData sd) {
      _sdData = sd;
      _sdData.Paths = new List<string>();
    }


    /// <summary>
    ///  WriteLine
    /// </summary>
    /// <param name="format"></param>
    private static void WriteLine(string format) {
      //====================================================================
      if (format.Length > 0)
        // ReSharper disable once LocalizableElement
        Program.Print("\r" + format.PadRight(Settings.Default.SCREEN_WIDTH, ' '));
      else
        // ReSharper disable once LocalizableElement
        Program.Print("\r" + format.PadRight(Settings.Default.SCREEN_WIDTH, ' '));
      //====================================================================
      Program.Print(@"Press any key to continue...");
    }


    /// <summary>
    ///   Piped argument for file loading.
    /// </summary>
    /// <param name="arg"></param>
    private void FileLoader(string arg) {
      var files = arg.Split(';');
      if (files.Length > 0)
        _sdData.Files = new List<string>();
      foreach (var fileName in files)
      {
        if (!File.Exists(fileName))
        {
          WriteLine($"{AppDomain.CurrentDomain.FriendlyName}:  File name `{fileName}' could not be found or does not exist.");
          Environment.Exit(1);
        }
        _sdData.Files.Add(fileName);
      }
    }


    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public bool Parse(string[] args) {
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
          "f|files=", "Specifies input file(s) for loading.\r\n\tUse ';' for a delimiter", FileLoader
        }, {
        //  "g|graphic", "Graphic mode.", v => _sdData.GUI = v != null
        //}, {
          "p|path=", "A target directory path of a folder containing the script files to be processed.  Multiple paths are supported & overrides $file switch.", v => _sdData.Paths.Add(v)
        }, {
          "t|character=", "Changes the default prompt character.  [Default='" + Settings.Default.TINTIN_CHAR + "']", v => {
            Settings.Default.TINTIN_CHAR = v?[0] ?? Settings.Default.TINTIN_CHAR;
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
        Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName}:  {e.Message}", Environment.NewLine, tryHelp);
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
        WriteLine(string.Format("{3}Invalid switch{0}:  `{1}' in \"{2}\"{3}", buf.Split(' ').Length == 1 ? string.Empty : "es", buf, string.Join(" ", args), Environment.NewLine));
        return false;
      }

      // ---------------------------------------------------------------------

      #endregion Options

      var x = 0;
      foreach (var path in _sdData.Paths.Where(path => _sdData.Verbosity))
        Debug.WriteLine($"{Settings.Default.TINTIN_CHAR}Using path {++x}:  {path}");

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
        message = $"\rUsage:  {Path.GetFileName(Assembly.GetExecutingAssembly().Location)}" + Environment.NewLine + "Options:" + output;
      }

      if (!string.IsNullOrEmpty(message))
          Program.Print(message);
    }
  }
}