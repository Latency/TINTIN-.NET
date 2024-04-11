//  *****************************************************************************
//  File:       Write.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System.IO;

namespace TinTin.Commands {
  // %LOCALAPPDATA%\Local\VirtualStore\Program Files\Wintin++
  internal sealed partial class Switchboard {
    public void Write(string s) {
      // Delete the file if it exists. 
      if (File.Exists(s))
        File.Delete(s);

      //try {
      //  using (var fs = File.CreateText(arg)) {


      //    for (uint i = 0; i < LIST_MAX; i++) {
      //      root = ses->list[i];

      //      if (!HAS_BIT(root->flags, LIST_FLAG_WRITE))
      //        continue;

      //      for (uint j = 0; j < root->used; j++) {
      //        if (*root->list[j]->group != 0)
      //          continue;
      //        write_node(ses, i, root->list[j], fs);

      //        cnt++;
      //      }
      //    }
      //  }
      //  show_message(ses, LIST_MESSAGE, "#WRITE: %d COMMAND%s WRITTEN TO {%s}.", cnt, (cnt == 1 ? "" : "S"), filename);
      //} catch {
      //  tintin_printf(ses, "#ERROR: #WRITE: COULDN'T OPEN {%s} TO WRITE.", filename);
      //}
    }
  }
}