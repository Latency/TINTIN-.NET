using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


namespace TinTin {
  internal static class Extensions {
    /// <summary>
    /// 
    /// </summary>
    /// <param Name="str"></param>
    /// <returns></returns>
    public static bool IsColorCode(this string str) {
      // Instantiate the regular expression object.
      var r = new Regex("<>", RegexOptions.IgnoreCase);

      // Match the regular expression pattern against a text string.
      return r.Match(str).Success;
    }


    /// <summary>
    ///  Returns the Name of the enum.
    /// </summary>
    /// <typeparam Name="T"></typeparam>
    /// <param Name="enm"></param>
    /// <returns></returns>
    public static string Parse<T>(this T enm) where T : struct, IComparable, IFormattable, IConvertible {
      return Enum.GetName(typeof (T), enm);
    }


    /// <summary>
    ///  Returns the Name of the enum.
    /// </summary>
    /// <typeparam Name="T"></typeparam>
    /// <param Name="enm"></param>
    /// <param Name="value"></param>
    /// <returns></returns>
    public static T GetEnumFromString<T>(this T enm, string value) where T : struct, IComparable, IFormattable, IConvertible {
      if (!typeof(T).IsEnum) {
        throw new ArgumentException("T must be an enumerated type");
      }

      foreach (var item in Enum.GetValues(typeof(T)).Cast<T>().Where(item => item.ToString(CultureInfo.InvariantCulture).ToLower().Equals(value.Trim().ToLower())))
        return item;

      return default(T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param Name="value"></param>
    /// <param Name="type"></param>
    /// <returns></returns>
    public static bool IsParseableAs(this string value, Type type) {
      var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder, new[] {typeof (string), type.MakeByRefType()}, null);
      if (tryParseMethod == null)
        return false;
      var arguments = new[] {value, Activator.CreateInstance(type)};
      return (bool) tryParseMethod.Invoke(null, arguments);
    }
  }
}