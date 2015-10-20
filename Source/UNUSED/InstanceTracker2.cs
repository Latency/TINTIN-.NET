// *****************************************************************************
// File:      InstanceTracker2.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections;
using System.Windows.Forms;

namespace TinTin {
  /// <summary>
  ///   Summary description for InstanceTracker2.
  /// </summary>
  internal partial class InstanceTracker2 : Form {
    private readonly ArrayList _theData;
    private int _current;

    public InstanceTracker2(ArrayList dataList) {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      _theData = dataList;
      ShowStatus();
      //
      // TODO: Add any constructor Code after InitializeComponent call
      //
    }

    private void ShowStatus() {
      _status.Text = (_current + 1) + @" of " + _theData.Count;
      _textBox.Text = (string) _theData[_current];
    }

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {
      if (disposing)
        _components?.Dispose();
      base.Dispose(disposing);
    }

    private void PreviousButton_Click(object sender, EventArgs e) {
      --_current;
      if (_current < 0)
        _current = 0;
      ShowStatus();
    }

    private void NextButton_Click(object sender, EventArgs e) {
      ++_current;
      if (_current > _theData.Count - 1)
        _current = _theData.Count - 1;
      ShowStatus();
    }
  }
}