//  *****************************************************************************
//  File:       Program.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using TinTin.Commands;
using TinTin.Entities;

namespace TinTin {
  public static partial class Program {
    public static TinTinData TinTin;
    internal static TerminalData Terminal;
    internal static ShellData Shell;

    
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    /// <remarks>Creates a console/application hybrid binary.</remarks>
    /// <param name="args">Application input arguments and/or switch commands - (unused)</param>
    [STAThread]
    public static void Main(string[] args) {
      if (!Parse(args))
        return;
      
      // Display status
      // TODO

      // Load help.
      var help = Help.Instance;

      // Load commands.
      var cmds = Switchboard.Instance;

      // Establish an event handler to process key press events.

      Console.CancelKeyPress += CancelEventHandler;
      while (true) {
        // Start a console read operation.
        var line = ReadLine.ReadLine.Read()?.Trim();
        var kvp = cmds.ProcessCommand(line);
        kvp.Value?.DynamicInvoke(kvp.Key);
      }
    }


    internal static void Exit(int retval) {
      Environment.Exit(retval);
    }


    internal static void CancelEventHandler(object sender, ConsoleCancelEventArgs args){
      Print($"The application was interrupted.  (Ctrl+{(args.SpecialKey == ConsoleSpecialKey.ControlC ? "C" : "Break")})");
      Environment.Exit(0);
    }
  }
}