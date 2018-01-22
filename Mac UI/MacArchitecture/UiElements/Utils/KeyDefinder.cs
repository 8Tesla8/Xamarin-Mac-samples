using System;
using AppKit;

namespace MacArchitecture.UiElements.Utils  {
    internal static class KeyDefinder {

        #region cmd+
        public static bool CmdA(NSEvent theEvent) {
            if (AKey(theEvent) && CmdMask(theEvent))
                return true;
            return false;
        }
        public static bool CmdC(NSEvent theEvent) {
            if (CKey(theEvent) && CmdMask(theEvent))
                return true;
            return false;
        }
        public static bool CmdV(NSEvent theEvent) {
            if (VKey(theEvent) && CmdMask(theEvent))
                return true;
            return false;
        }
        public static bool CmdW(NSEvent theEvent) {
            if (WKey(theEvent) && CmdMask(theEvent))
                return true;
            return false;
        }
        #endregion

        #region shift+
        public static bool ShiftDownKey(NSEvent theEvent) {
            if (DownKey(theEvent) && ShiftMask(theEvent))
                return true;
            return false;
        }
        public static bool ShiftUpKey(NSEvent theEvent) {
            if (UpKey(theEvent) && ShiftMask(theEvent))
                return true;
            return false;
        }
        #endregion

        #region Masks
        public static bool ShiftMask(NSEvent theEvent) {
            if (theEvent.ModifierFlags.HasFlag(NSEventModifierMask.ShiftKeyMask))
                return true;
            return false;
        }
        public static bool CmdMask(NSEvent theEvent) {
            if (theEvent.ModifierFlags.HasFlag(NSEventModifierMask.CommandKeyMask))
                return true;
            return false;
        }
        #endregion

        #region KeyCodes
        public static bool EscKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 53)
                return true;
            return false;
        }
        public static bool EnterKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 36)
                return true;
            return false;
        }
        public static bool SpaceKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 49)
                return true;
            return false;
        }

        public static bool LeftKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 123)
                return true;
            return false;
        }
        public static bool RightKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 124)
                return true;
            return false;
        }
        public static bool DownKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 125)
                return true;
            return false;
        }
        public static bool UpKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 126)
                return true;
            return false;
        }

        public static bool AKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 0)
                return true;
            return false;
        }
        public static bool CKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 8)
                return true;
            return false;
        }
        public static bool VKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 9)
                return true;
            return false;
        }
        public static bool WKey(NSEvent theEvent) {
            if (theEvent.KeyCode == 13)
                return true;
            return false;
        }
        #endregion
    }
}
