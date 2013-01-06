#include "tintin.h"

namespace TinTin {
  DO_COMMAND(do_function) {
    char arg1[BUFFER_SIZE], arg2[BUFFER_SIZE];

     arg = sub_arg_in_braces(ses, arg, arg1, 0, SUB_VAR | SUB_FUN);
     arg = get_arg_in_braces(ses, arg, arg2, 1);

    if (*arg1 == 0) {
      show_list(ses->list[LIST_FUNCTION], 0);
    }

    else if (*arg1 && *arg2 == 0) {
      if (show_node_with_wild(ses, arg1, LIST_FUNCTION) == FALSE) {
        show_message(ses, LIST_FUNCTION, "#FUNCTION: NO MATCH(ES) FOUND FOR {%s}.", arg1);
      }
    } else {
      update_node_list(ses->list[LIST_FUNCTION], arg1, arg2, "");

      show_message(ses, LIST_FUNCTION, "#OK. FUNCTION {%s} HAS BEEN SET TO {%s}.", arg1, arg2);
    }
    return ses;
  }

  DO_COMMAND(do_unfunction) {
    delete_node_with_wild(ses, LIST_FUNCTION, arg);

    return ses;
  }
}
