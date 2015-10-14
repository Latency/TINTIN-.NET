// *****************************************************************************
// File:      EventLogger.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TinTin {
  /// <summary>
  ///   This class can be used as the master event logging class for all
  ///   of an application and its libraries. The application should set the
  ///   system log file upon startup. All exceptions should be sent to the log
  ///   using the Log(Exception) method.
  /// </summary>
  public sealed class EventLogger {
    public delegate void EventHandler(EventLogEntryType logType, object origin, string stackTrace, string logMessage);

    public static bool Enabled;
    public static bool ShowAll = false;
    private static bool _gOnExceptionShowMessage;
    private static EventLog _log;
    public static event EventHandler OnEvent;

    /// <summary>
    ///   Set the application wide event logging to a Windows event log file.
    /// </summary>
    /// <param name="sourceName">Generaly the Name of the application</param>
    /// <param name="logName">The Name of the system log file</param>
    public static void SetLog(string sourceName, string logName) {
      try {
        if (!EventLog.SourceExists(sourceName))
          EventLog.CreateEventSource(sourceName, logName);
        _log = new EventLog(logName) {
          Source = sourceName
        };
      } catch (Exception) {
        StopLog();
      }
    }

    /// <summary>
    ///   Set the action to take when an exception is logged into the event
    ///   logger. This action will be taken in addition to logging the exception
    ///   in the system logs.
    /// </summary>
    /// <param name="showMessageBox">Show a message box with the event</param>
    public static void SetOnExceptionAction(bool showMessageBox) {
      _gOnExceptionShowMessage = showMessageBox;
    }

    /// <summary>
    ///   Stop application wide logging
    /// </summary>
    public static void StopLog() {
      try {
        Enabled = false;
        _log?.Close();
        _log = null;
      } catch {}
    }

    /// <summary>
    ///   Log an information string into the system log.
    /// </summary>
    /// <param name="information">Information string to be logged</param>
    public static void Log(string information) {
      Log(new object(), EventLogEntryType.Information, information);
    }

    public static void Log(object sender, EventLogEntryType logType, string information) {
      if (sender == null)
        sender = new object();
      if (!Enabled)
        return;
      if (!ShowAll && logType != EventLogEntryType.Error && logType != EventLogEntryType.SuccessAudit)
        return;
      var origin = sender.GetType().FullName;
      var trace = new StringBuilder();

      if (logType == EventLogEntryType.Error) {
        var t = new StackTrace();
        for (var i = 0; i < t.FrameCount; ++i) {
          var declaringType = t.GetFrame(i).GetMethod().DeclaringType;
          if (declaringType != null)
            trace.Append(declaringType.FullName + "." + t.GetFrame(i).GetMethod().Name + "\r\n");
        }
      }
      if (_log != null) {
        try {
          _log.WriteEntry(origin + ": " + information + "\r\n\r\nTRACE:\r\n" + trace, logType);
        } catch {}
      }
      OnEvent?.Invoke(logType, sender, trace.ToString(), information);
    }

    public static void Log(Exception exception) {
      Log(exception, "");
    }

    /// <summary>
    ///   Log an exception into the system log.
    /// </summary>
    /// <param name="exception">Exception to be logged</param>
    /// <param name="additional"></param>
    public static void Log(Exception exception, string additional) {
      try {
        var name = exception.GetType().FullName;
        var message = exception.Message;
        var t = exception;
        var i = 0;
        while (t.InnerException != null) {
          t = t.InnerException;
          name += " : " + t.GetType().FullName;
          // message = t.Message;
          // NKIDD - ADDED
          message += "\r\n\r\nInnerException #" + i + ":\r\nMessage: " + t.Message + "\r\nSource: " + t.Source + "\r\nStackTrace: " + t.StackTrace;
          i++;
        }

        name += "\r\n\r\n Additional Info: " + additional + "\r\n" + message;

        if (Enabled) {
          if (_log != null) {
            try {
              _log.WriteEntry(exception.Source + " threw exception: " + exception, EventLogEntryType.Error);
            } catch {}
          }
          OnEvent?.Invoke(EventLogEntryType.Error, exception.Source, exception.StackTrace, name);
        }

        if (!_gOnExceptionShowMessage)
          return;
        var ef = new ExceptionForm(exception);
        if (ef.ShowDialog() == DialogResult.OK)
          Debugger.Break();
        ef.Dispose();
      } catch {}
    }
  }
}