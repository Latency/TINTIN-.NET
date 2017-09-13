﻿//  *****************************************************************************
//  File:       PortData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using BitFields;

// ReSharper disable ArrangeTypeMemberModifiers
namespace TinTin.Structs {
  public struct PortData {
    string   name,
             ip,
             prefix,
             color,
             group;
    int      port,
             fd;
    BitField flags;
  }
}