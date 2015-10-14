// *****************************************************************************
// File:      ExitData.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

namespace TinTin.structs {
  public struct ExitData {
    // ReSharper disable InconsistentNaming
    public string cmd,
                  data;

    public int dir,
               flags;

    public string name;
    public int vnum;
    // ReSharper restore InconsistentNaming
  }
}