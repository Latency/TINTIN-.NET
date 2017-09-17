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
using TinTin.Structs;

namespace TinTin {
  internal static partial class Program {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    /// <remarks>Creates a console/application hybrid binary.</remarks>
    /// <param name="args">Application input arguments and/or switch commands - (unused)</param>
    [STAThread]
    public static void Main(string[] args) {
      #region Exception Sink Handlers

      // ---------------------------------------------------------------------

      OnError += LogException;

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += UnhandledException;

      // ---------------------------------------------------------------------

      #endregion Exception Sink Handlers

      var sData = new ShellData();
      var p = new CmdParser(ref sData);
      if (!p.Parse(args))
        return;

      // Load configuration file data.
      // TODO
      // Display status
      // TODO


      var cmds = new Switchboard();

      // Establish an event handler to process key press events.

      Console.CancelKeyPress += CancelEventHandler;
      while (true) {
        // Start a console read operation.
        var line = ReadLine.Read()?.Trim();
        var kvp = cmds.ProcessCommand(line);
        kvp.Value?.DynamicInvoke(kvp.Key);
      }
    }


    internal static void CancelEventHandler(object sender, ConsoleCancelEventArgs args){
      Print($"The application was interrupted.  (Ctrl+{(args.SpecialKey == ConsoleSpecialKey.ControlC ? "C" : "Break")})");
      Environment.Exit(0);
    }
  }
}