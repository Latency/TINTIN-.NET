//  *****************************************************************************
//  File:       Chat_Flag.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.ComponentModel;

namespace TinTin.Enums {
  // BitVector
  [Flags]
  // ReSharper disable once InconsistentNaming
  public enum Chat_Flag {
    Private = 1,
    Request,
    Serve,
    Ignore,
    Forward,
    [Description("Forward By")]
    ForwardBy,
    [Description("Forward All")]
    ForwardAll,
    [Description("Do Not Do")]
    DoNotDo,
    [Description("Link Lost")]
    LinkLost
  }
}