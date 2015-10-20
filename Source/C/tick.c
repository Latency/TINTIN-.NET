#include "tintin.h"

DO_COMMAND(do_tick) {
  char arg1[BUFFER_SIZE], arg2[BUFFER_SIZE], arg3[BUFFER_SIZE];

  arg = sub_arg_in_braces(ses, arg, arg1, 0, SUB_VAR | SUB_FUN);
  arg = get_arg_in_braces(ses, arg, arg2, 1);
  arg = get_arg_in_braces(ses, arg, arg3, 1);

  if (*arg3 == 0) {
    strcpy(arg3, "60");
  } else {
    get_number_string(ses, arg3, arg3);
  }

  if (*arg1 == 0) {
    show_list(ses->list[LIST_TICKER], 0);
  } else if (*arg1 && *arg2 == 0) {
    if (show_node_with_wild(ses, arg1, LIST_TICKER) == FALSE) {
      show_message(ses, LIST_TICKER, "#TICK, NO MATCH(ES) FOUND FOR {%s}.", arg1);
    }
  } else {
    update_node_list(ses->list[LIST_TICKER], arg1, arg2, arg3);

    show_message(ses, LIST_TICKER, "#OK {%s} NOW EXECUTES {%s} EVERY {%s} SECONDS.", arg1, arg2, arg3);
  }
  return ses;
}

DO_COMMAND(do_untick) {
  delete_node_with_wild(ses, LIST_TICKER, arg);

  return ses;
}

DO_COMMAND(do_delay) {
  char arg1[BUFFER_SIZE], arg2[BUFFER_SIZE], arg3[BUFFER_SIZE], temp[BUFFER_SIZE];

  arg = sub_arg_in_braces(ses, arg, arg1, GET_ONE, SUB_VAR | SUB_FUN);
  arg = get_arg_in_braces(ses, arg, arg2, 1);
  arg = sub_arg_in_braces(ses, arg, arg3, GET_ALL, SUB_VAR | SUB_FUN);

  if (*arg1 == 0) {
    show_list(ses->list[LIST_DELAY], 0);
  } else if (*arg2 == 0) {
    if (show_node_with_wild(ses, arg1, LIST_DELAY) == FALSE) {
      show_message(ses, LIST_DELAY, "#DELAY: NO MATCH(ES) FOUND FOR {%s}.", arg1);
    }
  } else {
    if (*arg3 == 0) {
      sprintf(arg3, "%lld", utime());

      get_number_string(ses, arg1, temp);

      update_node_list(ses->list[LIST_DELAY], arg3, arg2, temp);

      show_message(ses, LIST_TICKER, "#OK, IN {%s} SECONDS {%s} IS EXECUTED.", temp, arg2);
    } else {
      get_number_string(ses, arg3, temp);

      update_node_list(ses->list[LIST_DELAY], arg1, arg2, temp);

      show_message(ses, LIST_TICKER, "#OK, IN {%s} SECONDS {%s} IS EXECUTED.", temp, arg2);
    }
  }
  return ses;
}

DO_COMMAND(do_undelay) {
  delete_node_with_wild(ses, LIST_DELAY, arg);

  return ses;
}
