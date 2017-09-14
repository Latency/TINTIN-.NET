//  *****************************************************************************
//  File:       StrHashData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using BitFields;

// ReSharper disable InconsistentNaming
namespace TinTin.Structs {
  public class StrHashData : LinkedList<StrHashData> {
    public uint     count;
    public ushort   hash,
                    lines;
    public BitField flags;
  }
}