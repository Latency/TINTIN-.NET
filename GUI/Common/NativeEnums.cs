//  *****************************************************************************
//  File:      NativeEnums.cs
//  Solution:  Sentinel
//  Project:   Common
//  Date:      07/14/2016
//  Author:    Latency McLaughlin
//  Copywrite: Kryterion Online - 2016
//  *****************************************************************************

using System;

namespace TinTin.GUI.Common {
  // ReSharper disable InconsistentNaming
  [Flags]
  public enum ThreadAccess {
    TERMINATE            = 1 << 0,
    SUSPEND_RESUME       = 1 << 1,
    GET_CONTEXT          = 2 << 2,
    SET_CONTEXT          = 2 << 3,
    SET_INFORMATION      = 2 << 4,
    QUERY_INFORMATION    = 2 << 5,
    SET_THREAD_TOKEN     = 2 << 6,
    IMPERSONATE          = 2 << 7,
    DIRECT_IMPERSONATION = 2 << 8
  }

  
  /// <summary>
  ///   Enumerates the valid hook types passed into a call to SetWindowsHookEx.
  /// </summary>
  /// <seealso cref="http://www.pinvoke.net/default.aspx/Enums/HookType.html" />
  public enum HookType {
    WH_JOURNALRECORD = 0,
    WH_JOURNALPLAYBACK = 1,
    WH_KEYBOARD = 2,
    WH_GETMESSAGE = 3,
    WH_CALLWNDPROC = 4,
    WH_CBT = 5,
    WH_SYSMSGFILTER = 6,
    WH_MOUSE = 7,
    WH_HARDWARE = 8,
    WH_DEBUG = 9,
    WH_SHELL = 10,
    WH_FOREGROUNDIDLE = 11,
    WH_CALLWNDPROCRET = 12,
    WH_KEYBOARD_LL = 13,
    WH_MOUSE_LL = 14
  }


  /// <summary>
  ///  System command values used in the WM_SYSCOMMAND notification.
  /// </summary>
  public enum SysCommands {
    SC_SIZE = 0xF000,
    SC_MOVE = 0xF010,
    SC_MINIMIZE = 0xF020,
    SC_MAXIMIZE = 0xF030,
    SC_NEXTWINDOW = 0xF040,
    SC_PREVWINDOW = 0xF050,
    SC_CLOSE = 0xF060,
    SC_VSCROLL = 0xF070,
    SC_HSCROLL = 0xF080,
    SC_MOUSEMENU = 0xF090,
    SC_KEYMENU = 0xF100,
    SC_ARRANGE = 0xF110,
    SC_RESTORE = 0xF120,
    SC_TASKLIST = 0xF130,
    SC_SCREENSAVE = 0xF140,
    SC_HOTKEY = 0xF150,
    //#if(WINVER >= 0x0400) //Win95
    SC_DEFAULT = 0xF160,
    SC_MONITORPOWER = 0xF170,
    SC_CONTEXTHELP = 0xF180,
    SC_SEPARATOR = 0xF00F,
    //#endif /* WINVER >= 0x0400 */

    //#if(WINVER >= 0x0600) //Vista
    SCF_ISSECURE = 0x00000001,
    //#endif /* WINVER >= 0x0600 */

    /*
     * Obsolete names
     */
    SC_ICON = SC_MINIMIZE,
    SC_ZOOM = SC_MAXIMIZE,
  }


  /// <summary>
  ///  The window style constants used in CreateWindowEx.
  /// </summary>
  [Flags]
  public enum WindowStyles : uint {
    WS_OVERLAPPED = 0x00000000,
    WS_POPUP = 0x80000000,
    WS_CHILD = 0x40000000,
    WS_MINIMIZE = 0x20000000,
    WS_VISIBLE = 0x10000000,
    WS_DISABLED = 0x08000000,
    WS_CLIPSIBLINGS = 0x04000000,
    WS_CLIPCHILDREN = 0x02000000,
    WS_MAXIMIZE = 0x01000000,
    WS_BORDER = 0x00800000,
    WS_DLGFRAME = 0x00400000,
    WS_VSCROLL = 0x00200000,
    WS_HSCROLL = 0x00100000,
    WS_SYSMENU = 0x00080000,
    WS_THICKFRAME = 0x00040000,
    WS_GROUP = 0x00020000,
    WS_TABSTOP = 0x00010000,

