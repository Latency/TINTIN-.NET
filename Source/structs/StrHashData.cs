// *****************************************************************************
// File:      StrHashData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

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