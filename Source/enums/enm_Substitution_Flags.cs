// *****************************************************************************
// File:      enm_Substitution_Flags.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.ComponentModel;

namespace TinTin.enums {
  // BitVector
  [Flags]
  // ReSharper disable InconsistentNaming
  public enum Substitution_Flags {
    None,
    [Description("Argument")]                 Arg,
    [Description("Variable")]                 Var,
    [Description("Function")]                 Fun,
    [Description("Select Graphic Rendition")] SGR,
    [Description("Escape")]                   Esc,
    [Description("Command")]                  Cmd,
    [Description("Section")]                  Sec,
    [Description("End of Line")]              Eol,
    [Description("Line Feed")]                Lnf,
    [Description("Fixed")]                    Fix,
    [Description("Compare")]                  Cmp
  }
  // ReSharper restore InconsistentNaming
}