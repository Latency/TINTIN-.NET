using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TinTin.DataSources;
using TinTin.DataSources.MusicCollectionDataSetTableAdapters;

namespace TinTin.Forms {
  sealed partial class TreeExampleUserControl {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent(ComponentResourceManager resources) {
      this.components = new System.ComponentModel.Container();
      this.artistsBindingSource = new BindingSource(this.components);
      this.musicCollectionDataSet = new MusicCollectionDataSet();
      this.albumsBindingSource = new BindingSource(this.components);
      this.songsBindingSource = new BindingSource(this.components);
      this.artistsTableAdapter = new ArtistsTableAdapter();
      this.albumsTableAdapter = new AlbumsTableAdapter();
      this.songsTableAdapter = new SongsTableAdapter();
      this.imageList1 = new ImageList(this.components);
      this.radTreeView1 = new RadTreeView();
      this.radPanel1 = new RadPanel();
      this.radPanel3 = new RadPanel();
      this.radDropDownButton1 = new RadDropDownButton();
      this.radLabel1 = new RadLabel();
      this.radTextBox1 = new RadTextBox();
      ((System.ComponentModel.ISupportInitialize) (this.artistsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.musicCollectionDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.albumsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.songsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.radTreeView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.radPanel3)).BeginInit();
      this.radPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.radDropDownButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.radTextBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // artistsBindingSource
      // 
      this.artistsBindingSource.DataMember = "Artists";
      this.artistsBindingSource.DataSource = this.musicCollectionDataSet;
      // 
      // musicCollectionDataSet
      // 
      this.musicCollectionDataSet.DataSetName = "MusicCollectionDataSet";
      this.musicCollectionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // albumsBindingSource
      // 
      this.albumsBindingSource.DataMember = "Albums";
      this.albumsBindingSource.DataSource = this.musicCollectionDataSet;
      // 
      // songsBindingSource
      // 
      this.songsBindingSource.DataMember = "Songs";
      this.songsBindingSource.DataSource = this.musicCollectionDataSet;
      // 
      // artistsTableAdapter
      // 
      this.artistsTableAdapter.ClearBeforeFill = true;
      // 
      // albumsTableAdapter
      // 
      this.albumsTableAdapter.ClearBeforeFill = true;
      // 
      // songsTableAdapter
      // 
      this.songsTableAdapter.ClearBeforeFill = true;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((ImageListStreamer) (resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "folder_feed.png");
      this.imageList1.Images.SetKeyName(1, "feed.png");
      // 
      // radTreeView1
      // 
      this.radTreeView1.Dock = DockStyle.Fill;
      this.radTreeView1.ImageIndex = 0;
      this.radTreeView1.ImageList = this.imageList1;
      this.radTreeView1.Location = new System.Drawing.Point(0, 82);
      this.radTreeView1.Name = "radTreeView1";
      this.radTreeView1.Size = new System.Drawing.Size(457, 343);
      this.radTreeView1.SpacingBetweenNodes = -1;
      this.radTreeView1.TabIndex = 3;
      this.radTreeView1.Text = "radTreeView1";
      this.radTreeView1.NodeExpandedChanging += new RadTreeView.RadTreeViewCancelEventHandler(radTreeView1_NodeExpandedChanging);
      this.radTreeView1.AllowEdit = false;
      this.radTreeView1.AllowAdd = false;
      this.radTreeView1.AllowRemove = false;
      // 
      // radPanel1
      // 
      this.radPanel1.Dock = DockStyle.Top;
      this.radPanel1.Location = new System.Drawing.Point(0, 0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Size = new System.Drawing.Size(457, 44);
      this.radPanel1.TabIndex = 1;
      // 
      // radPanel3
      // 
      this.radPanel3.Controls.Add(this.radDropDownButton1);
      this.radPanel3.Controls.Add(this.radLabel1);
      this.radPanel3.Controls.Add(this.radTextBox1);
      this.radPanel3.Dock = DockStyle.Top;
      this.radPanel3.Location = new System.Drawing.Point(0, 44);
      this.radPanel3.Name = "radPanel3";
      this.radPanel3.Size = new System.Drawing.Size(457, 38);
      this.radPanel3.TabIndex = 2;
      // 
      // radDropDownButton1
      // 
      this.radDropDownButton1.Location = new System.Drawing.Point(38, 7);
      this.radDropDownButton1.Name = "radDropDownButton1";
      this.radDropDownButton1.Size = new System.Drawing.Size(140, 24);
      this.radDropDownButton1.TabIndex = 4;
      this.radDropDownButton1.Text = "None";
      // 
      // radLabel1
      // 
      this.radLabel1.Location = new System.Drawing.Point(3, 10);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(29, 18);
      this.radLabel1.TabIndex = 2;
      this.radLabel1.Text = "Sort:";
      // 
      // radTextBox1
      // 
      this.radTextBox1.Anchor = ((AnchorStyles) (((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
      this.radTextBox1.Location = new System.Drawing.Point(184, 7);
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.NullText = "Type here to filter";
      this.radTextBox1.Size = new System.Drawing.Size(270, 20);
      this.radTextBox1.TabIndex = 0;
      this.radTextBox1.TabStop = false;
      this.radTextBox1.TextChanged += new System.EventHandler(this.radTextBox1_TextChanged);
      // 
      // TreeExampleUserControl
      // 
      this.Controls.Add(this.radTreeView1);
      this.Controls.Add(this.radPanel3);
      this.Controls.Add(this.radPanel1);
      this.Name = "TreeExampleUserControl";
      this.Size = new System.Drawing.Size(457, 425);
      ((System.ComponentModel.ISupportInitialize) (this.radTreeView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.radPanel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.artistsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.musicCollectionDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.albumsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.songsBindingSource)).EndInit();
      this.radPanel3.ResumeLayout(false);
      this.radPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) (this.radDropDownButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.radTextBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private ImageList imageList1;
    private RadPanel radPanel1;
    private RadTreeView radTreeView1;
    private RadPanel radPanel3;
    private RadLabel radLabel1;
    private RadTextBox radTextBox1;
    private RadDropDownButton radDropDownButton1;
    private BindingSource artistsBindingSource;
    private BindingSource albumsBindingSource;
    private BindingSource songsBindingSource;
    private MusicCollectionDataSet musicCollectionDataSet;
    private ArtistsTableAdapter artistsTableAdapter;
    private AlbumsTableAdapter albumsTableAdapter;
    private SongsTableAdapter songsTableAdapter;
  }
}
