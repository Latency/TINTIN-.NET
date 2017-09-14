﻿//  *****************************************************************************
//  File:       ListNode.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Text.RegularExpressions;
using BitFields;

// ReSharper disable InconsistentNaming
namespace TinTin.Structs {
  public class ListNode {
    public long     data;
    public BitField flags;
    public string   group,
                    pr;
    public Regex    regex;
  }
}