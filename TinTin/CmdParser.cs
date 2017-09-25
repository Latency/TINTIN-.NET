//  *****************************************************************************
//  File:       CmdParser.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/22/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NDesk.Options;
using TinTin.Properties;

namespace TinTin {
  public static partial class Program {
    /// <summary>
    ///   Piped argument for file loading.
    /// </summary>
    /// <param name="arg"></param>
    private static void FileLoader(string arg) {
      foreach (var fileName in arg.Split(';')) {
        if (!File.Exists(fileName))
          Abort($"File `{fileName}' could not be found or does not exist.");

        Shell.Files.Add(fileName);
      }
    }


    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static bool Parse(string[] args) {
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
          "f|files=", $"Specifies input file(s) for loading.{Environment.NewLine}\tUse ';' for a delimiter", FileLoader
        }, {
      //  "g|graphic", "Graphic mode.", v => Shell.GUI = v != null
      //}, {
          "p|path=", "A target directory path of a folder containing the script files to be processed.  Multiple paths are supported & overrides $file switch.", v => Shell.Paths.Add(v)
        }, {
          "t|character=", $"Changes the default prompt character.\t[Default='{Resources.TINTIN_CHAR}']", v => {
            TinTin.tintin_char = v?[0] ?? Resources.TINTIN_CHAR[0];
          }
        }, {
          "v|verbose", "Verbose mode.", v => Shell.Verbosity = v != null
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
        Print(string.Format("{3}Invalid switch{0}:  `{1}' in \"{2}\"{3}", buf.Split(' ').Length == 1 ? string.Empty : "es", buf, string.Join(" ", args), Environment.NewLine));
        Print(@"Press any key to continue...");
        Console.ReadKey();
        return false;
      }

      // ---------------------------------------------------------------------

      #endregion Options

      var x = 0;
      foreach (var path in Shell.Paths.Where(path => Shell.Verbosity))
        Print($"Path {++x}:  {path}");

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
        Print(message);
    }
  }
}