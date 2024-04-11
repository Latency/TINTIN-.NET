//  *****************************************************************************
//  File:      DynamicSplashScreen.cs
//  Solution:  WPF_DynamicSplashScreen
//  Project:   WPF_DynamicSplashScreen
//  Date:      08/25/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Inc. - 2012-2016
//  *****************************************************************************

using System.Windows;

namespace TinTin.GUI.SplashScreen {
  public class DynamicSplashScreen : Window {
    public DynamicSplashScreen() {
      ShowInTaskbar = false;
      WindowStartupLocation = WindowStartupLocation.Manual;
      ResizeMode = ResizeMode.NoResize;
      WindowStyle = WindowStyle.None;
      Topmost = true;
      Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
      //calculate it manually since CenterScreen substracts taskbar height from available area
      Left = (SystemParameters.PrimaryScreenWidth - Width)/2;
      Top = (SystemParameters.PrimaryScreenHeight - Height)/2;
    }
  }
}