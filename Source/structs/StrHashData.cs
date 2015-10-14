// *****************************************************************************
// File:      StrHashData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.structs {
  public class StrHashData {
    public StrHashData() {
      node = new LinkedListNode<StrHashData>(this);
    }

    public StrHashData next { get { return (node.Next != null ? node.Next.Value : null); } }

    public StrHashData prev { get { return (node.Previous != null ? node.Previous.Value : null); } }

    // ReSharper disable InconsistentNaming
    private readonly LinkedListNode<StrHashData> node;

    public uint count;

    public ushort flags;
    public ushort hash;
    public ushort lines;

    // ReSharper restore InconsistentNaming
  }
}