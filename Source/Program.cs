// ****************************************************************************
// * Project:  TinTin
// * File:     Program.cs
// * Author:   Latency McLaughlin
// * Date:     05/22/2014
// ****************************************************************************

using System;
using System.Windows.Forms;
using TinTin.Commands;
using TinTin.Structs;

namespace TinTin {
  internal static partial class Program {
    private static ShellData _sdData = new ShellData();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// <remarks>Creates a console/application hybrid binary.</remarks>
    /// <param name="args">Application input arguments and/or switch commands - (unused)</param>
    /// <exception cref="InvalidOperationException">You cannot set the exception mode after the application has created its first window.</exception>
    /// <exception cref="Exception">A delegate callback throws an exception. </exception>
    /// <exception cref="ArgumentNullException"><paramref /> is null. </exception>
    /// <exception cref="FormatException"><paramref /> is invalid.-or- The index of a format item is not zero or one. </exception>
    /// <exception cref="AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref /> is less than zero. </exception>
    /// <exception cref="OverflowException">The number of elements in <paramref /> is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
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
        var line = Console.ReadLine();
        var kvp = cmds.ProcessCommand(line?.Trim());
        kvp.Key?.DynamicInvoke(kvp.Value);
      }
    }

    internal static void CancelEventHandler(object sender, ConsoleCancelEventArgs args) {
      Print("\nThe read operation has been interrupted.");
      System.Threading.Thread.Sleep(1000);
    }
  }
}