//  *****************************************************************************
//  File:       Program.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Threading;
using System.Windows.Forms;
using TinTin.Commands;
using TinTin.Structs;

namespace TinTin {
  internal static partial class Program {
    private static ShellData _sdData;

    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    /// <remarks>Creates a console/application hybrid binary.</remarks>
    /// <param name="args">Application input arguments and/or switch commands - (unused)</param>
    [STAThread]
    public static void Main(string[] args) {
      #region Exception Sink Handlers

      // ---------------------------------------------------------------------

      // Add the event handler for handling UI thread exceptions to the event.
      Application.ThreadException += ThreadException;
      Application.ApplicationExit += (sender, eventArgs) => Terminal.Free();
      OnError += LogException;

      // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += UnhandledException;

      // Setup hybrid compatability for Console mode.
      Terminal.Allocate();

      // ---------------------------------------------------------------------

      #endregion Exception Sink Handlers

      var p = new ShellSwitchParser(ref _sdData);
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
        var line = ReadLine.Read();
        var kvp = cmds.ProcessCommand(line?.Trim());
        kvp.Key?.DynamicInvoke(kvp.Value);
      }
    }

    internal static void CancelEventHandler(object sender, ConsoleCancelEventArgs args) {
      Print("\nThe read operation has been interrupted.");
      Thread.Sleep(1000);
    }
  }
}