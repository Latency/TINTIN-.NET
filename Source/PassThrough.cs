// *****************************************************************************
// File:      PassThrough.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin {
  public abstract class PassThrough {
    protected abstract void HandleImpl(int id, object[] data);
    protected abstract string GetMethodName(int id);

    protected void Invoke(object[] data) {
      Console.WriteLine(@"Pass through from {0}", GetMethodName((int) data[0]));
      HandleImpl((int) data[0], data);
    }
  }
}