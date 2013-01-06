using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTin {
  using method_t = System.Void;

  /// <summary>
  /// 
  /// </summary>
  public partial class Functions
  {
    private delegate method_t MethodDelegate();
    private Dictionary<string, MethodDelegate> _jumpTable;


    // Constructor
    Functions() {
      _jumpTable = new Dictionary<string, MethodDelegate>() {
        {"action", Action},
        {"gag", Gag}
      };
    }
  }

  public partial class Functions {
  }
}
