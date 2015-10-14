// *****************************************************************************
// File:      Typedef.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;

namespace TinTin {
  // ReSharper disable InconsistentNaming
  public class typedef<T> {
    protected T MValue;
    private readonly int _hashCode;

    public virtual T Value {
      get { return MValue; }
      set { MValue = value; }
    }

    #region Constructors/Destructor
    // -----------------------------------------------------------------------

    // Default Constructor
    public typedef() : this(default(T)) { }

    // Copy Constructor
    public typedef(T value) {
      MValue = value;
      _hashCode = MValue.GetHashCode();
    }

    // -----------------------------------------------------------------------
    #endregion Constructors/Destructor

    #region Type Comparison Methods
    // -----------------------------------------------------------------------

    private static bool IsNumeric(object value) {
      return ((value is sbyte) || (value is byte) || (value is short) || (value is ushort) || (value is int) || (value is uint) || (value is long) || (value is ulong) || (value is float) || (value is double) ||
              (value is decimal));
    }

    private static bool IsInteger(object value) {
      return ((value is sbyte) || (value is byte) || (value is short) || (value is ushort) || (value is int) || (value is uint) || (value is long) || (value is ulong));
    }

    private static bool IsFloatingPoint(object value) {
      return ((value is float) || (value is double) || (value is decimal));
    }

    private static decimal GetNumeric(object value) {
      if (value == null)
        throw new NullReferenceException("typedef.GetNumeric");
      if (!IsNumeric(value))
        throw new InvalidOperationException();
      var changeType = Convert.ChangeType(value, TypeCode.Decimal);
      if (changeType != null)
        return (decimal) changeType;
      throw new NullReferenceException("typedef.GetNumeric");
    }

    private static long GetInteger(object value) {
      if (value == null)
        throw new NullReferenceException("typedef.GetInteger");
      if (!IsInteger(value))
        throw new InvalidOperationException();
      var changeType = Convert.ChangeType(value, TypeCode.Int64);
      if (changeType != null)
        return (long) changeType;
      throw new NullReferenceException("typedef.GetInteger");
    }

    private static decimal GetFloatingPoint(object value) {
      if (value == null)
        throw new NullReferenceException("typedef.GetFloatingPoint");
      if (!IsFloatingPoint(value))
        throw new InvalidOperationException();
      var changeType = Convert.ChangeType(value, TypeCode.Decimal);
      if (changeType != null)
        return (decimal) changeType;
      throw new NullReferenceException("typedef.GetFloatingPoint");
    }

    // -----------------------------------------------------------------------
    #endregion Type Comparison Methods

    #region Override Methods
    // -----------------------------------------------------------------------

    public override bool Equals(object obj) {
      if (obj == null)
        return false;
      return ReferenceEquals(MValue.GetType(), obj.GetType()) && MValue.Equals(obj);
    }

    public override int GetHashCode() {
      return _hashCode;
    }

    public override string ToString() {
      return MValue.ToString();
    }

    // -----------------------------------------------------------------------
    #endregion Override Methods

    #region Convertional Operators
    // -----------------------------------------------------------------------

    public static implicit operator typedef<T>(T value) {
      return new typedef<T>(value);
    }

    public static explicit operator T(typedef<T> value) {
      return value.Value;
    }

    // -----------------------------------------------------------------------
    #endregion Convertional Operators

    #region Unary Operators  { +, -, !, ~, ++, --, true, false }
    // -----------------------------------------------------------------------

    public static T operator +(typedef<T> operand) {
      var temp = operand.MValue;
      return IsInteger(temp) ? (T) (object) (+GetInteger(temp)) : (IsFloatingPoint(temp) ? (T) (object) (+GetFloatingPoint(temp)) : temp);
    }

    public static T operator -(typedef<T> operand) {
      var temp = operand.MValue;
      return IsInteger(temp) ? (T) (object) (-GetInteger(temp)) : (IsFloatingPoint(temp) ? (T) (object) (-GetFloatingPoint(temp)) : temp);
    }

    public static T operator !(typedef<T> operand) {
      var temp = operand.MValue;
      if (temp is bool) {
        var changeType = Convert.ChangeType(temp, TypeCode.Boolean);
        if (changeType != null)
          return (T) (object) (((bool) changeType) == false);
        throw new NullReferenceException("typedef.operator(!)");
      }
      if (IsNumeric(temp)) {
        var changeType = Convert.ChangeType(temp, TypeCode.Decimal);
        if (changeType == null)
          throw new NullReferenceException("typedef.operator(!)");
        var val = (decimal) changeType;
        return (T) (object) ((val != 0) ? 0 : val);
      }
      try {
        var isNull = ReferenceEquals((temp), null);
        return (isNull ? ((T) (object) null) : temp);
      } catch (Exception) {
        throw new InvalidOperationException();
      }
    }

