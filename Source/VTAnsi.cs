/*****************************************************************************
 * File:     VTAnsi.cpp                                                      *
 * Author:   Latency McLaughlin                        Bio-Hazard Industries *
 * Date:     05/15/12                          �1998  -  All Rights Reserved *
 ****************************************************************************/
// http://ascii-table.com/ansi-escape-sequences-vt-100.php
using System;
using System.Drawing;
using TinTin.enums;


namespace TinTin {
// ReSharper disable InconsistentNaming
  public sealed class VT100 {
    public static string Esc = @"\e[";

    #region Properties
    // -----------------------------------------------------------------------

    public Size Size { get; }

    // -----------------------------------------------------------------------
    #endregion Properties


    #region Constructors
    // -----------------------------------------------------------------------

    public VT100() : this(80, 24) { }

    public VT100(int width, int height) {
      Size = new Size(width, height);
    }

    // -----------------------------------------------------------------------
    #endregion Constructors




    public static string Cursor(int x, Arrows dir) {
      return string.Format(Esc + "[{0};{1}", x, Convert.ToChar(65 + (int) dir));
    }

    public static string GoTo(int x, int y) {
      const char ch = 'H'; // or 'f'
      return string.Format(Esc + "[{0};{1}{2}", x, y, ch);
    }

    public static string Home() {
      return Esc + "[H";
    }

    public static string WrapLine(OnOff status) {
      return Esc + '7' + (status == OnOff.Off ? 'l' : 'h');
    }

    public static string Split(int top, int bottom) {
      return Esc + top + ';' + bottom + "r;2J";
    }


    /// <summary>
    /// Double-height letters, top half
    /// </summary>
    /// <returns>DECDHL</returns>
    public static string DblHtTopHalf => Esc + "#3";

    /// <summary>
    /// Double-height letters, bottom half
    /// </summary>
    /// <returns>DECDHL</returns>
    public static string DblHtBtmHalf => Esc + "#4";

    /// <summary>
    /// Single width, single height letters
    /// </summary>
    /// <returns>DECSWL</returns>
    public static string SnglWdthSnglHt => Esc + "#5";

    /// <summary>
    /// Double width, single height letters
    /// </summary>
    /// <returns>DECDWL</returns>
    public static string DblWdthSnglHt => Esc + "#6";

    /// <summary>
    /// Clear line from cursor right
    /// </summary>
    /// <returns>EL0</returns>
    public static string ClearLineRight => Esc + '[' + /* '0' + */ 'K';

    /// <summary>
    /// Clear line from cursor left
    /// </summary>
    /// <returns>EL1</returns>
    public static string ClearLineLeft => Esc + "1K";

    /// <summary>
    /// Clear entire line
    /// </summary>
    /// <returns>EL2</returns>
    public static string ClearLineAll => Esc + "[2K";

    /// <summary>
    ///  Clear screen from cursor down
    /// </summary>
    /// <returns>ED0</returns>
    public static string ClearDown => Esc + '[' + /* '0' + */ 'J';

    /// <summary>
    ///  Clear screen from cursor up
    /// </summary>
    /// <returns>ED1</returns>
    public static string ClearUp => Esc + "[1J";

    /// <summary>
    ///  Clear entire screen
    /// </summary>
    /// <returns>ED2</returns>
    public static string ClearScreen => Esc + "[2J";

    /// <summary>
    ///  Turn off all four leds
    /// </summary>
    /// <returns>DECLL0</returns>
    public static string LEDs_Off => Esc + "[0q";

    /// <summary>
    /// Turn on LED #1
    /// </summary>
    /// <returns>DECLL1</returns>
    public static string LED1_On => Esc + "[1q";

    /// <summary>
    /// Turn on LED #2
    /// </summary>
    /// <returns>DECLL2</returns>
    public static string LED2_On => Esc + "[2q";

    /// <summary>
    /// Turn on LED #3
    /// </summary>
    /// <returns>DECLL3</returns>
    public static string LED3_On => Esc + "[3q";

    /// <summary>
    /// Turn on LED #4
    /// </summary>
    /// <returns>DECLL4</returns>
    public static string LED4_On => Esc + "[4q";


    /*
     * VT100 Special Key Codes
     *
     * These are sent from the terminal back to the computer when the
     * particular key is pressed.	Note that the numeric keypad keys
     * send different codes in numeric mode than in alternate mode.
     * 
     * See escape codes above to change keypad mode.
     */

    // ---------------------------------------
    // Function Keys
    // ---------------------------------------
    public static string PF1 => Esc + "OP";

    public static string PF2 => Esc + "OQ";

    public static string PF3 => Esc + "OR";

    public static string PF4 => Esc + "OS";

    // ---------------------------------------
    // Arrow Keys
    // ---------------------------------------
    public static string Arrow(OnOff isSet, Arrows dir) {
      return string.Format(Esc + "{0}{1}", (isSet == OnOff.On ? "O" : ""), Convert.ToChar(65 + (int) dir));
    }
    
    // ---------------------------------------
    // Numeric Keypad Keys
    // ---------------------------------------
    public static string Keypad_0 => Esc + "Op";

    public static string Keypad_1 => Esc + "Oq";

    // ReSharper restore InconsistentNaming
  }
}