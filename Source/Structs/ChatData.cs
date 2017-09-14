//  *****************************************************************************
//  File:       ChatData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using BitFields;

namespace TinTin.Structs {
  public class ChatData : LinkedList<ChatData> {
    public string  name,
                   file_name,
                   ip,
                   version,
                   download,
                   reply,
                   prefix,
                   paste_buf,
                   color,
                   group;
    public int     port,
                   fd,
                   file_block_cnt,
                   file_block_tot,
                   file_block_patch;
    public BitField flags;
    public TimeSpan timeout,
                    paste_time,
                    file_start_time;
    public FileStream file_pt;
  }
}