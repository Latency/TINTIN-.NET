// *****************************************************************************
// File:      ListRoot.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.structs {
  public struct ListRoot {
    // ReSharper disable InconsistentNaming
    public int flags;
    public List<ListNode> list;
    public Session ses;
    public int size;

    public int type,
               update;

    public int used;
    // ReSharper restore InconsistentNaming
  }
}