// ****************************************************************************
// * Project:  TinTin
// * File:     Program.cs
// * Author:   Latency McLaughlin
// * Date:     05/22/2014
// ****************************************************************************

using System;
using System.Threading;
using System.Windows.Forms;

namespace TinTin {
  internal static class Program {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    private static void Main(string[] args) {
      Application.ThreadException += ExceptionSink;
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
      AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventSink;

      var p = new CmdParser();
      if (!p.Parse(args)) {
#if DEBUG
        if (!p.GUI) {
          Console.Write(@"Press any key to continue...  ");
          Console.ReadKey(false);
        }
#endif
      }
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public static void ExceptionSink(object sender, ThreadExceptionEventArgs args) {
      InstanceTracker.GenerateExceptionFile("Exceptions.txt", args.Exception.ToString(), InstanceTracker.VersionString);
    }


    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public static void UnhandledExceptionEventSink(object sender, UnhandledExceptionEventArgs args) {
      InstanceTracker.GenerateExceptionFile("Exceptions.txt", args.ExceptionObject.ToString(), InstanceTracker.VersionString);
    }
  }
}