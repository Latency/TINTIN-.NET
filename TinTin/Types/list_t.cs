//  *****************************************************************************
//  File:       list_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Types {
  // ReSharper disable once InconsistentNaming
  public class list_t : typedef<string> {
    // Default Constructor
    public list_t() {
    }

    // Copy Constructor
    public list_t(string value) : base(value) {
      Name = value;
    }

    // Properties
    public string Name { get; }

    public string name_multi { get; set; }

    public int mode { get; set; }

    public int args { get; set; }

    public int flags { get; set; }
  }
}