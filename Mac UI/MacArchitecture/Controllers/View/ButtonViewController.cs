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

            #region CancelButton

            btn_cancel.Activated += (sender, e) =>
                _alertWindow.ShowAlert("AlertWindow", "You clicled on CancelButton", "OK");

            lbl_cancel.StringValue = "You can activate this button if you will press Esc key";

            #endregion

            #region DefaultButton

            btn_default.Activated += (sender, e) =>
                _alertWindow.ShowAlert("AlertWindow", "You clicled on DefaultButton", "OK");

            lbl_default.StringValue = "You can activate this button if you will press Enter key";
            #endregion

            #region LinkButton

            btn_link.SetLinkString("Go to google");
            btn_link.Activated += (sender, e) =>
                NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl("https://www.google.com"));

            lbl_link.StringValue = "LinkButton look like a link, it also open link after click";

            #endregion

            #region StateButton

            lbl_state.StringValue = "StateButton change image, title and tooltip after every click";

            btn_state.SetStateTitles("Folder", "Smart folder");
            btn_state.SetStateImages("NSFolder", "NSFolderSmart");
            btn_state.SetStateTooltips("NSFolder image", "NSFolderSmart image");

            btn_state.Activated += (sender, e) => 
                btn_state.BtnState = !btn_state.BtnState;

            //pragramaticly activate button
            btn_state.PerformClick(this); 

            #endregion
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(ButtonViewController);
        }
    }
}
