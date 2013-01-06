#include "tintin.h"

DO_COMMAND(do_action) {
  char arg1[BUFFER_SIZE], arg2[BUFFER_SIZE], arg3[BUFFER_SIZE];

  arg = sub_arg_in_braces(ses, arg, arg1, 0, SUB_VAR | SUB_FUN);
  arg = get_arg_in_braces(ses, arg, arg2, 1);
  arg = get_arg_in_braces(ses, arg, arg3, 1);

  if (*arg3 == 0) {
    strcpy(arg3, "5");
  }

  if (*arg1 == 0) {
    show_list(ses->list[LIST_ACTION], 0);
  } else if (*arg1 && *arg2 == 0) {
    if (show_node_with_wild(ses, arg1, LIST_ACTION) == FALSE) {
      show_message(ses, LIST_ACTION, "#ACTION: NO MATCH(ES) FOUND FOR {%s}.", arg1);
    }
  } else {
    update_node_list(ses->list[LIST_ACTION], arg1, arg2, arg3);

    show_message(ses, LIST_ACTION, "#OK. {%s} NOW TRIGGERS {%s} @ {%s}.", arg1, arg2, arg3);
  }
  return ses;
}

DO_COMMAND(do_unaction) {
  delete_node_with_wild(ses, LIST_ACTION, arg);

  return ses;
}

void check_all_actions(struct session *ses, char *original, char *line) {
  struct listroot *root = ses->list[LIST_ACTION];
  char buf[BUFFER_SIZE];

  for (root->update = 0; root->update < root->used; root->update++) {
    if (check_one_regexp(ses, root->list[root->update], line, original, 0)) {
      show_debug(ses, LIST_ACTION, "#DEBUG ACTION {%s}", root->list[root->update]->left);

      substitute(ses, root->list[root->update]->right, buf, SUB_ARG | SUB_SEC);

      script_driver(ses, LIST_ACTION, buf);

      return;
    }
  }
}
