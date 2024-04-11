//  *****************************************************************************
//  File:       Telnet_Protocol.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

// ReSharper disable InconsistentNaming
namespace TinTin.Enums {
  public enum Telnet_Protocol {
    EOF = 236,
    SUSP,
    ABORT,
    EOR,      // Used for prompt marking.
    SE,
    NOP,
    DMARK,
    BRK,
    IP,
    AO,
    AYT,
    EC,
    EL,
    GA,       // Used for prompt marking.
    SB,
    WILL,
    WONT,
    DO,
    DONT,
    IAC
  }
}