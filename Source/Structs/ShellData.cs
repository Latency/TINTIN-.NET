// *****************************************************************************
// File:      ShellData.cs
// Solution:  TinTin.NET
// Date:      10/19/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Structs {
  public struct ShellData {
    public List<string> Paths,
                        Files;
    public bool GUI,
                Verbosity;
  }
}