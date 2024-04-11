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

namespace TinTin.Entities {
  public class MapData {
    public List<RoomData>    room_list,
                             grid;
    public FileStream        logfile;
    public LinkData          undo_head,
                             undo_tail;
    public SearchData        search;
    public string            exit_color,
                             here_color,
                             path_color,
                             room_color,
                             back_color;
    public int               max_grid_x,
                             max_grid_y,
                             undo_size,
                             size,
                             flags,
                             in_room,
                             at_room,
                             last_room;
    public short             display_stamp,
                             nofollow;
    public List<string>      legend;
  }
}