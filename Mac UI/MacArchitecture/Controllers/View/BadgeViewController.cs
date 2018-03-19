using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Utils;
using MacArchitecture.UiElements.Tray;

namespace MacArchitecture {
    public partial class BadgeViewController : NSViewController {
        public BadgeViewController(IntPtr handle) : base(handle) {
        }

        private Tray _tray = new Tray();

        private int _number = 1;


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            DockTileIndicator.ShowIndicator = true;
            DockTileIndicator.SetText(_number.ToString());

            ckb_showBadge.AllowsMixedState = false;
            ckb_showBadge.Activated += (sender, e) => {
                if (ckb_showBadge.State == NSCellStateValue.On)
                    DockTileIndicator.ShowIndicator = true;

                else if (ckb_showBadge.State == NSCellStateValue.Off)
                    DockTileIndicator.ShowIndicator = false;
            };

            btn_addBadge.Activated += (sender, e) => {
                ++_number;
                DockTileIndicator.SetText(_number.ToString());
            };

            btn_clear.Activated += (sender, e) => 
                DockTileIndicator.SetText(null);


            //tray
            btn_showTray.Activated += (sender, e) => {
                var menu = new NSMenu();
                menu.AddItem(new NSMenuItem("MenuItem1"));
                menu.AddItem(new NSMenuItem("MenuItem2"));
                menu.AddItem(new NSMenuItem("MenuItem3"));

                _tray.CreateTray(menu);

                btn_showTray.Enabled = false;
                btn_hideTray.Enabled = true;
            };

            btn_hideTray.Activated += (sender, e) => {
                _tray.RemoveTray();

                btn_showTray.Enabled = true;
                btn_hideTray.Enabled = false;
            };

            btn_hideTray.Enabled = false;
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(BadgeViewController);
        }
    }
}
