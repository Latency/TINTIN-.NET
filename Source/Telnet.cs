using System;
using System.Collections.Generic;
using System.Threading;

namespace TinTin {
  /// <summary>
  ///  Telnet protocol.
  /// </summary>
  public enum TelProt {
    xEOF = 236,
    SUSP = 237,
    ABORT = 238,
    EOR = 239, // Used for prompt marking
    SE = 240,
    NOP = 241,
    DMARK = 242,
    BRK = 243,
    IP = 244,
    AO = 245,
    AYT = 246,
    EC = 247,
    EL = 248,
    GA = 249, // Used for prompt marking
    SB = 250,
    WILL = 251,
    WONT = 252,
    DO = 253,
    DONT = 254,
    IAC = 255,
  }

  /// <summary>
  ///  Telnet options
  /// </summary>
  public enum TelOpt {
    BINARY,
    ECHO,
    RCP,
    SGA, // Supress Go Ahead
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
    SUPDUP,
    SUPDUPOUTPUT,
    SNDLOC,
    TTYPE, // Terminal Type
    EOR, // End of Record
    TUID,
    OUTMRK,
    TTYLOC,
    3270REGIME,
    X3PAD,
    NAWS, // Negotiate About Window Size
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
    // 50 - 137 unassigned
    MSDP = 69, // Mud Server Data Protocol
    MSSP = 70, // Mud Server Status Protocol
    MCCP1 = 85,
    MCCP2 = 86, // Mud Client Compression Protocol
    MSP = 90, // Mud Sound Protocol
    MXP = 91, // Mud eXtention Protocol
    ZMP = 93, // Zenith Mud Protocol
    PRAGMA_LOGON = 138,
    SSPI__LOGON = 139,
    // 141 - 254 unassigned
    PRAGMA_HEARTBEAT = 140,
    GMCP = 201, // Generic Mud Communication Protocol
    EXOPL = 255,
  }

//#define     TELCMD_OK(c)     ((c) >= xEOF)
//#define     TELCMD(c)        telcmds[(c)-xEOF]
//#define     TELOPT(c)       (telnet_table[(unsigned char) (c)].name)


// Sub negotiation
// [RFC2941]
// 
  public enum Auth {
    IS,
    SEND,
    REPLY,
    NAME
  }


public enum ENV {
    VAR,
    VAL,
    ESC,   // Not implemented in tintin
    USR
  }

  public enum MSDP {
    VAR,
    VAL,
    TABLE_OPEN,
    TABLE_CLOSE,
    ARRAY_OPEN,
    ARRAY_CLOSE
  }

}