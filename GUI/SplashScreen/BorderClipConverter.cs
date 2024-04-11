//  *****************************************************************************
//  File:       BorderClipConverter.cs
//  Solution:   Sentinel
//  Project:    Sentinel
//  Date:       09/05/2016
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2016
//  *****************************************************************************

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TinTin.GUI.SplashScreen {
  public class BorderClipConverter : IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
      if (values.Length == 3 && values[0] is double && values[1] is double && values[2] is CornerRadius) {
        var width = (double) values[0];
        var height = (double) values[1];

        if (width < double.Epsilon || height < double.Epsilon)
          return Geometry.Empty;

        var radius = (CornerRadius) values[2];

        // Actually we need more complex geometry, when CornerRadius has different values.
        // But let me not to take this into account, and simplify example for a common value.
        var clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft, radius.TopLeft);
        clip.Freeze();

        return clip;
      }

      return DependencyProperty.UnsetValue;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
      throw new NotSupportedException();
    }
  }
}