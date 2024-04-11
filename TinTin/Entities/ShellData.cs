//  *****************************************************************************
//  File:       ShellData.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;

namespace TinTin.Entities {
  public class ShellData {
    public List<string>  Paths,
                         Files;
    public bool          GUI,
                         Verbosity;


    /// <summary>
    ///  Constructor
    /// </summary>
    public ShellData() {
      Paths = new List<string>();
      Files = new List<string>();
    }
  }
}