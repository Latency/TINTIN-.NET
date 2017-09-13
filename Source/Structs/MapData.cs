//  *****************************************************************************
//  File:       MapData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using System.IO;

namespace TinTin.Structs {
  public struct MapData {
    List<RoomData> room_list,
                   grid;
    Stream         logfile;
    LinkData       undo_head,
                   undo_tail;
    SearchData     search;
    string         exit_color,
                   here_color,
                   path_color,
                   room_color,
                   back_color;
    int            max_grid_x,
                   max_grid_y,
                   undo_size,
                   size,
                   flags,
                   in_room,
                   at_room,
                   last_room;
    short          display_stamp,
                   nofollow;
    string         legend[];
  }
}