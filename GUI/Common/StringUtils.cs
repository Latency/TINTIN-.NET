//  *****************************************************************************
//  File:      StringUtils.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      07/26/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System.Globalization;
using System.Text;

namespace TinTin.GUI.Common {
  /// <summary>
  ///   Utilities for manipulating strings.
  /// </summary>
  public static class StringUtils {
    /// <summary>
    ///   Converts a byte array to a string.
    /// </summary>
    /// <param name="buffer">The buffer to convert</param>
    /// <returns>converted buffer</returns>
    public static string ByteToString(byte[] buffer) {
      var str = new StringBuilder();

      foreach (var b in buffer)
        str.AppendFormat(CultureInfo.CurrentCulture, "{0:x2}", b);

      return str.ToString();
    }
  }
}