using AppKit;
using System;

namespace MacArchitecture.BaseElements.Controller.View {
    abstract internal class BaseViewController : NSViewController {
        public BaseViewController(IntPtr handle) : base(handle) { }

        //public abstract void Init();

        //public override void ViewDidAppear() {
        //    base.ViewDidAppear();

        //    View.Window.MakeKeyAndOrderFront(this);
        //}

        //public abstract void CancelAction();

        //public virtual void WindowClosing() { }

        //public void CloseWindow() {
        //    View.Window.PerformClose(this);
        //}
    }
}
