// *****************************************************************************
// File:      TerminalData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.structs {
  public struct TerminalData {
    // ReSharper disable InconsistentNaming
    public int bot_row;
    public int cols;
    public int cur_col;
    public int cur_row;
    public int rows;
    public int sav_col;
    public int sav_row;
    public int scroll_base;
    public int scroll_line;

    public int scroll_max,
               scroll_row;

    public int top_row;
    // ReSharper restore InconsistentNaming
  }
}