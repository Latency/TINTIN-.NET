// *****************************************************************************
// File:      Commands.cs
// Solution:  TinTin.NET
// Date:      10/19/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinTin.Commands {
  public partial class Switchboard {
    public void Commands(string s) {
      var sb = new StringBuilder();
      sb.AppendLine("Command Listings");
      sb.AppendLine("----------------------------");
      // Query for ascending sort.
      IEnumerable<string> sortAscendingQuery =
          from name in CMD.Keys
          orderby name //"ascending" is default
          select name;

      foreach (var cmd in sortAscendingQuery) {
        sb.AppendLine("\t" + cmd);
      }

      Program.Print(sb.ToString());
    }
  }
}