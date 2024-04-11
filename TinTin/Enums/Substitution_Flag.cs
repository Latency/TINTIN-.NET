//  *****************************************************************************
//  File:       Substitution_Flag.cs
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
  // ReSharper disable InconsistentNaming
  public enum Substitution_Flag {
    None,

    [Description("Argument")]
    Arg,

    [Description("Variable")]
    Var,

    [Description("Function")]
    Fun,

    [Description("Select Graphic Rendition")]
    SGR,

    [Description("Escape")]
    Esc,

    [Description("Command")]
    Cmd,

    [Description("Section")]
    Sec,

    [Description("End of Line")]
    Eol,

    [Description("Line Feed")]
    Lnf,

    [Description("Fixed")]
    Fix,

    [Description("Compare")]
    Cmp
  }
  // ReSharper restore InconsistentNaming
}