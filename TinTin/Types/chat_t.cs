//  *****************************************************************************
//  File:       chat_t.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace TinTin.Types {
  public class chat_t : typedef<Dictionary<string, string>> {
    // Default Constructor
    public chat_t() {
    }

    // Copy Constructor
    public chat_t(Dictionary<string, string> value) : base(value) {
    }

    // Properties
    public string name { get; set; }

    public Delegates.CHAT func { get; set; }

    public int lval { get; set; }

    public int rval { get; set; }

    public string desc { get; set; }
  }
}