    WS_MINIMIZEBOX = 0x00020000,
    WS_MAXIMIZEBOX = 0x00010000,

    WS_CAPTION = WS_BORDER | WS_DLGFRAME,
    WS_TILED = WS_OVERLAPPED,
    WS_ICONIC = WS_MINIMIZE,
    WS_SIZEBOX = WS_THICKFRAME,
    WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

    WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
    WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
    WS_CHILDWINDOW = WS_CHILD,

    //Extended Window Styles

    WS_EX_DLGMODALFRAME = 0x00000001,
    WS_EX_NOPARENTNOTIFY = 0x00000004,
    WS_EX_TOPMOST = 0x00000008,
    WS_EX_ACCEPTFILES = 0x00000010,
    WS_EX_TRANSPARENT = 0x00000020,
    
    //#if(WINVER >= 0x0400)

    WS_EX_MDICHILD = 0x00000040,
    WS_EX_TOOLWINDOW = 0x00000080,
    WS_EX_WINDOWEDGE = 0x00000100,
    WS_EX_CLIENTEDGE = 0x00000200,
    WS_EX_CONTEXTHELP = 0x00000400,

    WS_EX_RIGHT = 0x00001000,
    WS_EX_LEFT = 0x00000000,
    WS_EX_RTLREADING = 0x00002000,
    WS_EX_LTRREADING = 0x00000000,
    WS_EX_LEFTSCROLLBAR = 0x00004000,
    WS_EX_RIGHTSCROLLBAR = 0x00000000,

    WS_EX_CONTROLPARENT = 0x00010000,
    WS_EX_STATICEDGE = 0x00020000,
    WS_EX_APPWINDOW = 0x00040000,

    WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
    WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
    
    //#endif /* WINVER >= 0x0400 */

    //#if(WIN32WINNT >= 0x0500)

    WS_EX_LAYERED = 0x00080000,

    //#endif /* WIN32WINNT >= 0x0500 */

    //#if(WINVER >= 0x0500)

    WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
    WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring

    //#endif /* WINVER >= 0x0500 */

    //#if(WIN32WINNT >= 0x0500)

    WS_EX_COMPOSITED = 0x02000000,
    WS_EX_NOACTIVATE = 0x08000000


    //#endif /* WIN32WINNT >= 0x0500 */
  }


