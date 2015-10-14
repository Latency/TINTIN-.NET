// ****************************************************************************
// *                                TinTin#                                   *
// *                                                                          *
// *                        written by peter unold 1992                       *
// *                        modified by Bill Reiss 1993                       *
// *                    converted by Latency McLaughlin 1999                  * 
// *                     updated by Igor van den Hoven 2004                   *
// *                    re-written by Latency McLaughlin 2013                 *
// ****************************************************************************

using System;
using System.IO;
using TinTin.types;

namespace TinTin.commands {
  // %LOCALAPPDATA%\Local\VirtualStore\Program Files\Wintin++
  public partial class Switchboard {
    public void Write(string arg) {
      // Delete the file if it exists. 
      if (File.Exists(arg))
        File.Delete(arg);

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