//  *****************************************************************************
//  File:       ListRoot.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Structs {
  public struct ListRoot {
    // ReSharper disable InconsistentNaming
    public List<ListNode> list;

    public Session ses;

    public int flags, size, type, update, used;
    // ReSharper restore InconsistentNaming
  }
}