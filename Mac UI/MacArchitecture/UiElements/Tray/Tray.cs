using System;
using AppKit;

namespace MacArchitecture.UiElements.Tray {
    public class Tray {

        public NSStatusItem StatusBarItem { get; private set; }


        public void CreateTray(NSMenu trayMenu) {
            //in Info.plist add row - | Property: Application is agent (UIElement) | Type: Boolen | Value: Yes | (may be need or not)

            if (StatusBarItem != null)
                RemoveTray();

            StatusBarItem = NSStatusBar.SystemStatusBar.CreateStatusItem(30);
            StatusBarItem.Menu = trayMenu;

            var btn = StatusBarItem.Button;
            btn.Image = NSImage.ImageNamed("NSQuickLookTemplate");
            btn.Highlight(false);

        }


        public void RemoveTray() {
            if (StatusBarItem == null)
                return;

            NSStatusBar.SystemStatusBar.RemoveStatusItem(StatusBarItem);
            StatusBarItem = null;
        }

        //size in pixels 44x44

        //color for tray themes
        //dark  - R255 G255 B255
        //light - R13 G17  B30

        //size for mac pictures
        //http://iconhandbook.co.uk/reference/chart/osx/


    }
}
