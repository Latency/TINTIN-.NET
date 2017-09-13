//  *****************************************************************************
//  File:       Timers.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using System;
using System.Collections.Generic;
using System.Threading;
using Timer = System.Timers.Timer;

namespace TinTin {
  public class Event {
    // Define a delegate named LogHandler, which will encapsulate
    // any method that takes a string as the parameter and returns no value
    public delegate void EventHandler(object o);

    private AutoResetEvent _a;
    private Timer _t;


    // Constructor
    public Event(int pulse) {
      _t = new Timer(pulse);
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


  internal class StatusChecker {
    private readonly int _maxCount;
    private int _invokeCount;

    public StatusChecker(int count) {
      _invokeCount = 0;
      _maxCount = count;
    }

    // This method is called by the timer delegate.
    public void CheckStatus(object stateInfo) {
      var autoEvent = (AutoResetEvent) stateInfo;
      Console.WriteLine(@"{0:h:mm:ss.fff} Checking status {1,2}.", DateTime.Now, ++_invokeCount);

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
        {
          "poll_input", new Event(1)
        }, {
          "poll_sessions", new Event(1)
        }, {
          "poll_chat", new Event(2)
        }, {
          "update_ticks", new Event(1)
        }, {
          "update_delays", new Event(1)
        }, {
          "update_packets", new Event(2)
        }, {
          "update_chat", new Event(2)
        }, {
          "update_terminal", new Event(1)
        }, {
          "update_memory", new Event(2)
        }, {
          "update_time", new Event(20)
        }
      };

      var autoEvent = new AutoResetEvent(false);
      var statusChecker = new StatusChecker(10);

      // Create the delegate that invokes methods for the timer.
      var timerDelegate = new TimerCallback(statusChecker.CheckStatus);

      // Create a timer that signals the delegate to invoke 
      // CheckStatus after one second, and every 1/4 second 
      // thereafter.
      Console.WriteLine(@"{0:h:mm:ss.fff} Creating timer.", DateTime.Now);
      var stateTimer = new System.Threading.Timer(timerDelegate, autoEvent, 1000, 250);
    }

    // ReSharper restore InconsistentNaming
  }
}