//  *****************************************************************************
//  File:       SearchData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using BitFields;

namespace TinTin.Structs {
  public struct SearchData {
    int      vnum,
             exit_size;
    short    stamp;
    string   name,
             exit_list,
             desc,
             area,
             note,
             terrain;
    BitField exit_dirs,
             flag;
  }
}