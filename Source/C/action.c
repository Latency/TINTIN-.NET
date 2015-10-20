#include "tintin.h"



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
