using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.SplitView {
    public class SplitViewDelegate : NSSplitViewDelegate {

        public event EventHandler DidResizeView;


        public override void DidResizeSubviews(NSNotification notification) {
            DidResizeView?.Invoke(notification.Object, EventArgs.Empty);
        }
    }
}
