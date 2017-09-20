//  *****************************************************************************
//  File:       ExitData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Entities {
  public class ExitData : LinkedList<ExitData> {
    public string cmd,
                  data,
                  name;
    public int    dir,
                  flags,
                  vnum;
  }
}