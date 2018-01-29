using System;
using Foundation;
using AppKit;

namespace MacArchitecture {
    public partial class MainViewController : NSViewController {
        public MainViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(MainViewController);
        }
    }
}
