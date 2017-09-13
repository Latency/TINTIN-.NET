//  *****************************************************************************
//  File:       ListNode.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Text.RegularExpressions;

namespace TinTin.Structs {
  public struct ListNode {
    // ReSharper disable InconsistentNaming
    public long data;

    public short flags;
    public string group;
    public string pr;

    public Regex regex;
    // ReSharper restore InconsistentNaming
  }
}