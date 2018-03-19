using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Tray;

namespace MacArchitecture{
	public partial class OtherViewController : NSViewController{
		public OtherViewController (IntPtr handle) : base (handle){
		}


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            //show here app info / chang lang / finger print/ 

            btn_tst.Activated += (sender, e) => {
                var tr = new Tray();

                var menu = new NSMenu();
                menu.AddItem(new NSMenuItem("MenuItem1"));
                menu.AddItem(new NSMenuItem("MenuItem2"));
                menu.AddItem(new NSMenuItem("MenuItem3"));

                tr.CreateTray(menu);
            };
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(OtherViewController);
        }
    }
}
