//  *****************************************************************************
//  File:       Gag.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

namespace TinTin.Commands {
  /// <summary>
  /// </summary>
  public partial class Switchboard {
    public void Gag(string s) {
      //string arg1,
      //       cmd = MethodBase.GetCurrentMethod().Name.ToLower();
      //arg = sub_arg_in_braces(_session, arg, out arg1, 1, SUB_VAR | SUB_FUN);

      //if (arg1.Length == 0)
      //  show_list(_session->list[cmd], 0);
      //else {
      //  update_node_list(_session->list[cmd], arg1, "", "");
      //  show_message(_session, cmd, "#OK. {%s} IS NOW GAGGED.", arg1);
      //}
    }
  }
}

/*

void check_all_gags(struct session *ses, char *original, char *line) {
  listroot *root = ses->list[LIST_GAG];

  for (root->update = 0; root->update < root->used; root->update++) {
    if (check_one_regexp(ses, root->list[root->update], line, original, 0)) {
      SET_BIT(ses->flags, SES_FLAG_GAG);
      break;
    }
  }
}
*/