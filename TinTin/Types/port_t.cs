//  *****************************************************************************
//  File:       port_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class port_t : typedef<KeyValuePair<string, Delegates.PORT>> {
    // Default Constructor
    public port_t() {
    }

    // Copy Constructor
    public port_t(KeyValuePair<string, Delegates.PORT> kvp) : base(kvp) {
      Name = kvp.Key;
      Port = kvp.Value;
    }

    // Properties
    public string Name { get; }

    public Delegates.PORT Port { get; }

    public int lval { get; set; }

    public int rval { get; set; }

    public string desc { get; set; }
  }
}