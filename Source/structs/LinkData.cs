//  *****************************************************************************
//  File:       LinkData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

// ReSharper disable ArrangeTypeMemberModifiers

using System.Collections.Generic;

namespace TinTin.Structs {
  public class LinkData : LinkedList<LinkData> {
    string str1,
           str2,
           str3;
  }
}