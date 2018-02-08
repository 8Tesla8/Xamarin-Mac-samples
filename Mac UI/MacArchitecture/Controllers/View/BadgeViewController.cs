using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture {
    public partial class BadgeViewController : NSViewController {
        public BadgeViewController(IntPtr handle) : base(handle) {
        }

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
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(BadgeViewController);
        }
    }
}
