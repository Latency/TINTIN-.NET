//  *****************************************************************************
//  File:       TerminalData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Structs {
  public struct TerminalData {
    int bot_row,
        cols,
        cur_col,
        cur_row,
        rows,
        sav_col,
        sav_row,
        scroll_base,
        scroll_line,
        scroll_max,
        scroll_row,
        top_row;
  }
}