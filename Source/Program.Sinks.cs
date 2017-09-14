//  *****************************************************************************
//  File:       Program.Sinks.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Diagnostics;
using System.Reflection;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;

namespace TinTin {
  internal static partial class Program {
    //private static readonly ExceptionMessageBox ExceptionMessageBox = new ExceptionMessageBox(new Exception());
    private static event EventHandler OnError;


    /// <summary>
    ///   LogException
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void LogException(object sender, EventArgs e) {
      var methodBase = MethodBase.GetCurrentMethod();
      var strBase = string.Empty;
      if (methodBase.DeclaringType != null)
        strBase += methodBase.DeclaringType.FullName + '.';
      strBase += methodBase.Name;
      // Hooks into ReflectInsight listner for LiveView / Database / STDOUT / etc. error logging.   See 'app.config'
      RILogManager.Default.SendException(strBase, sender as Exception);
    }


    /// <summary>
    ///   ExceptionSinkTrigger
    /// </summary>
    /// <param name="innerException"></param>
    /// <returns></returns>
    private static void ExceptionSinkTrigger(Exception innerException) {
      // Fix the exception to include the stack trace from the current frame.
      Exception exception;
      try {
        throw new ReflectInsightException(MethodBase.GetCurrentMethod().Name, innerException);
      } catch (Exception ex) {
        ex.Source = new StackFrame(2).GetMethod().Name;
        exception = ex;
      }
      // Remote logging and system messaging trigger.
      OnError?.Invoke(exception, new EventArgs());
    }


    /// <summary>
    ///   Handle the UI exceptions by showing a dialog box, and asking the user whether or not they wish to abort execution.
    /// </summary>
    /// <summary>
    ///   UnhandledException
    /// </summary>
    /// <remarks>Exception sink if all else fails and was never trapped.</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      var method = MethodBase.GetCurrentMethod().Name;
      ExceptionSinkTrigger(new ReflectInsightException(method));
      //MessageBox.Show(@"Unhandled exception thrown in application event handler sink.", @"Fatal " + method + @" Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      Print("Unhandled exception thrown in application event handler sink.");
      Environment.Exit(1);
    }
  }
}