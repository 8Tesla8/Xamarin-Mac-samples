using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Tray;
using MacArchitecture.Utils;

namespace MacArchitecture{
	public partial class OtherViewController : NSViewController{
		public OtherViewController (IntPtr handle) : base (handle){
		}


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            var appInfo = new AppInfo();

            lbl_buildVersion.StringValue = "Build version: " + appInfo.BuildVersion;
            lbl_appVersion.StringValue = "App version: " + appInfo.AppVersion;

            var fingerPrint = new FingerPrintService();

            lbl_currentUser.StringValue = "Current user: " + fingerPrint.CurrentUser;
            lbl_serialNumber.StringValue = "Serial number: " + fingerPrint.SerialNumber;
            lbl_osVersion.StringValue = "OS version: " + fingerPrint.OsVersion;

            var langService = new LanguageService();

            lbl_localization.StringValue = langService.GetLocalizedString("en", "Test_Title");
            sgm.SetSelected(true, 0);

            sgm.Activated += (sender, e) => {
                switch(sgm.SelectedSegment){
                    case 0: 
                        lbl_localization.StringValue = langService.GetLocalizedString("en", "Test_Title");
                        break;

                    case 1:
                        lbl_localization.StringValue = langService.GetLocalizedString("ru", "Test_Title");
                        break;
                }
            };
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(OtherViewController);
        }
    }
}
