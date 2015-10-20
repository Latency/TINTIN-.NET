using System.ComponentModel;
using System.Windows.Forms;


namespace TinTin {
  partial class InstanceTracker2 {
    #region Windows Form Designer generated Code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the Code editor.
    /// </summary>
    private void InitializeComponent() {
      this._textBox = new TextBox();
      this._previousButton = new Button();
      this._nextButton = new Button();
      this._status = new Label();
      this.SuspendLayout();
      // 
      // TextBox
      // 
      this._textBox.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                              | AnchorStyles.Left)
                             | AnchorStyles.Right);
      this._textBox.Location = new System.Drawing.Point(8, 8);
      this._textBox.Multiline = true;
      this._textBox.Name = "TextBox";
      this._textBox.ReadOnly = true;
      this._textBox.Size = new System.Drawing.Size(344, 232);
      this._textBox.TabIndex = 0;
      this._textBox.Text = "";
      // 
      // PreviousButton
      // 
      this._previousButton.Anchor = AnchorStyles.Bottom;
      this._previousButton.Location = new System.Drawing.Point(8, 248);
      this._previousButton.Name = "_previousButton";
      this._previousButton.TabIndex = 1;
      this._previousButton.Text = "<<";
      this._previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
      // 
      // NextButton
      // 
      this._nextButton.Anchor = AnchorStyles.Bottom;
      this._nextButton.Location = new System.Drawing.Point(280, 248);
      this._nextButton.Name = "_nextButton";
      this._nextButton.TabIndex = 2;
      this._nextButton.Text = ">>";
      this._nextButton.Click += new System.EventHandler(this.NextButton_Click);
      // 
      // Status
      // 
      this._status.Anchor = AnchorStyles.Bottom;
      this._status.Location = new System.Drawing.Point(128, 248);
      this._status.Name = "_status";
      this._status.TabIndex = 3;
      this._status.Text = "1 of 1";
      this._status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // InstanceTracker2
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(360, 278);
      this.Controls.AddRange(new Control[] {
        this._status,
        this._nextButton,
        this._previousButton,
        this._textBox
      });
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "InstanceTracker2";
      this.Text = "InstanceTracker2";
      this.ResumeLayout(false);
    }

    #endregion

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container _components = null;

    private Button _nextButton;
    private Button _previousButton;
    private Label _status;
    private TextBox _textBox;
  }
}
