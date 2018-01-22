using System;
using AppKit;
using MacArchitecture.BaseElements.Controller.View;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.BaseElements.Controller.Window {
    abstract internal class BaseWindowController : NSWindowController {
        public BaseWindowController(IntPtr handle) : base(handle) {
        }

        public abstract void Init();

        //не уверен насчет всего этого 
        //public override void KeyUp(NSEvent theEvent) {
        //    base.KeyUp(theEvent);
        //    if (KeyDefinder.EscKey(theEvent))
        //        CancelAction();
        //}

        public override void WindowDidLoad() {
            base.WindowDidLoad();

            Window.WillClose += (sender, e) => WindowClosing();
        }

        public virtual void WindowClosing() {
            var cntrlV = (BaseViewController)ContentViewController;
            cntrlV.WindowClosing();
        }
    }
}
