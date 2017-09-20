//  *****************************************************************************
//  File:       Extensions.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TinTin {
  internal static class Extensions {
    /// <summary>
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsColorCode(this string str) {
      // Instantiate the regular expression object.
      var r = new Regex("<>", RegexOptions.IgnoreCase);

      // Match the regular expression pattern against a text string.
      return r.Match(str).Success;
    }

    /// <summary>
    ///   Returns the Name of the enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enm"></param>
    /// <returns></returns>
    public static string Parse<T>(this T enm) where T : struct, IComparable, IFormattable, IConvertible {
      return Enum.GetName(typeof(T), enm);
    }

    /// <summary>
    ///   Returns the Name of the enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enm"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T GetEnumFromString<T>(this T enm, string value) where T : struct, IComparable, IFormattable, IConvertible {
      if (!typeof(T).IsEnum)
        throw new ArgumentException("T must be an enumerated type");

      foreach (var item in Enum.GetValues(typeof(T)).Cast<T>().Where(item => item.ToString(CultureInfo.InvariantCulture).ToLower().Equals(value.Trim().ToLower())))
        return item;

      return default(T);
    }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsParseableAs(this string value, Type type) {
      var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder, new[] {
        typeof(string),
        type.MakeByRefType()
      }, null);
      if (tryParseMethod == null)
        return false;
      var arguments = new[] {
        value,
        Activator.CreateInstance(type)
      };
      return (bool) tryParseMethod.Invoke(null, arguments);
    }


    /* enum ConsoleColor {
     *   Black
     *   DarkBlue
     *   DarkGreen
     *   DarkCyan
     *   DarkRed
     *   DarkMagenta
     *   DarkYellow
     *   Gray
     *   DarkGray
     *   Blue
     *   Green
     *   Cyan
     *   Red
     *   Magenta
     *   Yellow
     *   White
     * }
     */
    public static int ParseColor(this string str, out string temp) {
      // Main buffer.
      temp = string.Empty;
      // Used for &+ &-
      bool verbatim = false, isColor = false;
      // Common variable
      var x = 0;

      while (str[x] != '\0') {
        if (str[x] == '\\') { // Toggle verbatim mode
          verbatim = !verbatim;
          if (str[++x] == '\\') {
            verbatim = !verbatim;
            temp += str[x];
          } else
            x--;
        } else if (!verbatim && str[x] == '&') {
          switch (str[++x]) {
            case '+':
            case '-':
            case '=':
              ushort bit;
              switch (str[x]) {
                case '+':
                  bit = 2;
                  break;
                case '-':
                  bit = 1;
                  break;
                default:
                  bit = 0;
                  break;
              }
              var idx = str.IndexOfAny("01234567".ToCharArray(), ++x, 1);
              if (idx != -1) {
                temp += "\\e[";
                temp += bit == 2 ? "3" : (bit == 1 ? "4" : string.Empty);
                temp += str[idx];
                temp += 'm';
                isColor = true;
              } else {
                x -= 2;
                temp += str[x];
              }
              break;

            case '~':
              var nibble = str.Substring(++x, 3);
              ushort y;
              if (!CSTypes.Types.IsNumber(nibble) || (y = Convert.ToUInt16(nibble)) > char.MaxValue) {
                x -= 2;
                temp += str[x];
              } else {
                temp += Convert.ToChar(y);
                x += 2;
              }
              break;

            default:
              temp += str[--x];
              break;
          }
        } else if (isColor && str[x].ToString().Equals(Environment.NewLine)) {
          verbatim = false;
          isColor = false;
          temp += "[0m" + Environment.NewLine;
        } else
          temp += str[x];
        x++;
      }
      return temp.Length;
    }
  }
}