using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Window;

namespace MacArchitecture {
    public partial class ButtonViewController : NSViewController {
        public ButtonViewController(IntPtr handle) : base(handle) {
        
        }

        private AlertWindow _alertWindow = new AlertWindow();

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            #region row1
            btn_cancel.Activated += (sender, e) => 
                _alertWindow.ShowAlert("AlertWindow", "You clicled on CancelButton", "OK");

            lbl_cancel.StringValue = "You can activate this button if you will press Esc key";
            #endregion

            #region row2
            btn_default.Activated += (sender, e) => 
                _alertWindow.ShowAlert("AlertWindow", "You clicled on DefaultButton", "OK");

            lbl_default.StringValue = "You can activate this button if you will press Enter key";
            #endregion

            #region row3
            btn_link.SetLinkString("Go to google");
            btn_link.Activated += (sender, e) =>
                NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl("https://www.google.com"));

            #endregion
        }

        //todo write description to all  

        public override void ViewDidAppear() {
            base.ViewDidAppear();
            View.Window.Title = nameof(ButtonViewController);
        }
    }
}
