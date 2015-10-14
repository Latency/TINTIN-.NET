// *****************************************************************************
// File:      ListNode.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Text.RegularExpressions;

namespace TinTin.structs {
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