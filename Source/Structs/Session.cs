//  *****************************************************************************
//  File:       Session.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using BitFields;

namespace TinTin.Structs {
  public struct Session {
    private struct listroot {
      listnode list[];
      Session  session;
      int      size,
               used,
               type,
               update;
      BitField flags;
    }

    private struct listnode {
      LinkedList<listroot> root;
      string               priority,
                           group;
      Regex                regex;
      BitField             data,
                           flags;
    }


    MapData map;
    LinkedList<PortData> port;
    LinkedList<>
    string[] buffer;
    string   name,
             group,
             session_host,
             session_ip,
             session_port,
             cmd_color,
             read_buf,
             more_output,
             color;
    Stream   logfile,
             logline;
    int      rows,
             colos,
             top_row,
             bot_row,
             cur_row,
             sav_row,
             cur_col,
             sav_col,
             scroll_max,
             scroll_row,
             scroll_line,
             scroll_base,
             fgc,
             bgc,
             vtc,
             socket,
             read_len,
             read_max,
             connect_error,
             auto_tab;
    long long connect_retry,
              check_output;
    BitField telopts,
             telopts_flag[],
             flags;
  }
}