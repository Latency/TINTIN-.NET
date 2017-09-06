using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTin.src {
  class show_message {
    
    void show_message(int index, char *format, ...) {
      struct listroot *root;
      char buf[STRING_SIZE];
      va_list args;

      push_call("show_message(%p,%p,%p)", ses, index, format);

      va_start(args, format);

      vsprintf(buf, format, args);

      va_end(args);

      if (HAS_BIT(ses->flags, SES_FLAG_VERBOSELINE)) {
        tintin_puts2(ses, buf);

        pop_call();
        return;
      }

      if (index == -1) {
        if (ses->input_level == 0) {
          tintin_puts2(ses, buf);
        }
        pop_call();
        return;
      }

      root = ses->list[index];

      if (HAS_BIT(root->flags, LIST_FLAG_DEBUG)) {
        tintin_puts2(ses, buf);

        pop_call();
        return;
      }

      if (HAS_BIT(root->flags, LIST_FLAG_MESSAGE)) {
        if (ses->input_level == 0) {
          tintin_puts2(ses, buf);

          pop_call();
          return;
        }
      }

      if (HAS_BIT(root->flags, LIST_FLAG_LOG)) {
        if (ses->logfile) {
          logit(ses, buf, ses->logfile, TRUE);
        }
      }
      pop_call();
      return;
    }
  }
}
