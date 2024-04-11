//  *****************************************************************************
//  File:       RoomData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using BitFields;

// ReSharper disable InconsistentNaming
namespace TinTin.Entities {
  public struct RoomData {
    public LinkedList<ExitData>     exit_list;
    public string                   color,
                                    name,
                                    symbol,
                                    desc,
                                    area,
                                    note,
                                    terrain,
                                    data;
    public short                    search_stamp,
                                    display_stamp;
    public BitField                 flags,
                                    exit_dirs;
    public float                    weight;
    public int                      length,
                                    vnum,
                                    exit_size;
  }
}