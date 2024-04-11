//  *****************************************************************************
//  File:       class_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class class_t : typedef<KeyValuePair<string, Delegates.CLASS>> {
    // Default Constructor
    public class_t() {
    }

    // Copy Constructor
    public class_t(KeyValuePair<string, Delegates.CLASS> kvp) : base(kvp) {
      Name = kvp.Key;
      Func = kvp.Value;
    }

    // Properties
    public string Name { get; set; }

    public Delegates.CLASS Func { get; set; }
  }
}