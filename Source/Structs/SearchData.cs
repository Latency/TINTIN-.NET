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
  public class SearchData {
    public int       vnum,
                     exit_size;
    public short     stamp;
    public string    name,
                     exit_list,
                     desc,
                     area,
                     note,
                     terrain;
    public BitField  exit_dirs,
                     flag;
  }
}