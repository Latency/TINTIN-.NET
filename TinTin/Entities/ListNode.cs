//  *****************************************************************************
//  File:       ListNode.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using BitFields;
using System.Text.RegularExpressions;

// ReSharper disable InconsistentNaming
namespace TinTin.Entities {
  public class ListNode {
    public long     data;
    public BitField flags;
    public string   group,
                    pr;
    public Regex    regex;
  }
}