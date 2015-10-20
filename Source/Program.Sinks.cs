// *****************************************************************************
// File:      Program.Sinks.cs
// Solution:  TinTin.NET
// Date:      10/19/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;

namespace TinTin {
  internal static partial class Program {
    private static readonly ExceptionMessageBox ExceptionMessageBox = new ExceptionMessageBox(new Exception());
    private static event EventHandler OnError;

    /// <summary>
    ///   LogException
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void LogException(object sender, EventArgs e) {
      var methodBase = MethodBase.GetCurrentMethod();
      if (methodBase == null)
        return;
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
    private static Exception ExceptionSinkTrigger(Exception innerException) {
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
      return exception;
    }

    /// <summary>
    ///   Handle the UI exceptions by showing a dialog box, and asking the user whether or not they wish to abort execution.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="t"></param>
    private static void ThreadException(object sender, ThreadExceptionEventArgs t) {
      try {
        var exception = ExceptionSinkTrigger(t.Exception);

        // Unwind the call stack and attribute the 'data' tags for the ExceptionMessageBox.
        for (var e = exception; e != null; e = e.InnerException) {
          if (e.Data.Count <= 0)
            continue;
          var collection = e.Data.Cast<DictionaryEntry>().ToDictionary<DictionaryEntry, object, object>(kvp => "AdvancedInformation." + kvp.Key, kvp => kvp.Value ?? string.Empty);
          e.Data.Clear();
          foreach (var item in collection)
            e.Data.Add(item.Key, item.Value);
        }

        switch (ExceptionMessageBox.Show(exception)) {
          case DialogResult.Abort:
            Application.Exit();
            break;

          case DialogResult.Cancel:
            break;

          case DialogResult.Retry:
            var currentProcess = Process.GetCurrentProcess();
            RILogManager.Default.SendInformation($"Restarting application `{currentProcess.ProcessName}' after exception `{exception.GetType().Name}' on pid #{currentProcess.Id}");
            Application.Restart();
            break;
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.GetType().Name + @" thrown in application event handler sink.", @"Fatal " + MethodBase.GetCurrentMethod().Name + @" Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Application.Exit();
      }
    }

    /// <summary>
    ///   UnhandledException
    /// </summary>
    /// <remarks>Exception sink if all else fails and was never trapped.</remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e) {
      var method = MethodBase.GetCurrentMethod().Name;
      ExceptionSinkTrigger(new ReflectInsightException(method));
      MessageBox.Show(@"Unhandled exception thrown in application event handler sink.", @"Fatal " + method + @" Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      Application.Exit();
    }
  }
}