//  *****************************************************************************
//  File:      Program.Sinks.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      07/04/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Inc. - 2012-2016
//  *****************************************************************************

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Microsoft.SqlServer.MessageBox;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;

namespace TinTin.GUI {
  internal static class Program {
    /// <summary>
    ///   The object that the class will write
    ///   diagnostic information to at runtime.
    /// </summary>
    private static readonly IReflectInsight Log = RILogManager.Default;

    /// <summary>
    ///   Event handler for Error
    /// </summary>
    public static event EventHandler OnError;


    /// <summary>
    ///   LogException
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal static void LogException(object sender, EventArgs e) {
      var methodBase = MethodBase.GetCurrentMethod();
      var strBase = string.Empty;
      if (methodBase.DeclaringType != null)
        strBase += methodBase.DeclaringType.FullName + '.';
      strBase += methodBase.Name;
      // Hooks into ReflectInsight listner for LiveView / Database / STDOUT / etc. error logging.   See 'app.config'
      Log.SendException(strBase, sender as Exception);
    }


    /// <summary>
    ///   ExceptionSinkTrigger
    /// </summary>
    /// <param name="innerException"></param>
    /// <returns></returns>
    private static Exception ExceptionSinkTrigger(Exception innerException) {
      // Fix the exception to include the stack trace from the current frame.
      Exception exception;
      try {
        //throw new ReflectInsightException($"{AppDomain.CurrentDomain.FriendlyName}::{MethodBase.GetCurrentMethod().Name}", innerException);
        throw new Exception($"{AppDomain.CurrentDomain.FriendlyName}::{MethodBase.GetCurrentMethod().Name}", innerException);
      } catch (Exception ex) {
        ex.Source = new StackFrame(2).GetMethod().Name;
        exception = ex;
      }
      // Remote logging and system messaging trigger.
      OnError?.Invoke(exception, new EventArgs());
      return exception;
    }


    /// <summary>
    ///   Handle the UI exceptions by showing a dialog box, and asking the user whether or not they wish to abort execution.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="t"></param>
    public static void ReportUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs t) {
      Log.SendFatal("Unhandled exception occurred in main UI thread.", t.Exception);

      var exception = ExceptionSinkTrigger(t.Exception);

      // Unwind the call stack and attribute the 'data' tags for the ExceptionMessageBox.
      for (var e = exception; e != null; e = t.Exception.InnerException) {
        if (e.Data.Count <= 0)
          continue;
        var collection = e.Data.Cast<DictionaryEntry>().ToDictionary<DictionaryEntry, object, object>(kvp => "AdvancedInformation." + kvp.Key, kvp => kvp.Value ?? string.Empty);
        e.Data.Clear();
        foreach (var item in collection)
          e.Data.Add(item.Key, item.Value);
      }

      var exceptionMessageBox = new ExceptionMessageBox(exception, ExceptionMessageBoxButtons.AbortRetryIgnore, ExceptionMessageBoxSymbol.Error);
      // ReSharper disable once SwitchStatementMissingSomeCases
      switch (exceptionMessageBox.Show(null)) {
        case System.Windows.Forms.DialogResult.Abort:
          Application.Current.Shutdown();
          break;

        case System.Windows.Forms.DialogResult.Cancel:
          break;

        case System.Windows.Forms.DialogResult.Retry:
          var currentProcess = Process.GetCurrentProcess();
          Log.SendInformation($"Restarting application `{currentProcess.ProcessName}' after exception `{exception.GetType().Name}' on pid #{currentProcess.Id}");
          Process.Start(Application.ResourceAssembly.Location);
          Application.Current.Shutdown();
          break;
      }
    }


    /// <summary>
    ///   UnhandledException
    /// </summary>
    /// <remarks>Exception sink if all else fails and was never trapped.</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      var ex = ExceptionSinkTrigger((Exception) e.ExceptionObject);
      var exceptionMessageBox = new ExceptionMessageBox(ex, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error);
      exceptionMessageBox.Show(null);
    }
  }
}