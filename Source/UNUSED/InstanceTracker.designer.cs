using System.ComponentModel;
using System.Windows.Forms;

namespace TinTin {
  partial class InstanceTracker {
    #region Windows Form Designer generated Code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the Code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceTracker));
      this.DetailMenu = new ContextMenu();
      this.DetailMenuItem = new MenuItem();
      this.statusBar = new StatusBar();
      this.mainMenu = new MainMenu(this.components);
      this.menuItem1 = new MenuItem();
      this.saveAsMenuItem = new MenuItem();
      this.menuItem8 = new MenuItem();
      this.gcMenuItem = new MenuItem();
      this.fullGcMenuItem = new MenuItem();
      this.menuItem4 = new MenuItem();
      this.enableInstanceTrackingMenuItem = new MenuItem();
      this.menuItem3 = new MenuItem();
      this.closeMenuItem = new MenuItem();
      this.menuItem2 = new MenuItem();
      this.showExceptionsMenuItem = new MenuItem();
      this.showWarningsMenuItem = new MenuItem();
      this.showInformationMenuItem = new MenuItem();
      this.showAuditMenuItem = new MenuItem();
      this.menuItem5 = new MenuItem();
      this.haltOnExceptionsMenuItem = new MenuItem();
      this.menuItem6 = new MenuItem();
      this.ClearEventMenuItem = new MenuItem();
      this.tabControl1 = new TabControl();
      this.tabPage2 = new TabPage();
      this.EventText = new TextBox();
      this.splitter1 = new Splitter();
      this.EventListView = new ListView();
      this.columnHeader4 = ((ColumnHeader)(new ColumnHeader()));
      this.columnHeader3 = ((ColumnHeader)(new ColumnHeader()));
      this.iconImageList = new ImageList(this.components);
      this.tabPage1 = new TabPage();
      this.instanceListView = new ListView();
      this.columnHeader1 = ((ColumnHeader)(new ColumnHeader()));
      this.columnHeader2 = ((ColumnHeader)(new ColumnHeader()));
      this.ToolsIconList = new ImageList(this.components);
      this.eventToolBar = new ToolBar();
      this.toolBarButton3 = new ToolBarButton();
      this.showExceptionsToolBarButton = new ToolBarButton();
      this.showWarningEventsToolBarButton = new ToolBarButton();
      this.showInformationEventsToolBarButton = new ToolBarButton();
      this.showAuditEventsToolBarButton = new ToolBarButton();
      this.toolBarButton1 = new ToolBarButton();
      this.clearEventLogToolBarButton = new ToolBarButton();
      this.toolBarButton2 = new ToolBarButton();
      this.gcToolBarButton = new ToolBarButton();
      this.saveLogFileDialog = new SaveFileDialog();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // DetailMenu
      // 
      this.DetailMenu.MenuItems.AddRange(new MenuItem[] {
        this.DetailMenuItem
      });
      // 
      // DetailMenuItem
      // 
      this.DetailMenuItem.Index = 0;
      this.DetailMenuItem.Text = "Details";
      this.DetailMenuItem.Click += new System.EventHandler(this.DetailMenuItem_Click);
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 441);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(480, 16);
      this.statusBar.TabIndex = 1;
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new MenuItem[] {
        this.menuItem1,
        this.menuItem2
      });
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new MenuItem[] {
        this.saveAsMenuItem,
        this.menuItem8,
        this.gcMenuItem,
        this.fullGcMenuItem,
        this.menuItem4,
        this.enableInstanceTrackingMenuItem,
        this.menuItem3,
        this.closeMenuItem
      });
      this.menuItem1.Text = "&File";
      // 
      // saveAsMenuItem
      // 
      this.saveAsMenuItem.Index = 0;
      this.saveAsMenuItem.Text = "Save As...";
      this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
      // 
      // menuItem8
      // 
      this.menuItem8.Index = 1;
      this.menuItem8.Text = "-";
      // 
      // gcMenuItem
      // 
      this.gcMenuItem.Index = 2;
      this.gcMenuItem.Text = "&Garbage Collect";
      this.gcMenuItem.Click += new System.EventHandler(this.gcMenuItem_Click);
      // 
      // fullGcMenuItem
      // 
      this.fullGcMenuItem.Index = 3;
      this.fullGcMenuItem.Text = "&Full Garbage Collect";
      this.fullGcMenuItem.Click += new System.EventHandler(this.fullGcMenuItem_Click);
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 4;
      this.menuItem4.Text = "-";
      // 
      // enableInstanceTrackingMenuItem
      // 
      this.enableInstanceTrackingMenuItem.Index = 5;
      this.enableInstanceTrackingMenuItem.Text = "&Enable Object Tracking";
      this.enableInstanceTrackingMenuItem.Click += new System.EventHandler(this.enableInstanceTrackingMenuItem_Click);
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 6;
      this.menuItem3.Text = "-";
      // 
      // closeMenuItem
      // 
      this.closeMenuItem.Index = 7;
      this.closeMenuItem.Text = "&Close";
      this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 1;
      this.menuItem2.MenuItems.AddRange(new MenuItem[] {
        this.showExceptionsMenuItem,
        this.showWarningsMenuItem,
        this.showInformationMenuItem,
        this.showAuditMenuItem,
        this.menuItem5,
        this.haltOnExceptionsMenuItem,
        this.menuItem6,
        this.ClearEventMenuItem
      });
      this.menuItem2.Text = "Events";
      // 
      // showExceptionsMenuItem
      // 
      this.showExceptionsMenuItem.Index = 0;
      this.showExceptionsMenuItem.Text = "Show &Exception Messages";
      this.showExceptionsMenuItem.Click += new System.EventHandler(this.showExceptionsMenuItem_Click);
      // 
      // showWarningsMenuItem
      // 
      this.showWarningsMenuItem.Index = 1;
      this.showWarningsMenuItem.Text = "Show &Warning Messages";
      this.showWarningsMenuItem.Click += new System.EventHandler(this.showWarningsMenuItem_Click);
      // 
      // showInformationMenuItem
      // 
      this.showInformationMenuItem.Index = 2;
      this.showInformationMenuItem.Text = "Show &Information Messages";
      this.showInformationMenuItem.Click += new System.EventHandler(this.showInformationMenuItem_Click);
      // 
      // showAuditMenuItem
      // 
      this.showAuditMenuItem.Index = 3;
      this.showAuditMenuItem.Text = "Show &Audit Messages";
      this.showAuditMenuItem.Click += new System.EventHandler(this.showAuditMenuItem_Click);
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 4;
      this.menuItem5.Text = "-";
      // 
      // haltOnExceptionsMenuItem
      // 
      this.haltOnExceptionsMenuItem.Index = 5;
      this.haltOnExceptionsMenuItem.Text = "&Halt On Exceptions";
      this.haltOnExceptionsMenuItem.Click += new System.EventHandler(this.haltOnExceptionsMenuItem_Click);
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 6;
      this.menuItem6.Text = "-";
      // 
      // ClearEventMenuItem
      // 
      this.ClearEventMenuItem.Index = 7;
      this.ClearEventMenuItem.Text = "&Clear Event Log";
      this.ClearEventMenuItem.Click += new System.EventHandler(this.ClearEventMenuItem_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Alignment = TabAlignment.Bottom;
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 28);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(480, 413);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.EventText);
      this.tabPage2.Controls.Add(this.splitter1);
      this.tabPage2.Controls.Add(this.EventListView);
      this.tabPage2.Location = new System.Drawing.Point(4, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(472, 387);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Events";
      // 
      // EventText
      // 
      this.EventText.BorderStyle = BorderStyle.None;
      this.EventText.Dock = DockStyle.Fill;
      this.EventText.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.EventText.Location = new System.Drawing.Point(0, 179);
      this.EventText.Multiline = true;
      this.EventText.Name = "EventText";
      this.EventText.ReadOnly = true;
      this.EventText.ScrollBars = ScrollBars.Vertical;
      this.EventText.Size = new System.Drawing.Size(472, 208);
      this.EventText.TabIndex = 1;
      this.EventText.TabStop = false;
      this.EventText.TextChanged += new System.EventHandler(this.EventText_TextChanged);
      // 
      // splitter1
      // 
      this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitter1.Dock = DockStyle.Top;
      this.splitter1.Location = new System.Drawing.Point(0, 176);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(472, 3);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      // 
      // EventListView
      // 
      this.EventListView.BorderStyle = BorderStyle.None;
      this.EventListView.Columns.AddRange(new ColumnHeader[] {
        this.columnHeader4,
        this.columnHeader3
      });
      this.EventListView.Dock = DockStyle.Top;
      this.EventListView.FullRowSelect = true;
      this.EventListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.EventListView.LargeImageList = this.iconImageList;
      this.EventListView.Location = new System.Drawing.Point(0, 0);
      this.EventListView.MultiSelect = false;
      this.EventListView.Name = "EventListView";
      this.EventListView.Size = new System.Drawing.Size(472, 176);
      this.EventListView.SmallImageList = this.iconImageList;
      this.EventListView.TabIndex = 0;
      this.EventListView.UseCompatibleStateImageBehavior = false;
      this.EventListView.View = View.Details;
      this.EventListView.SelectedIndexChanged += new System.EventHandler(this.EventListView_SelectedIndexChanged);
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Origin";
      this.columnHeader4.Width = 150;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Message";
      this.columnHeader3.Width = 300;
      // 
      // iconImageList
      // 
      this.iconImageList.ImageStream =
        ((ImageListStreamer)(resources.GetObject("iconImageList.ImageStream")));
      this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.iconImageList.Images.SetKeyName(0, "");
      this.iconImageList.Images.SetKeyName(1, "");
      this.iconImageList.Images.SetKeyName(2, "");
      this.iconImageList.Images.SetKeyName(3, "");
      this.iconImageList.Images.SetKeyName(4, "");
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.instanceListView);
      this.tabPage1.Location = new System.Drawing.Point(4, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(472, 387);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Instances";
      // 
      // instanceListView
      // 
      this.instanceListView.BorderStyle = BorderStyle.None;
      this.instanceListView.Columns.AddRange(new ColumnHeader[] {
        this.columnHeader1,
        this.columnHeader2
      });
      this.instanceListView.ContextMenu = this.DetailMenu;
      this.instanceListView.Dock = DockStyle.Fill;
      this.instanceListView.FullRowSelect = true;
      this.instanceListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.instanceListView.Location = new System.Drawing.Point(0, 0);
      this.instanceListView.MultiSelect = false;
      this.instanceListView.Name = "instanceListView";
      this.instanceListView.Size = new System.Drawing.Size(472, 387);
      this.instanceListView.Sorting = SortOrder.Ascending;
      this.instanceListView.TabIndex = 1;
      this.instanceListView.UseCompatibleStateImageBehavior = false;
      this.instanceListView.View = View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Count";
      this.columnHeader1.Width = 81;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Object";
      this.columnHeader2.Width = 370;
      // 
      // ToolsIconList
      // 
      this.ToolsIconList.ImageStream =
        ((ImageListStreamer)(resources.GetObject("ToolsIconList.ImageStream")));
      this.ToolsIconList.TransparentColor = System.Drawing.Color.Transparent;
      this.ToolsIconList.Images.SetKeyName(0, "");
      this.ToolsIconList.Images.SetKeyName(1, "");
      this.ToolsIconList.Images.SetKeyName(2, "");
      this.ToolsIconList.Images.SetKeyName(3, "");
      this.ToolsIconList.Images.SetKeyName(4, "");
      this.ToolsIconList.Images.SetKeyName(5, "");
      this.ToolsIconList.Images.SetKeyName(6, "");
      // 
      // eventToolBar
      // 
      this.eventToolBar.Appearance = ToolBarAppearance.Flat;
      this.eventToolBar.Buttons.AddRange(new ToolBarButton[] {
        this.toolBarButton3,
        this.showExceptionsToolBarButton,
        this.showWarningEventsToolBarButton,
        this.showInformationEventsToolBarButton,
        this.showAuditEventsToolBarButton,
        this.toolBarButton1,
        this.clearEventLogToolBarButton,
        this.toolBarButton2,
        this.gcToolBarButton
      });
      this.eventToolBar.DropDownArrows = true;
      this.eventToolBar.ImageList = this.ToolsIconList;
      this.eventToolBar.Location = new System.Drawing.Point(0, 0);
      this.eventToolBar.Name = "eventToolBar";
      this.eventToolBar.ShowToolTips = true;
      this.eventToolBar.Size = new System.Drawing.Size(480, 28);
      this.eventToolBar.TabIndex = 4;
      this.eventToolBar.ButtonClick +=
        new ToolBarButtonClickEventHandler(this.eventToolBar_ButtonClick);
      // 
      // toolBarButton3
      // 
      this.toolBarButton3.Name = "toolBarButton3";
      this.toolBarButton3.Style = ToolBarButtonStyle.Separator;
      // 
      // showExceptionsToolBarButton
      // 
      this.showExceptionsToolBarButton.ImageIndex = 3;
      this.showExceptionsToolBarButton.Name = "showExceptionsToolBarButton";
      this.showExceptionsToolBarButton.Style = ToolBarButtonStyle.ToggleButton;
      this.showExceptionsToolBarButton.ToolTipText = "Show Exception Messages";
      // 
      // showWarningEventsToolBarButton
      // 
      this.showWarningEventsToolBarButton.ImageIndex = 2;
      this.showWarningEventsToolBarButton.Name = "showWarningEventsToolBarButton";
      this.showWarningEventsToolBarButton.Style = ToolBarButtonStyle.ToggleButton;
      this.showWarningEventsToolBarButton.ToolTipText = "Show Warnings Messages";
      // 
      // showInformationEventsToolBarButton
      // 
      this.showInformationEventsToolBarButton.ImageIndex = 1;
      this.showInformationEventsToolBarButton.Name = "showInformationEventsToolBarButton";
      this.showInformationEventsToolBarButton.Style = ToolBarButtonStyle.ToggleButton;
      this.showInformationEventsToolBarButton.ToolTipText = "Show Information Messages";
      // 
      // showAuditEventsToolBarButton
      // 
      this.showAuditEventsToolBarButton.ImageIndex = 6;
      this.showAuditEventsToolBarButton.Name = "showAuditEventsToolBarButton";
      this.showAuditEventsToolBarButton.Style = ToolBarButtonStyle.ToggleButton;
      this.showAuditEventsToolBarButton.ToolTipText = "Show Audit Messages";
      // 
      // toolBarButton1
      // 
      this.toolBarButton1.Name = "toolBarButton1";
      this.toolBarButton1.Style = ToolBarButtonStyle.Separator;
      // 
      // clearEventLogToolBarButton
      // 
      this.clearEventLogToolBarButton.ImageIndex = 4;
      this.clearEventLogToolBarButton.Name = "clearEventLogToolBarButton";
      this.clearEventLogToolBarButton.ToolTipText = "Clear Event Log";
      // 
      // toolBarButton2
      // 
      this.toolBarButton2.ImageIndex = 5;
      this.toolBarButton2.Name = "toolBarButton2";
      this.toolBarButton2.Style = ToolBarButtonStyle.Separator;
      // 
      // gcToolBarButton
      // 
      this.gcToolBarButton.ImageIndex = 5;
      this.gcToolBarButton.Name = "gcToolBarButton";
      this.gcToolBarButton.ToolTipText = "Force Garbage Collection";
      // 
      // saveLogFileDialog
      // 
      this.saveLogFileDialog.DefaultExt = "log";
      this.saveLogFileDialog.FileName = "DebugInformation.log";
      this.saveLogFileDialog.Filter = "Log Files|*.log";
      this.saveLogFileDialog.Title = "Save Debug Information Log";
      // 
      // InstanceTracker
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(480, 457);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.eventToolBar);
      this.Controls.Add(this.statusBar);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu;
      this.Name = "InstanceTracker";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Debug Information";
      this.Closed += new System.EventHandler(this.InstanceTracker_Closed);
      this.FormClosing += new FormClosingEventHandler(this.InstanceTracker_FormClosing);
      this.Load += new System.EventHandler(this.InstanceTracker_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private MenuItem ClearEventMenuItem;
    private ContextMenu DetailMenu;
    private MenuItem DetailMenuItem;
    private ListView EventListView;
    private TextBox EventText;
    private ImageList ToolsIconList;
    private ToolBarButton clearEventLogToolBarButton;
    private MenuItem closeMenuItem;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private IContainer components;
    private MenuItem enableInstanceTrackingMenuItem;
    private ToolBar eventToolBar;
    private MenuItem fullGcMenuItem;
    private MenuItem gcMenuItem;
    private ToolBarButton gcToolBarButton;
    private MenuItem haltOnExceptionsMenuItem;
    private ImageList iconImageList;
    private ListView instanceListView;
    private MainMenu mainMenu;
    private MenuItem menuItem1;
    private MenuItem menuItem2;
    private MenuItem menuItem3;
    private MenuItem menuItem4;
    private MenuItem menuItem5;
    private MenuItem menuItem6;
    private MenuItem menuItem8;
    private MenuItem saveAsMenuItem;
    private SaveFileDialog saveLogFileDialog;
    private ToolBarButton showAuditEventsToolBarButton;
    private MenuItem showAuditMenuItem;
    private MenuItem showExceptionsMenuItem;
    private ToolBarButton showExceptionsToolBarButton;
    private ToolBarButton showInformationEventsToolBarButton;
    private MenuItem showInformationMenuItem;
    private ToolBarButton showWarningEventsToolBarButton;
    private MenuItem showWarningsMenuItem;
    private Splitter splitter1;
    private StatusBar statusBar;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private ToolBarButton toolBarButton1;
    private ToolBarButton toolBarButton2;
    private ToolBarButton toolBarButton3;
  }
}
