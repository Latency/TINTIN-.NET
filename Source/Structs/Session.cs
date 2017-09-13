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
using System.IO.Compression;
using System.Net.Security;
using System.Text.RegularExpressions;
using BitFields;

namespace TinTin.Structs {
  public class Session : LinkedList<Session> {
    Regex                regex;
    MapData              map;
    DeflateStream        mccp;
    LinkedList<PortData> port;
    string[] buffer;
    string   name,
             priority,
             group,
             session_host,
             session_ip,
             session_port,
             cmd_color,
             read_buf,
             more_output,
             color;
    FileStream   logfile,
                 logline;
    int      rows,
             cols,
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
             size,
             used,
             type,
             update,
             auto_tab;
    SslStream  ssl;
    long     connect_retry,
             check_output;
    BitField telopts,
             flags,
             data;
    BitField[] telopts_flag;
  }
}