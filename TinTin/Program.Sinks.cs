﻿//  *****************************************************************************
//  File:       Program.Sinks.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/24/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Logging;
using TinTin.Entities;
using TinTin.Properties;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TinTin {
  public static partial class Program {
    /// <summary>
    ///   Static constructor
    /// </summary>
    static Program() {
      #region Exception Sink Handlers
      // ---------------------------------------------------------------------

      OnError += LogException;

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += UnhandledException;

      // ---------------------------------------------------------------------
      #endregion Exception Sink Handlers

      #region Fields
      // ---------------------------------------------------------------------
      TinTin = new TinTinData {
        tintin_char = Resources.TINTIN_CHAR[0]
      };

      Terminal = new TerminalData {
        cols = Console.WindowWidth,
        rows = Console.WindowHeight
      };

      Shell = new ShellData();
      // ---------------------------------------------------------------------
      #endregion Fields
      
      #region Logging
      // ---------------------------------------------------------------------

      var loggerFactory = new LoggerFactory();
      loggerFactory.AddConsole();
      Log = loggerFactory.CreateLogger(Assembly.GetExecutingAssembly().FullName);

      // ---------------------------------------------------------------------
      #endregion Logging
    }

    public static ILogger Log { get; }

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
      Log.LogError(sender as Exception, strBase);
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
        throw new Exception(MethodBase.GetCurrentMethod().Name, innerException);
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
      ExceptionSinkTrigger(new Exception(method));
      Print("Unhandled exception thrown in application event handler sink.");
      Environment.Exit(1);
    }
  }
}