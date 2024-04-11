//  *****************************************************************************
//  File:      ShellWindow.xaml.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      06/29/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using AssemblyLoader;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;
using TinTin.GUI.Common;

namespace TinTin.GUI.Windows {
  /// <inheritdoc cref="" />
  /// <summary>
  ///   Controls the presentation and behavior for the main window of the
  ///   OLP Sentinel application.
  /// </summary>
  public partial class ShellWindow {
    /// <summary>
    ///   The object that the class will write diagnostic information to at runtime.
    /// </summary>
    private static readonly IReflectInsight Log = RILogManager.Default;

    /// <summary>
    ///  ShellApplication
    /// </summary>
    private readonly ShellApplication _parent ;

    /// <summary>
    ///   Occurs when close button is clicked.
    /// </summary>
    public event CancelEventHandler CloseClicked;

    /// <summary>
    ///   Occurs when the user requests help.
    /// </summary>
    public event EventHandler HelpClicked;


    /// <inheritdoc />
    /// <summary>
    ///   Initializes a new instance of the ShellWindow class.
    /// </summary>
    public ShellWindow(ShellApplication parent) {
      InitializeComponent();
      _parent = parent;
      Title = Assembly.GetExecutingAssembly().ProductTitle();
      HelpClicked += Help_Trigger;

#if (!DEBUG)
      WindowState = WindowState.Maximized;
      ResizeMode = ResizeMode.NoResize;
#endif
    }


    /// <summary>
    ///   Initializes the window when the window is loaded.
    /// </summary>
    /// <param name="sender">The <see cref="ShellWindow" /> object.</param>
    /// <param name="e">The event arguments.</param>
    private void Window_Loaded(object sender, RoutedEventArgs e) {
      // Setup custom configuration for menu buttons.
      NativeMethods.CustomMenu(this);

      // Attach help button callback.
      var fromVisual = (HwndSource)PresentationSource.FromVisual(this);
      fromVisual?.AddHook(Win32LLHook_Callback);
    }


    /// <summary>
    ///   Handles the event of the Help button control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    internal void Help_Trigger(object sender, EventArgs e) {
      Log.SendInformation("Help button clicked.");
    }


    /// <summary>
    ///   Handles the Click event of the CloseButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
    private void Window_Closed(object sender, EventArgs e) {
      // Terminate process.
      Application.Current.Shutdown();
    }


    /// <summary>
    ///  MenuBar Hook
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <param name="handled"></param>
    /// <returns></returns>
    private IntPtr Win32LLHook_Callback(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
      switch (msg) {
        case (int) NativeConstants.WM_GETMINMAXINFO:
          //NativeMethods.WmGetMinMaxInfo(hwnd, lParam);
          handled = true;
          break;
        case (int) NativeConstants.WM_SYSCOMMAND:
          // 4 low order bits ( NOT bytes) of this ID are used by the system internally see http://www.codeguru.com/forum/showthread.php?t=79864
          switch (wParam.ToInt32() & 0xFFF0) {
#if (!(DEBUG || NOLOCKDOWN) || LOCKDOWN)
            // SC_RESTORE; diable double click on title bar see http://msdn.microsoft.com/en-us/library/ms646360(VS.85).aspx
            case (int) SysCommands.SC_RESTORE:
              handled = true;
              break;
            case (int)SysCommands.SC_MOVE:
              handled = true;
              break;
#endif
            case (int) SysCommands.SC_CLOSE:
              Log.SendInformation("Close button clicked.");
              CloseClicked?.Invoke(this, new CancelEventArgs());
              break;
            case (int) SysCommands.SC_CONTEXTHELP:
              Log.SendInformation("Help button clicked.");
              HelpClicked?.Invoke(this, EventArgs.Empty);
              handled = true;
              break;
          }
          break;
      }
      return IntPtr.Zero;
    }
  }
}