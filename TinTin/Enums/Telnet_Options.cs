//  *****************************************************************************
//  File:       Telnet_Options.cs
//  Solution:   TinTin.NET
//  Project:    TinTin
//  Date:       09/13/2017
//  Author:     Latency McLaughlin
//  Copywrite:  Bio-Hazard Industries - 1998-2017
//  *****************************************************************************

// ReSharper disable InconsistentNaming
namespace TinTin.Enums {
  public enum Telnet_Options {
    BINARY,
    ECHO,         // Echo
    RCP,
    SGA,          // Supress Go Ahead
    NAMS,
    STATUS,
    TIMINGMARK,
    RCTE,
    NAOL,
    NAOP,
    NAOCRD,
    NAOHTS,
    NAOHTD,
    NAOFFD,
    NAOVTS,
    NAOVTD,
    NAOLFD,
    XASCII,
    LOGOUT,
    BM,
    DET,
    SUPUP,
    SUPDUPOUTPUT,
    SNDLOC,
    TTYPE,        // Terminal Type
    EOR,          // End of Record
    TUID,
    OUTMRK,
    TTYLOC,
    REGIME,
    X3PAD,
    NAWS,         // Negotiate About Window Size
    TSPEED,
    LFLOW,
    LINEMODE,
    XDISPLOC,
    OLD_ENVIRON,
    AUTH,
    ENCRYPT,
    NEW_ENVIRON,
    TN3270E,
    XAUTH,
    CHARSET,
    TREMOTESERIAL,
    CPCO,
    SUPECHO,
    STARTTLS,
    KERMIT,
    SEND_URL,
    FORWARD_X,
    MSDP = 69,    // Mud Server Data Protocol
    MSSP,         // Mud Server Status Protocol
    MCCP1 = 85,
    MCCP2,        // Mud Client Compression Protocol
    MSP = 90,     // Mud Sound Protocol
    MXP,          // Mud eXtension Protocol
    ZMP = 93,     // Zenith Mud Protocol
    PRAGMA_LOGON = 138,
    SSPI_LOGON,
    PRAGMA_HEARTBEAT,
    GMCP = 201,   // Generic Mud Communication Protocol
    EXOPL = 255
  }
}