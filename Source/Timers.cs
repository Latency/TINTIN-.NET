// *****************************************************************************
// File:      Timers.cs
// Solution:  TinTin.NET
// Date:      10/13/2015
// Author:    Latency McLaughlin
// Copywrite: Bio-Hazard Industries - 1997-2015
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Threading;

namespace TinTin {
  public class Event {
    // Define a delegate named LogHandler, which will encapsulate
    // any method that takes a string as the parameter and returns no value
    public delegate void EventHandler(object o);

    private AutoResetEvent _a;
    private System.Timers.Timer _t;
    // Constructor
    public Event(int pulse) {
      _t = new System.Timers.Timer(pulse);
      _a = new AutoResetEvent(false);
    }

    // Define an Event based on the above Delegate
    public event EventHandler Evt;
    // The method which fires the Event
    protected void OnEvent(object obj) {
      var e = (EventHandler) obj;
      // Check if there are any Subscribers and call the Event
      Evt?.Invoke(obj);
    }
  }


  class StatusChecker {
    private int _invokeCount;
    private readonly int _maxCount;

    public StatusChecker(int count) {
      _invokeCount = 0;
      _maxCount = count;
    }

    // This method is called by the timer delegate.
    public void CheckStatus(object stateInfo) {
      var autoEvent = (AutoResetEvent)stateInfo;
      Console.WriteLine(@"{0} Checking status {1,2}.", DateTime.Now.ToString("h:mm:ss.fff"), ++_invokeCount);

      if (_invokeCount == _maxCount) {
        // Reset the counter and signal Main.
        _invokeCount = 0;
        autoEvent.Set();
      }
    }
  }


  public class TimerDelegates {
    // ReSharper disable InconsistentNaming
    private Dictionary<string, Event> _timers;

    /// <summary>
    ///   Constructor
    /// </summary>
    public TimerDelegates() {
      _timers = new Dictionary<string, Event> {
        {"poll_input", new Event(1)},
        {"poll_sessions", new Event(1)},
        {"poll_chat", new Event(2)},
        {"update_ticks", new Event(1)},
        {"update_delays", new Event(1)},
        {"update_packets", new Event(2)},
        {"update_chat", new Event(2)},
        {"update_terminal", new Event(1)},
        {"update_memory", new Event(2)},
        {"update_time", new Event(20)}
      };

      var autoEvent = new AutoResetEvent(false);
      var statusChecker = new StatusChecker(10);

      // Create the delegate that invokes methods for the timer.
      var timerDelegate = new TimerCallback(statusChecker.CheckStatus);

      // Create a timer that signals the delegate to invoke 
      // CheckStatus after one second, and every 1/4 second 
      // thereafter.
      Console.WriteLine(@"{0} Creating timer.", DateTime.Now.ToString("h:mm:ss.fff"));
      var stateTimer = new Timer(timerDelegate, autoEvent, 1000, 250);
    }

    // ReSharper restore InconsistentNaming
  }
}