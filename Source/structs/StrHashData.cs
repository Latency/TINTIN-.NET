//  *****************************************************************************
//  File:       StrHashData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Structs {
  public class StrHashData {
    public StrHashData() {
      node = new LinkedListNode<StrHashData>(this);
    }

    // ReSharper disable InconsistentNaming

    public StrHashData next => node.Next?.Value;
    public StrHashData prev => node.Previous?.Value;

    private readonly LinkedListNode<StrHashData> node;

    public uint count;

    public ushort flags,
                  hash,
                  lines;

    // ReSharper restore InconsistentNaming
  }
}