    public static T operator ~(typedef<T> operand) {
      var temp = operand.MValue;
      return IsInteger(temp) ? (T) (object) (~GetInteger(temp)) : temp;
    }

    public static bool operator true(typedef<T> operand) {
      var temp = operand.MValue;

      if (temp is bool) {
        var changeType = Convert.ChangeType(temp, TypeCode.Boolean);
        if (changeType != null)
          return (bool) changeType;
      } else if (temp is char) {
        var type = Convert.ChangeType(temp, TypeCode.Char);
        if (type != null)
          return ((char) type != '\0');
      } else if (IsInteger(temp)) {
        var o = Convert.ChangeType(temp, TypeCode.Int64);
        if (o != null)
          return ((long) o > 0);
      } else if (IsFloatingPoint(temp)) {
        var changeType1 = Convert.ChangeType(temp, TypeCode.Decimal);
        if (changeType1 != null)
          return ((decimal) changeType1 > 0);
      } else {
        var s = temp as string;
        if (s != null)
          return string.IsNullOrEmpty((string) (object) temp);
        try {
          return !ReferenceEquals((temp), null);
        } catch (Exception) {
          throw new InvalidOperationException();
        }
      }
      throw new NullReferenceException("typedef.operator(true)");
    }

    public static bool operator false(typedef<T> operand) {
      return (bool) (object) !operand;
    }

    // -----------------------------------------------------------------------
    #endregion Unary Operators  { +, -, !, ~, ++, --, true, false }

    #region Binary Operators  { +, -, *, /, %, &, |, ^, <<, >> }
    // -----------------------------------------------------------------------

    public static T operator +(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return (tempLeft is string) && (tempRight is string)
               ? (T) (object) (((string) (object) tempLeft) + ((string) (object) tempRight))
               : (IsNumeric(tempLeft) && IsNumeric(tempRight) ? (T) (object) (GetNumeric(tempLeft) + GetNumeric(tempRight)) : tempLeft);
    }

    public static T operator -(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) ? (T) (object) (GetNumeric(tempLeft) - GetNumeric(tempRight)) : tempLeft;
    }

    public static T operator *(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) ? (T) (object) (GetNumeric(tempLeft)*GetNumeric(tempRight)) : tempLeft;
    }

    public static T operator /(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) ? (T) (object) (GetNumeric(tempLeft)/GetNumeric(tempRight)) : tempLeft;
    }

    public static T operator %(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) ? (T) (object) (GetNumeric(tempLeft)%GetNumeric(tempRight)) : tempLeft;
    }

    public static T operator &(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsInteger(tempLeft) && IsInteger(tempRight) ? (T) (object) (GetInteger(tempLeft) & GetInteger(tempRight)) : tempLeft;
    }

    public static T operator |(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsInteger(tempLeft) && IsInteger(tempRight) ? (T) (object) (GetInteger(tempLeft) | GetInteger(tempRight)) : tempLeft;
    }

    public static T operator ^(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsInteger(tempLeft) && IsInteger(tempRight) ? (T) (object) (GetInteger(tempLeft) ^ GetInteger(tempRight)) : tempLeft;
    }

    public static T operator <<(typedef<T> left, int right) {
      var tempLeft = left.MValue;
      return IsInteger(tempLeft) ? (T) (object) (GetInteger(tempLeft) << right) : tempLeft;
    }

    public static T operator >>(typedef<T> left, int right) {
      var tempLeft = left.MValue;
      return IsInteger(tempLeft) ? (T) (object) (GetInteger(tempLeft) >> right) : tempLeft;
    }

    // -----------------------------------------------------------------------
    #endregion Binary Operators  { +, -, *, /, %, &, |, ^, <<, >> }

    #region Comparison Operators  { ==, !=, <, >, <=, >= }
    // -----------------------------------------------------------------------

    public static bool operator ==(typedef<T> left, typedef<T> right) {
      return Equals(left, right);
    }

    public static bool operator !=(typedef<T> left, typedef<T> right) {
      return !Equals(left, right);
    }

    public static bool operator <(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) && GetNumeric(tempLeft) < GetNumeric(tempRight);
    }

    public static bool operator >(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) && GetNumeric(tempLeft) > GetNumeric(tempRight);
    }

    public static bool operator <=(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) && GetNumeric(tempLeft) <= GetNumeric(tempRight);
    }

    public static bool operator >=(typedef<T> left, typedef<T> right) {
      var tempLeft = left.MValue;
      var tempRight = right.MValue;
      return IsNumeric(tempLeft) && IsNumeric(tempRight) && GetNumeric(tempLeft) >= GetNumeric(tempRight);
    }

    // -----------------------------------------------------------------------
    #endregion Comparison Operators  { ==, !=, <, >, <=, >= }
  }
}