using System;
using AppKit;

namespace MacArchitecture.UiElements.Menu {
    internal class MenuDelegate : NSMenuDelegate {
        public MenuDelegate() {
        }

        public override void MenuWillHighlightItem(NSMenu menu, NSMenuItem item) {
            if (item == null)
                return;
        }


        //public override void NeedsUpdate(NSMenu menu) {
        //}


        //public override bool UpdateItem(NSMenu menu, NSMenuItem item, nint atIndex, bool shouldCancel) { 
        //  Console.WriteLine("UpdateItem " + item.Title);
        //  item.Enabled = false;
        //  //return true;
        //  return false;
        //}

    }
}
