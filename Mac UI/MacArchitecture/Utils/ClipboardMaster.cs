using System;
using AppKit;
using Foundation;

namespace MacArchitecture.Utils {
    public class ClipboardMaster {
        public void CopyString(string str) {
            if (string.IsNullOrEmpty(str)) return;

            var pasteboard = NSPasteboard.GeneralPasteboard;
            pasteboard.ClearContents();
            pasteboard.WriteObjects(new NSString[] { (NSString)str });
        }

        public string PasteString() {
            string strForPaste = string.Empty;

            var pasteboard = NSPasteboard.GeneralPasteboard;
            ObjCRuntime.Class[] classArray = { new ObjCRuntime.Class("NSString") };

            bool ok = pasteboard.CanReadObjectForClasses(classArray, null);
            if (ok) {
                NSObject[] objectsToPaste = pasteboard.ReadObjectsForClasses(classArray, null);
                strForPaste = (NSString)objectsToPaste[0];
            }

            return strForPaste;
        }

        //public void CopyStringCtrlV(string str, NSEvent keyEvent) {
        //  //key code
        //  //c = 8
        //  //v = 8
        //  if (keyEvent.KeyCode == 8 &&
        //      keyEvent.ModifierFlags.HasFlag(NSEventModifierMask.CommandKeyMask)) {
        //      CopyString(str);
        //  }
        //}
    }
}
