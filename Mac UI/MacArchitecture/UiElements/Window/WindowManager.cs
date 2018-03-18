using System;
using AppKit;

namespace MacArchitecture.UiElements.Window {
    public class WindowManager {
        public WindowManager() {
        }


        public void CreateModalWindow(NSWindow window) {
            window.WillClose += (sender, e) =>
                NSApplication.SharedApplication.StopModal();

            window.OrderFront(window);

            NSApplication.SharedApplication.RunModalForWindow(window);
        }


        public NSWindow GetCurrentWindow(){
            return NSApplication.SharedApplication.KeyWindow;
        }
    }
}
