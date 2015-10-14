using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;


namespace TinTin.Forms {
  /// <summary>
  ///   Example beautifying
  /// </summary>
  public sealed partial class TreeExampleUserControl : UserControl {
    private readonly List<Bitmap> _level = new List<Bitmap>();

    public TreeExampleUserControl() {
      var resources = new ComponentResourceManager(typeof(TreeExampleUserControl));
      InitializeComponent(resources);

      foreach (var image in new[] {"level1", "level2", "level3" } )
        _level.Add(((Bitmap) (resources.GetObject(image))));

      ThemeResolutionService.ApplyThemeToControlTree(this, "TelerikMetroBlue");

      var item = new RadMenuItem("None");
      item.Click += item_Click;
      radDropDownButton1.Items.Add(item);

      item = new RadMenuItem("Alphabetically");
      item.Click += item_Click;
      radDropDownButton1.Items.Add(item);

      var searchIcon = new ImagePrimitive { Image = ((Image) (resources.GetObject("TV_search"))), Alignment = ContentAlignment.MiddleRight };
      radTextBox1.TextBoxElement.Children.Add(searchIcon);
      radTextBox1.TextBoxElement.TextBoxItem.Alignment = ContentAlignment.MiddleLeft;
      radTextBox1.TextBoxElement.TextBoxItem.PropertyChanged += TextBoxItem_PropertyChanged;
      radTreeView1.TreeViewElement.AllowAlternatingRowColor = true;
      radTreeView1.AllowEdit = false;
      radTreeView1.AllowAdd = false;
      radTreeView1.AllowRemove = false;
      radTreeView1.ItemHeight = 34;
      radTreeView1.AllowDefaultContextMenu = false;

      AutoScroll = false;

      radPanel3.PanelElement.PanelFill.BackColor = Color.White;
      radPanel3.BackColor = Color.White;
      radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
      radPanel3.PanelElement.PanelBorder.TopColor = Color.FromArgb(196, 199, 182);
      radPanel3.PanelElement.PanelBorder.LeftColor = Color.FromArgb(196, 199, 182);
      radPanel3.PanelElement.PanelBorder.RightColor = Color.FromArgb(196, 199, 182);
      radPanel3.PanelElement.PanelBorder.BottomColor = Color.White;
      radPanel3.PanelElement.PanelBorder.BoxStyle = BorderBoxStyle.FourBorders;
      radPanel3.PanelElement.PanelBorder.BorderDrawMode = BorderDrawModes.VerticalOverHorizontal;
      radPanel3.PanelElement.PanelBorder.GradientStyle = GradientStyles.Solid;

      radPanel1.PanelElement.PanelFill.BackColor = Color.FromArgb(26, 93, 192);
      radPanel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
      radPanel1.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
      radPanel1.PanelElement.Font = new Font("Segoe UI Light", 20, FontStyle.Regular);
      radPanel1.ForeColor = Color.White;
      radPanel1.PanelElement.Padding = new Padding(8, 2, 2, 2);
      radPanel1.Text = @"Music Collection";
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      artistsTableAdapter.Fill(musicCollectionDataSet.Artists);
      albumsTableAdapter.Fill(musicCollectionDataSet.Albums);
      songsTableAdapter.Fill(musicCollectionDataSet.Songs);

      using (radTreeView1.DeferRefresh()) {
        radTreeView1.RelationBindings.Add(albumsBindingSource, "AlbumName", "ArtistID");
        radTreeView1.RelationBindings.Add(songsBindingSource, "SongName", "AlbumID");
        radTreeView1.DisplayMember = "ArtistName";
        radTreeView1.DataSource = artistsBindingSource;
      }

      foreach (var node in radTreeView1.Nodes)
        node.Expand();
    }

    private void item_Click(object sender, EventArgs e) {
      var item = (RadMenuItem) sender;
      radDropDownButton1.Text = item.Text;
      radTreeView1.SortOrder = item.Text == @"None" ? SortOrder.None : SortOrder.Ascending;
    }

    private void radTextBox1_TextChanged(object sender, EventArgs e) {
      radTreeView1.Filter = radTextBox1.Text;
    }

    private void radTreeView1_NodeExpandedChanging(object sender, RadTreeViewCancelEventArgs e) {
      var nodes = e.Node.Nodes;
      if (e.Node.Level == 0)
        e.Node.Image = _level[0];
      foreach (var node in nodes) {
        switch (node.Level) {
          case 0:
            node.Image = _level[0];
            break;
          case 1:
            node.Image = _level[1];
            break;
          default:
            node.Image = _level[2];
            break;
        }
      }
    }

    private void TextBoxItem_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      if (e.PropertyName == "Bounds")
        radTextBox1.TextBoxElement.TextBoxItem.HostedControl.MaximumSize = new Size(radTextBox1.Size.Width - 28, 0);
    }
  }
}