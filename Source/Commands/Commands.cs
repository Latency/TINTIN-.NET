//  *****************************************************************************
//  File:       Commands.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinTin.Commands {
  internal sealed partial class Switchboard {
    public void Commands(string s) {
      var sb = new StringBuilder();
      sb.AppendLine("Command Listings");
      sb.AppendLine("----------------------------");
      // Query for ascending sort.
      IEnumerable<string> sortAscendingQuery = from name in CMD.Keys
        orderby name //"ascending" is default
        select name;

      foreach (var cmd in sortAscendingQuery)
        sb.AppendLine("\t" + cmd);

      Program.Print(sb.ToString());
    }
  }
}