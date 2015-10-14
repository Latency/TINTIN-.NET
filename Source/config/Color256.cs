// ****************************************************************************
// *                                TinTin#                                   *
// *                                                                          *
// *                        written by peter unold 1992                       *
// *                        modified by Bill Reiss 1993                       *
// *                    converted by Latency McLaughlin 1999                  * 
// *                     updated by Igor van den Hoven 2004                   *
// *                    re-written by Latency McLaughlin 2013                 *
// ****************************************************************************

namespace TinTin.config {
  partial class Configuration {
    DO_CONFIG(config_256color ) {
      if (!strcasecmp(arg, "AUTO")) {
        if (!strcasecmp(gtd->term, "xterm") || strstr(gtd->term, "256color") || strstr(gtd->term, "256COLOR"))
          SET_BIT(ses->flags, SES_FLAG_256COLOR);
        else DEL_BIT(ses->flags, SES_FLAG_256COLOR);
      } else if (!strcasecmp(arg, "ON")) SET_BIT(ses->flags, SES_FLAG_256COLOR);
      else if (!strcasecmp(arg, "OFF")) DEL_BIT(ses->flags, SES_FLAG_256COLOR);
      else {
        tintin_printf(ses, "#SYNTAX: #CONFIG {%s} <AUTO|ON|OFF>", config_table[index].name);
        return NULL;
      }
      update_node_list(ses->list[LIST_CONFIG], config_table[index].name, HAS_BIT(ses->flags, SES_FLAG_256COLOR) ? "ON" : "OFF", "");

      return ses;
    }
  }
}