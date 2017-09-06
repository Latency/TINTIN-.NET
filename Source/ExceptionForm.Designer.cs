using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinTin {
  internal partial class ExceptionForm {
    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container _components = null;

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {
      if (disposing) if (_components != null)
          _components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated Code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the Code editor.
    /// </summary>
    private void InitializeComponent() {
      this._errorBox = new System.Windows.Forms.TextBox();
      this._breakButton = new System.Windows.Forms.Button();
      this._ignoreButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _errorBox
      // 
      this._errorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._errorBox.Location = new System.Drawing.Point(8, 8);
      this._errorBox.Multiline = true;
      this._errorBox.Name = "_errorBox";
      this._errorBox.ReadOnly = true;
      this._errorBox.Size = new System.Drawing.Size(416, 168);
      this._errorBox.TabIndex = 0;
      // 
      // _breakButton
      // 
      this._breakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._breakButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._breakButton.Location = new System.Drawing.Point(272, 184);
      this._breakButton.Name = "_breakButton";
      this._breakButton.Size = new System.Drawing.Size(75, 23);
      this._breakButton.TabIndex = 1;
      this._breakButton.Text = "Break";
      this._breakButton.Click += new System.EventHandler(this.breakButton_Click);
      // 
      // _ignoreButton
      // 
      this._ignoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._ignoreButton.Location = new System.Drawing.Point(352, 184);
      this._ignoreButton.Name = "_ignoreButton";
      this._ignoreButton.Size = new System.Drawing.Size(75, 23);
      this._ignoreButton.TabIndex = 2;
      this._ignoreButton.Text = "Ignore";
      this._ignoreButton.Click += new System.EventHandler(this.ignoreButton_Click);
      // 
      // ExceptionForm
      // 
      this.AcceptButton = this._ignoreButton;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(432, 214);
      this.Controls.Add(this._ignoreButton);
      this.Controls.Add(this._breakButton);
      this.Controls.Add(this._errorBox);
      this.Name = "ExceptionForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ExceptionForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
  }
}
