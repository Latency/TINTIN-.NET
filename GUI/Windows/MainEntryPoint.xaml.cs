//  *****************************************************************************
//  File:      ShellApplication.xaml.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      06/29/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;
using AssemblyLoader;

namespace TinTin.GUI.Windows
{
  /// <inheritdoc />
  /// <summary>
  ///   Interaction logic for ShellApplication.xaml
  /// </summary>
  public partial class ShellApplication {
    private static readonly IReflectInsight Log = RILogManager.Default;

    /// <summary>
    ///  SplashThread
    /// </summary>
    internal Thread SplashThread { get; set; }
    
    /// <summary>
    ///   The loading window
    /// </summary>
    internal LoadingWindow SplashScreen { get; private set; }

    /// <summary>
    ///  SplashScreenDispatcher
    /// </summary>
    internal Dispatcher SplashScreenDispatcher { get; set; }

    /// <summary>
    ///  Application entry point.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <summary>
    ///   Handles the start event of the application.
    /// </summary>
    private void Application_OnStartup(object sender, StartupEventArgs e) {
#region Exception Sink Handlers

      // ---------------------------------------------------------------------
      DispatcherUnhandledException += Program.ReportUnhandledException;

      // Add the event handler for handling UI thread exceptions to the event.
      AppDomain.CurrentDomain.AssemblyLoad += (o, args) => {
#if ASMLOADING
        Log.SendDebug(args.LoadedAssembly.FullName);
#endif
      };

      Program.OnError += Program.LogException;

      AppDomain.CurrentDomain.ProcessExit += (o, args) => {
        Log.SendInformation($"Application `{AppDomain.CurrentDomain.FriendlyName}' is exiting.");
      };

      AppDomain.CurrentDomain.FirstChanceException += (o, args) => {
        Log.SendError($"FirstChanceException event raised in {AppDomain.CurrentDomain.FriendlyName}", args.Exception);
      };

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += Program.UnhandledException;

      // ---------------------------------------------------------------------

#endregion Exception Sink Handlers

      if (Environment.OSVersion.Platform != PlatformID.Win32NT) {
        MessageBox.Show("This operating system is not supported!");
        Shutdown(1);
        return;
      }

#if FOO
      if (RunAsAdministrator(e))
        return;
#endif

      using (var mrEvent = new ManualResetEvent(false)) {
        SplashThread = new Thread(DisplaySplashScreen);
        SplashThread.SetApartmentState(ApartmentState.STA);
        SplashThread.IsBackground = true;
        SplashThread.Name = "Splash Screen";
        SplashThread.Start(mrEvent);
        mrEvent.WaitOne();
      }

      HideSplashScreen();

      DisplayMainWindow();

      Log.SendInformation("***** STARTING SESSION *****");
    }


    /// <summary>
    ///  Displays the splash screen window.
    /// </summary>
    /// <param name="mrEvent"></param>
    internal void DisplaySplashScreen(object mrEvent) {
      Log.SendInformation("Displaying the splash screen.");

      SplashScreenDispatcher = Dispatcher.CurrentDispatcher;
      
      var asm = Assembly.GetExecutingAssembly();
      SplashScreen = new LoadingWindow {
        Company = asm.Company(),
        Title = asm.ProductTitle(),
        IsIndeterminate = true,
        Interrupt = false
      };

      // Show the splash screen.
      SplashScreen.Show();

      (mrEvent as ManualResetEvent)?.Set();
      Dispatcher.Run();
      Log.SendInformation("Shutting down splash screen thread.");
    }


    /// <summary>
    ///  HideSplashScreen
    /// </summary>
    internal async void HideSplashScreen() {
      await Task.Factory.StartNew(splash => {
        if (!(splash is LoadingWindow splsh))
          return;

        while (!splsh.CanClose)
          Task.Delay(250).Wait();

        if (!splsh.Interrupt) {
          Log.SendInformation("Hiding the splash screen.");
          SplashScreenDispatcher.InvokeAsync(SplashScreen.Hide);
        }
      }, SplashScreen);
    }


#if FOO
    /// <summary>
    ///  RunAsAdministrator
    /// </summary>
    private bool RunAsAdministrator(StartupEventArgs e) {
      Log.SendInformation("Checking for run as administrator.");

      // The user is the administrator of time, direct start application.
      // If not the administrator, use the startup object start program, using run as administrator to ensure.
      WindowsIdentity identity;

      using (Log.TraceMethod(MethodBase.GetCurrentMethod().Name)) {
        try {
          identity = WindowsIdentity.GetCurrent();
        } catch (Exception ex) {
          Log.SendInformation($"Unable to elevate permissions to administrator!{Environment.NewLine}\t- {ex.Message}");
          Shutdown(1);
          return false;
        }
      }

      //Get the current logged on user labeled Windows
      var principal = new WindowsPrincipal(identity);
      //Judge whether the currently logged in as administrator.
      if (principal.IsInRole(WindowsBuiltInRole.Administrator))
        return false;

      using (Log.TraceMethod(MethodBase.GetCurrentMethod().Name)) {
        try {
          //Create a startup object
          var startInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().Location, string.Join(" ", e.Args)) {
            WorkingDirectory = Environment.CurrentDirectory,
            Verb = "runas"
          };

          // Set the start action, make sure to run as Administrator
          Process.Start(startInfo);
        } catch (Win32Exception ex) {
          if (ex.NativeErrorCode != 1223 /*ERROR_CANCELLED*/)
            throw;
        } finally {
          Shutdown(0);
        }
      }

      return true;
    }
#endif


    /// <summary>
    ///   Displays the main window.
    /// </summary>
    private void DisplayMainWindow() {
      Log.SendInformation("Displaying the main window.");

      var mainWindow = new ShellWindow(this);

      // Set version on main window.
      mainWindow.LblAssemblyVersion.Content += $"  {Assembly.GetEntryAssembly().AssemblyVersion()}";
      mainWindow.Show();
      MainWindow = mainWindow;
      MainWindow.Activate();
    }


    /// <summary>
    ///   Handles the Exit event of the Application.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">The <see cref="ExitEventArgs" /> instance containing the event data.</param>
    private void Application_Exit(object sender, ExitEventArgs args) {
      // Dispose the splash screen.
#if !RESTORE
      if (SplashScreen != null) {
        SplashScreenDispatcher.Invoke(SplashScreen.Close);
        SplashScreen.Dispose();
        SplashScreen = null;
      }
#endif

      Log.SendInformation("---- SESSION ENDED ----");
    }
  }
}