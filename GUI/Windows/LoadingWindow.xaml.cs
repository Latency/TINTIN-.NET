//  *****************************************************************************
//  File:      SplashScreen.xaml.cs
//  Solution:  Sentinel
//  Project:   Sentinel
//  Date:      08/25/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Inc. - 2012-2016
//  *****************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using TinTin.GUI.Common;
using TinTin.GUI.Properties;
using TinTin.GUI.SplashScreen;

namespace TinTin.GUI.Windows {
  public partial class LoadingWindow : IDisposable {
    #region Fields
    // -----------------------------------------------------------------------

    /// <summary>
    ///  _dependancyCollection
    /// </summary>
    private static readonly Dictionary<string, DependencyProperty>  DependancyCollection = new Dictionary<string, DependencyProperty>();

    private readonly Queue _queue = new Queue();   

    private static readonly object Mutex = new object();
    private static readonly object DictMutex = new object();

    // -----------------------------------------------------------------------
    #endregion Fields


    #region Properties
    // -----------------------------------------------------------------------

    public bool Interrupt { get; set; }

    /// <summary>
    ///  CanClose
    /// </summary>
    public bool CanClose => _queue.Count == 0;

    // -----------------------------------------------------------------------
    #endregion Properties


    #region Constructors
    // -----------------------------------------------------------------------

    /// <summary>
    ///  Static constructor
    /// </summary>
    static LoadingWindow() {
      var classType = typeof(LoadingWindow);

      // Map the actual property to the DependencyProperty type.
      foreach (var key in new[] {
          nameof(AvailablePlugins),
          nameof(Company),
          nameof(IsIndeterminate),
          nameof(Message),
          nameof(ProgressMessage),
          nameof(ProgressValue),
          nameof(Title)
      }) {
        var propertyType = classType.GetProperty(key)?.PropertyType;
        DependancyCollection.Add(key, DependencyProperty.Register(key, propertyType ?? throw new InvalidOperationException(), classType, new UIPropertyMetadata(propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null, (sender, e) => Invoke(sender, key, e.NewValue))));
      }
    }


    /// <summary>
    ///  Default constructor
    /// </summary>
    public LoadingWindow() {
      InitializeComponent();

      // Bind listeners.
      //if (!ProgressBar.IsIndeterminate)
      //  ContentRendered += OnContentRendered;
    }

    // -----------------------------------------------------------------------
    #endregion Constructors


    #region Dependancy Properties
    // -----------------------------------------------------------------------

      /// <summary>
      ///  AvailablePlugins
      /// </summary>
    public IEnumerable<string> AvailablePlugins {
      get => Get<IEnumerable<string>>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }


    /// <summary>
    ///  Company
    /// </summary>
    public string Company {
      get => Get<string>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }


    /// <summary>
    ///  IsIndeterminate
    /// </summary>
    public bool IsIndeterminate {
      get => Get<bool>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }


    /// <summary>
    ///  Message
    /// </summary>
    public string Message {
      get => Get<string>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set {
        // The property name via reflection.
        var methodName = MethodBase.GetCurrentMethod().Name;
        // Invoke the callback.
        Dispatcher.InvokeAsync(
          () => {
            lock (DictMutex) {
              var sea = new SplashEventArgs(methodName, value, new DispatcherTimer(TimeSpan.FromMilliseconds(Settings.Default.SplashScreenDelay), DispatcherPriority.Send, Tick, Dispatcher.CurrentDispatcher));
              _queue.Enqueue(sea);
              Set(methodName.Substring(4), _queue.ToArray().Aggregate(string.Empty, (current, item) => current + ((SplashEventArgs)item).Value + Environment.NewLine));
              TextBoxCtrl.ScrollToEnd();
            }
          }, DispatcherPriority.Send
        );
      }
    }


    /// <summary>
    ///  ProgressMessage
    /// </summary>
    public string ProgressMessage {
      get => Get<string>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }


    /// <summary>
    ///  ProgressValue
    /// </summary>
    public int ProgressValue {
      get => Get<int>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }


    /// <summary>
    ///  Title
    /// </summary>
    public new string Title {
      get => Get<string>(MethodBase.GetCurrentMethod().Name.Substring(4));
      set => Set(MethodBase.GetCurrentMethod().Name.Substring(4), value);
    }

    // -----------------------------------------------------------------------
    #endregion Dependancy Properties


    #region Methods
    // -----------------------------------------------------------------------

    /// <summary>
    ///  Get
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="property"></param>
    /// <returns></returns>
    private T Get<T>(string property) {
      return (T) this.InvokeIfRequired(
        objs => {
          lock (Mutex) {
            return objs[0] is string key ? GetValue(DependancyCollection[key]) : null;
          }
        }, DispatcherPriority.Send, property
      );
    }


    /// <summary>
    ///  Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="property"></param>
    /// <param name="value"></param>
    private void Set<T>(string property, T value) {
      this.InvokeIfRequired(
        objs => {
          lock (Mutex) {
            if (!(objs[0] is string key))
              return;
            var v = objs[1] is T variable ? variable : default(T);
            SetValue(DependancyCollection[key], v);
          }
        }, DispatcherPriority.Send, property, value
      );
    }


    /// <summary>
    ///  Invoke - Similar to Set, but uses Reflection.SetValue() instead of DependancyObject.SetValue()
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="property"></param>
    /// <param name="ea"></param>
    private static void Invoke(DispatcherObject sender, string property, object ea) {
      sender.InvokeIfRequired(
        objs => {
          typeof(DispatcherObject).GetProperty((string) objs[1])?.SetValue(objs[0], objs[2]);
        }, DispatcherPriority.Send, sender, property, ea
      );
    }


    /// <summary>
    ///  Eventhandler for DispatcherTimer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private void Tick(object sender, EventArgs eventArgs) {
      var dt = sender as DispatcherTimer;
      dt?.Stop();

      if (_queue.Count <= 0)
        return;

      lock (DictMutex) {
        var sea = (SplashEventArgs)_queue.Dequeue();
        // Copy since modification to collection is taking place.
        Set(sea.Name.Substring(4), _queue.ToArray().Aggregate(string.Empty, (current, item) => current + ((SplashEventArgs)item).Value + Environment.NewLine));
      }
    }


    /// <inheritdoc />
    /// <summary>
    ///  Updates the progress bar to simulate interval markings.
    /// </summary>
    /// <summary>
    ///  Dispose
    /// </summary>
    public void Dispose() {
      _queue?.Clear();
    }

    // -----------------------------------------------------------------------
    #endregion Methods
  }
}