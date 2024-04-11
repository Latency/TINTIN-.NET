//  *****************************************************************************
//  File:       LinkData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Entities {
  public class LinkData : LinkedList<LinkData> {
    public string  str1,
                   str2,
                   str3;
  }
}