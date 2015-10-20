// *****************************************************************************
// File:      ExceptionMessageBox.cs
// Solution:  TinTin.NET
// Date:      10/20/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Windows.Forms;
using Microsoft.SqlServer.MessageBox;

namespace TinTin {
  /// <summary>
  ///   ExceptionMessageBox
  /// </summary>
  public sealed class ExceptionMessageBox : Microsoft.SqlServer.MessageBox.ExceptionMessageBox {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="exception"></param>
    public ExceptionMessageBox(Exception exception) : base(exception) {
      Buttons = ExceptionMessageBoxButtons.AbortRetryIgnore;
      Caption = "Application Exception";
      ShowCheckBox = true;
      ShowToolBar = true;
      Symbol = ExceptionMessageBoxSymbol.Stop;
    }

    /// <summary>
    ///   Show (+1 overload)
    /// </summary>
    /// <param name="hWindow"></param>
    /// <returns></returns>
    public new DialogResult Show(IWin32Window hWindow = null) {
      return Show(Message, hWindow);
    }

    /// <summary>
    ///   Show (+2 overload)
    /// </summary>
    /// <param name="message"></param>
    /// <param name="hWindow"></param>
    /// <returns></returns>
    public DialogResult Show(Exception message, IWin32Window hWindow = null) {
      Message = message;
      return base.Show(hWindow ?? new Form());
    }
  }
}