  /// <summary>
  ///   An enumeration which maps to the various VK_* constants.
  /// </summary>
  /// <seealso cref="http://www.pinvoke.net/default.aspx/Enums/VirtualKeys.html" />
  public enum VirtualKeys : ushort {
    LeftButton = 0x01,
    RightButton = 0x02,
    Cancel = 0x03,
    MiddleButton = 0x04,
    ExtraButton1 = 0x05,
    ExtraButton2 = 0x06,
    Back = 0x08,
    Tab = 0x09,
    Clear = 0x0C,
    Return = 0x0D,
    Shift = 0x10,
    Control = 0x11,
    Menu = 0x12,
    Pause = 0x13,
    CapsLock = 0x14,
    Kana = 0x15,
    Hangeul = 0x15,
    Hangul = 0x15,
    Junja = 0x17,
    Final = 0x18,
    Hanja = 0x19,
    Kanji = 0x19,
    Escape = 0x1B,
    Convert = 0x1C,
    NonConvert = 0x1D,
    Accept = 0x1E,
    ModeChange = 0x1F,
    Space = 0x20,
    Prior = 0x21,
    Next = 0x22,
    End = 0x23,
    Home = 0x24,
    Left = 0x25,
    Up = 0x26,
    Right = 0x27,
    Down = 0x28,
    Select = 0x29,
    Print = 0x2A,
    Execute = 0x2B,
    Snapshot = 0x2C,
    Insert = 0x2D,
    Delete = 0x2E,
    Help = 0x2F,
    N0 = 0x30,
    N1 = 0x31,
    N2 = 0x32,
    N3 = 0x33,
    N4 = 0x34,
    N5 = 0x35,
    N6 = 0x36,
    N7 = 0x37,
    N8 = 0x38,
    N9 = 0x39,
    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,
    LeftWindows = 0x5B,
    RightWindows = 0x5C,
    Application = 0x5D,
    Sleep = 0x5F,
    Numpad0 = 0x60,
    Numpad1 = 0x61,
    Numpad2 = 0x62,
    Numpad3 = 0x63,
    Numpad4 = 0x64,
    Numpad5 = 0x65,
    Numpad6 = 0x66,
    Numpad7 = 0x67,
    Numpad8 = 0x68,
    Numpad9 = 0x69,
    Multiply = 0x6A,
    Add = 0x6B,
    Separator = 0x6C,
    Subtract = 0x6D,
    Decimal = 0x6E,
    Divide = 0x6F,
    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,
    NumLock = 0x90,
    ScrollLock = 0x91,
    NEC_Equal = 0x92,
    Fujitsu_Jisho = 0x92,
    Fujitsu_Masshou = 0x93,
    Fujitsu_Touroku = 0x94,
    Fujitsu_Loya = 0x95,
    Fujitsu_Roya = 0x96,
    LeftShift = 0xA0,
    RightShift = 0xA1,
    LeftControl = 0xA2,
    RightControl = 0xA3,
    LeftMenu = 0xA4,
    RightMenu = 0xA5,
    BrowserBack = 0xA6,
    BrowserForward = 0xA7,
    BrowserRefresh = 0xA8,
    BrowserStop = 0xA9,
    BrowserSearch = 0xAA,
    BrowserFavorites = 0xAB,
    BrowserHome = 0xAC,
    VolumeMute = 0xAD,
    VolumeDown = 0xAE,
    VolumeUp = 0xAF,
    MediaNextTrack = 0xB0,
    MediaPrevTrack = 0xB1,
    MediaStop = 0xB2,
    MediaPlayPause = 0xB3,
    LaunchMail = 0xB4,
    LaunchMediaSelect = 0xB5,
    LaunchApplication1 = 0xB6,
    LaunchApplication2 = 0xB7,
    OEM1 = 0xBA,
    OEMPlus = 0xBB,
    OEMComma = 0xBC,
    OEMMinus = 0xBD,
    OEMPeriod = 0xBE,
    OEM2 = 0xBF,
    OEM3 = 0xC0,
    OEM4 = 0xDB,
    OEM5 = 0xDC,
    OEM6 = 0xDD,
    OEM7 = 0xDE,
    OEM8 = 0xDF,
    OEMAX = 0xE1,
    OEM102 = 0xE2,
    ICOHelp = 0xE3,
    ICO00 = 0xE4,
    ProcessKey = 0xE5,
    ICOClear = 0xE6,
    Packet = 0xE7,
    OEMReset = 0xE9,
    OEMJump = 0xEA,
    OEMPA1 = 0xEB,
    OEMPA2 = 0xEC,
    OEMPA3 = 0xED,
    OEMWSCtrl = 0xEE,
    OEMCUSel = 0xEF,
    OEMATTN = 0xF0,
    OEMFinish = 0xF1,
    OEMCopy = 0xF2,
    OEMAuto = 0xF3,
    OEMENLW = 0xF4,
    OEMBackTab = 0xF5,
    ATTN = 0xF6,
    CRSel = 0xF7,
    EXSel = 0xF8,
    EREOF = 0xF9,
    Play = 0xFA,
    Zoom = 0xFB,
    Noname = 0xFC,
    PA1 = 0xFD,
    OEMClear = 0xFE
  }

  // ReSharper restore InconsistentNaming
}