//  *****************************************************************************
//  File:       ExitData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Structs {
  public class ExitData {
    public ExitData() {
      node = new LinkedListNode<ExitData>(this);
    }

    // ReSharper disable InconsistentNaming

    public ExitData next => node.Next?.Value;
    public ExitData prev => node.Previous?.Value;

    private readonly LinkedListNode<ExitData> node;
    public string cmd,
                  data,
                  name;
    public int    dir,
                  flags,
                  vnum;
  }
}