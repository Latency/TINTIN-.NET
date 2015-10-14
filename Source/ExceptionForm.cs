using System;
using System.Windows.Forms;

namespace TinTin {
  /// <summary>
  ///   Summary description for ExceptionForm.
  /// </summary>
  internal partial class ExceptionForm : Form {
    private TextBox _errorBox;

    private Button _breakButton;
    private Button _ignoreButton;

    public ExceptionForm(Exception e) {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      Text = e.Source;
      _errorBox.Text = e.ToString();
      _errorBox.SelectionLength = 0;
      //
      // TODO: Add any constructor Code after InitializeComponent call
      //
    }

    public override sealed string Text {
      get { return base.Text; }
      set { base.Text = value; }
    }

    private void ignoreButton_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
    }

    private void breakButton_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.OK;
    }

  }
}