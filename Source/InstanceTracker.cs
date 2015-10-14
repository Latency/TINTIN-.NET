// *****************************************************************************
// File:      InstanceTracker.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinTin {
  /// <summary>
  ///   Summary description for InstanceTracker.
  /// </summary>
  public sealed partial class InstanceTracker : Form {
    public delegate void TrackerHandler(object obj);

    public static string VersionString = "0.01";
    public new static bool Enabled;
    private static long _timeValue;
    private static readonly Hashtable _dataTable = new Hashtable();
    private static readonly Hashtable _instancetable = new Hashtable();
    private static InstanceTracker _tracker;

    public InstanceTracker() {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      instanceListView.ListViewItemSorter = new InstanceTrackerSorter();

      EventLogger.OnEvent += OnEventSink;
      EventLogger.Enabled = true;

      if (EventLogger.ShowAll != true)
        return;
      showInformationMenuItem.Checked = true;
      showWarningsMenuItem.Checked = true;
      showExceptionsMenuItem.Checked = true;
      showAuditMenuItem.Checked = true;
    }

    public static void StartTimer() {
      _timeValue = DateTime.Now.Ticks;
    }

    public static void StopTimer() {
      StopTimer("");
    }

    public static void StopTimer(string s) {
      MessageBox.Show(@"Time to execute: " + s + @" = " + new TimeSpan(DateTime.Now.Ticks - _timeValue).TotalMilliseconds);
    }

    private void OnEventSink(EventLogEntryType logType, object origin, string trace, string information) {
      BeginInvoke(new EventLogger.EventHandler(OnEventSinkEx), logType, origin, trace, information);
    }

    private void OnEventSinkEx(EventLogEntryType logType, object origin, string trace, string information) {
      lock (this) {
        int imageIndex;
        switch (logType) {
          case EventLogEntryType.Information:
            imageIndex = 0;
            if (!showInformationMenuItem.Checked)
              return;
            break;
          case EventLogEntryType.Warning:
            imageIndex = 1;
            if (!showWarningsMenuItem.Checked)
              return;
            break;
          case EventLogEntryType.Error:
            imageIndex = 2;
            if (!showExceptionsMenuItem.Checked)
              return;
            break;
          case EventLogEntryType.SuccessAudit:
            imageIndex = 3;
            if (!showAuditMenuItem.Checked)
              return;
            break;
          default:
            imageIndex = 4;
            break;
        }

        string originString;
        var s = origin as string;
        if (s != null)
          originString = s;
        else
          originString = origin.GetType().Name + " [" + origin.GetHashCode() + "]";

        var i = new ListViewItem(new[] {
          originString,
          information
        }, imageIndex);
        var s1 = origin as string;
        if (s1 != null)
          originString = s1;
        else
          originString = origin.GetType().FullName + " [" + origin.GetHashCode() + "]";
        if (trace != "") {
          i.Tag = "Origin: " + originString + "\r\nTime: " + DateTime.Now + "\r\n\r\n" + information +
                  "\r\n\r\nTRACE:\r\n" + trace;
        } else
          i.Tag = "Origin: " + originString + "\r\nTime: " + DateTime.Now + "\r\n\r\n" + information;
        EventListView.Items.Insert(0, i);
      }
    }

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {
      if (disposing)
        components?.Dispose();
      base.Dispose(disposing);
    }

    /// <summary>
    ///   Add one to the counter for the type specified by object o.
    /// </summary>
    /// <param Name="o"></param>
    public static void Add(object o) {
      if (Enabled == false)
        return;
      lock (_instancetable) {
        var st = new StackTrace();
        StackFrame sf;
        var idx = 0;
        var sb = new StringBuilder();


        do {
          sf = st.GetFrame(idx);
          if (sf != null) {
            if (sb.Length == 0) {
              var declaringType = sf.GetMethod().DeclaringType;
              if (declaringType != null)
                sb.Append(declaringType.FullName + " : " + sf.GetMethod().Name);
            } else {
              sb.Append("\r\n");
              var declaringType = sf.GetMethod().DeclaringType;
              if (declaringType != null)
                sb.Append(declaringType.FullName + " : " + sf.GetMethod().Name);
            }
          }
          ++idx;
        } while (sf != null && idx != 7);


        var name = o.GetType().FullName;

        if (_dataTable.ContainsKey(name) == false)
          _dataTable[name] = new ArrayList();
        var iss = new InstanceStruct {
          WR = new WeakReference(o),
          StackList = sb.ToString()
        };
        ((ArrayList) _dataTable[name]).Add(iss);

        if (_tracker == null)
          return;
        _tracker.UpdateDisplayEntry(name);
        _tracker.statusBar.BeginInvoke(new TrackerHandler(HandleTracker), o.GetType().FullName);
      }
    }

    public static void HandleTracker(object name) {
      _tracker.statusBar.Text = @"Add: " + (string) name;
    }

    /// <summary>
    ///   Remove one to the counter for the type specified by object o.
    /// </summary>
    /// <param Name="o"></param>
    public static void Remove(object o) {
      if (Enabled == false)
        return;
      lock (_instancetable) {
        if (_tracker == null)
          return;
        _tracker.UpdateDisplayEntry(o.GetType().FullName);
        _tracker.statusBar.Text = @"Remove: " + o.GetType().FullName;
      }
    }

    private void InstanceTracker_Closed(object sender, EventArgs e) {
      _tracker.Dispose();
      _tracker = null;
    }

    /// <summary>
    ///   Display the tracking debug window to the user. If an instance of the windows
    ///   is already shown, it will pop it back to front.
    /// </summary>
    public static void Display() {
      if (_tracker != null)
        _tracker.Activate();
      else {
        _tracker = new InstanceTracker();
        _tracker.Show();
      }
    }

    private void UpdateDisplay() {
      lock (_instancetable) {
        instanceListView.Items.Clear();
        foreach (string name in _instancetable.Keys) {
          instanceListView.Items.Add(new ListViewItem(new[] {
            _instancetable[name].ToString(),
            name
          }));
        }
      }
      showExceptionsToolBarButton.Pushed = showExceptionsMenuItem.Checked;
      showWarningEventsToolBarButton.Pushed = showWarningsMenuItem.Checked;
      showInformationEventsToolBarButton.Pushed = showInformationMenuItem.Checked;
      showAuditEventsToolBarButton.Pushed = showAuditMenuItem.Checked;
    }

    private void UpdateDisplayEntry(string name) {
      Recalculate(name);
      lock (_instancetable) {
        foreach (var li in instanceListView.Items.Cast<ListViewItem>().Where(li => li.SubItems[1].Text == name)) {
          li.SubItems[0].Text = _instancetable[name].ToString();
          return;
        }

        instanceListView.Items.Add(new ListViewItem(new[] {
          _instancetable[name].ToString(),
          name
        }));
      }
    }

    private void InstanceTracker_Load(object sender, EventArgs e) {
      UpdateDisplay();
    }

    private void gcMenuItem_Click(object sender, EventArgs e) {
      GC.Collect();
      Recalculate();
      UpdateDisplay();
    }

    private static void Recalculate(string name) {
      lock (_instancetable) {
        if (_dataTable.ContainsKey(name)) {
          var a = (ArrayList) _dataTable[name];
          var removeList = new ArrayList();
          foreach (var iss in a.Cast<InstanceStruct>().Where(iss => iss.WR.IsAlive == false))
            removeList.Add(iss);
          foreach (InstanceStruct iss in removeList)
            a.Remove(iss);
          _instancetable[name] = (long) a.Count;
        } else
          _instancetable[name] = (long) 0;
      }
    }

    private static void Recalculate() {
      lock (_instancetable) {
        var en = _instancetable.GetEnumerator();
        var keyList = new ArrayList();
        while (en.MoveNext())
          keyList.Add(en.Key);
        foreach (string objectName in keyList) {
          if (!_dataTable.ContainsKey(objectName))
            continue;
          var a = (ArrayList) _dataTable[objectName];
          var removeList = new ArrayList();
          foreach (var iss in a.Cast<InstanceStruct>().Where(iss => iss.WR.IsAlive == false))
            removeList.Add(iss);
          foreach (InstanceStruct iss in removeList)
            a.Remove(iss);
          _instancetable[objectName] = (long) a.Count;
        }
      }
    }

    private void closeMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void fullGcMenuItem_Click(object sender, EventArgs e) {
      var mem = GC.GetTotalMemory(true);
      statusBar.Text = @"Memory: " + mem;
    }

    private void DetailMenuItem_Click(object sender, EventArgs e) {
      var lvi = instanceListView.SelectedItems[0];
      var compName = lvi.SubItems[1].Text;
      var a = (ArrayList) _dataTable[compName];
      var dl = new ArrayList();
      foreach (var iss in a.Cast<InstanceStruct>().Where(iss => iss.WR.IsAlive))
        dl.Add(iss.StackList);
      if (dl.Count > 0) {
        var it2 = new InstanceTracker2(dl) {
          Text = compName
        };
        it2.ShowDialog();
        it2.Dispose();
      } else
        MessageBox.Show(@"No details for this item");
    }

    private void ClearEventMenuItem_Click(object sender, EventArgs e) {
      EventText.Text = "";
      EventListView.Items.Clear();
    }

    private void haltOnExceptionsMenuItem_Click(object sender, EventArgs e) {
      haltOnExceptionsMenuItem.Checked = !haltOnExceptionsMenuItem.Checked;
      EventLogger.SetOnExceptionAction(haltOnExceptionsMenuItem.Checked);
    }

    private void enableInstanceTrackingMenuItem_Click(object sender, EventArgs e) {
      enableInstanceTrackingMenuItem.Checked = !enableInstanceTrackingMenuItem.Checked;
      Enabled = enableInstanceTrackingMenuItem.Checked;
    }

    private void eventToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      if (e.Button == showExceptionsToolBarButton)
        showExceptionsMenuItem_Click(this, null);
      if (e.Button == showWarningEventsToolBarButton)
        showWarningsMenuItem_Click(this, null);
      if (e.Button == showInformationEventsToolBarButton)
        showInformationMenuItem_Click(this, null);
      if (e.Button == showAuditEventsToolBarButton)
        showAuditMenuItem_Click(this, null);
      if (e.Button == clearEventLogToolBarButton)
        ClearEventMenuItem_Click(this, null);
      if (e.Button == gcToolBarButton)
        gcMenuItem_Click(this, null);
    }

    private void saveAsMenuItem_Click(object sender, EventArgs e) {
      if (saveLogFileDialog.ShowDialog(this) != DialogResult.OK)
        return;
      var file = File.CreateText(saveLogFileDialog.FileName);
      foreach (ListViewItem l in EventListView.Items) {
        file.Write(l.Tag.ToString());
        file.Write("\r\n\r\n-------------------------------------------------\r\n");
      }
      file.Close();
    }

    private void EventListView_SelectedIndexChanged(object sender, EventArgs e) {
      if (EventListView.SelectedItems.Count <= 0)
        return;
      EventText.Text = (string) EventListView.SelectedItems[0].Tag;
    }

    private void showExceptionsMenuItem_Click(object sender, EventArgs e) {
      showExceptionsMenuItem.Checked = !showExceptionsMenuItem.Checked;
      showExceptionsToolBarButton.Pushed = showExceptionsMenuItem.Checked;
      EventLogger.ShowAll = showAuditMenuItem.Checked || showInformationMenuItem.Checked ||
                            showExceptionsMenuItem.Checked || showExceptionsMenuItem.Checked;
    }

    private void showWarningsMenuItem_Click(object sender, EventArgs e) {
      showWarningsMenuItem.Checked = !showWarningsMenuItem.Checked;
      showWarningEventsToolBarButton.Pushed = showWarningsMenuItem.Checked;
      EventLogger.ShowAll = showAuditMenuItem.Checked || showInformationMenuItem.Checked ||
                            showExceptionsMenuItem.Checked || showExceptionsMenuItem.Checked;
    }

    private void showInformationMenuItem_Click(object sender, EventArgs e) {
      showInformationMenuItem.Checked = !showInformationMenuItem.Checked;
      showInformationEventsToolBarButton.Pushed = showInformationMenuItem.Checked;
      EventLogger.ShowAll = showAuditMenuItem.Checked || showInformationMenuItem.Checked ||
                            showExceptionsMenuItem.Checked || showExceptionsMenuItem.Checked;
    }

    private void showAuditMenuItem_Click(object sender, EventArgs e) {
      showAuditMenuItem.Checked = !showAuditMenuItem.Checked;
      showAuditEventsToolBarButton.Pushed = showAuditMenuItem.Checked;
      EventLogger.ShowAll = showAuditMenuItem.Checked || showInformationMenuItem.Checked ||
                            showExceptionsMenuItem.Checked || showExceptionsMenuItem.Checked;
    }

    public static void GenerateExceptionFile(string filename, string exception, string versionInfo) {
      try {
        var fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
        var s = new StringBuilder();
        if (fs.Length == 0) {
          s.Append("Please e-mail these exceptions to Ylian Saint-Hilaire, ylian.saint-hilaire@intel.com.")
           .Append("\r\n\r\n");
        }
        s.AppendFormat("********** {0}\r\n{1}\r\n\r\n", DateTime.Now, exception);
        s.Append(versionInfo).Append("\r\n");
        //s.Append(GetLastEvents(10)).Append("\r\n\r\n");
        var bytes = Encoding.UTF8.GetBytes(s.ToString());
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
        MessageBox.Show(
                        $"Exception error logged in: {fs.Name}\r\n\r\n{"Please e-mail these exceptions to Ylian Saint-Hilaire, ylian.saint-hilaire@intel.com."}",
                        @"Application Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
      } catch (Exception ex) {
        EventLogger.Log(ex);
      }
    }

    private void InstanceTracker_FormClosing(object sender, FormClosingEventArgs e) {
      EventLogger.OnEvent -= OnEventSink;
    }

    private void EventText_TextChanged(object sender, EventArgs e) {}

    public struct InstanceStruct {
      public string StackList;
      // ReSharper disable once InconsistentNaming
      public WeakReference WR;
    }

    private class InstanceTrackerSorter : IComparer {
      public int Compare(object x, object y) {
        var itemX = (ListViewItem) x;
        var itemY = (ListViewItem) y;

        return (string.Compare(itemX.SubItems[1].Text, itemY.SubItems[1].Text, StringComparison.Ordinal));
      }
    }
  }
}