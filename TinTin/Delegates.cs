//  *****************************************************************************
//  File:       Delegates.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

using TinTin.Entities;

// ReSharper disable InconsistentNaming
namespace TinTin {
  public static class Delegates {
    public delegate Session ARRAY(Session session, ListNode list, string arg, string var);

    public delegate Session CLASS(Session session, string left, string right);

    public delegate Session CONFIG(Session session, string arg, int index);

    public delegate Session COMMAND(Session session, string arg);

    public delegate Session PORT(Session session, string left, string right, string arg);

    public delegate Session LINE(Session session, string arg);

    public delegate void CHAT(string left, string right);

    public delegate void MAP(Session session, string arg, string arg1, string arg2);

    public delegate void CURSOR(Session session, string arg);

    public delegate void PATH(Session session, string arg);

    public delegate void HISTORY(Session session, string arg);

    public delegate void BUFFER(Session session, string arg);
  }
}