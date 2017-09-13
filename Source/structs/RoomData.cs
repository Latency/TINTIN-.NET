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

namespace TinTin.Structs {
  public struct RoomData {
    LinkedList<ExitData>    exit_list;
    string                  color,
                            name,
                            symbol,
                            desc,
                            area,
                            note,
                            terrain,
                            data;
    short                   search_stamp,
                            display_stamp;
    BitField                flags,
                            exit_dirs;
    float                   length,
                            weight;
    int                     vnum,
                            exit_size;
  }
}