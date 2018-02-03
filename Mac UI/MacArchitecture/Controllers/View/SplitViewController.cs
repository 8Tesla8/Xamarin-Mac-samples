using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.SplitView;

namespace MacArchitecture {
    public partial class SplitViewController : NSViewController {
        public SplitViewController(IntPtr handle) : base(handle) {
        }

        private string _rightPanel = " right panel";
        private string _bottomPanel = " bottom panel";
        private string _hide = "Hide";
        private string _show = "Show";


        private bool _bottomPanelIsHiden;
        private bool BottomPanelIsHiden {
            get {
                return _bottomPanelIsHiden;
            }
            set {
                if (value)
                    btn_vertical.Title = _show + _bottomPanel;
                else
                    btn_vertical.Title = _hide + _bottomPanel;

                _bottomPanelIsHiden = value;
            }
        }

        private bool _rightPanelIsHiden;
        private bool RightPanelIsHiden {
            get {
                return _rightPanelIsHiden;
            }
            set {
                if (value)
                    btn_horizontal.Title = _show + _rightPanel;
                else
                    btn_horizontal.Title = _hide + _rightPanel;

                _rightPanelIsHiden = value;
            }
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            var vertDlg = new SplitViewDelegate();
            vertDlg.DidResizeView += (sender, e) => {
                var bottomPanel = splv_vertical.Subviews[1];

                if (BottomPanelIsHiden != bottomPanel.Hidden)
                    BottomPanelIsHiden = bottomPanel.Hidden;

                if (bottomPanel.Frame.Height < 100) {
                    BottomPanelIsHiden = true;
                    bottomPanel.Hidden = true;
                }
            };
            splv_vertical.Delegate = vertDlg;

            var horzDlg = new SplitViewDelegate();
            horzDlg.DidResizeView += (sender, e) => {
                var rightPanel = splv_horizontal.Subviews[0];

                if (RightPanelIsHiden != rightPanel.Hidden)
                    RightPanelIsHiden = rightPanel.Hidden;

                if (rightPanel.Frame.Width < 100) {
                    RightPanelIsHiden = true;
                    rightPanel.Hidden = true;
                }
            };
            splv_horizontal.Delegate = horzDlg;


            btn_vertical.Activated += (sender, e) => {
                var bottomPanel = splv_vertical.Subviews[1];

                BottomPanelIsHiden = !BottomPanelIsHiden;
                bottomPanel.Hidden = BottomPanelIsHiden;
            };
            btn_horizontal.Activated += (sender, e) => {
                var rightPanel = splv_horizontal.Subviews[0];

                RightPanelIsHiden = !RightPanelIsHiden;
                rightPanel.Hidden = RightPanelIsHiden;
            };


            btn_vertical.Title = _hide + _bottomPanel;
            btn_horizontal.Title = _hide + _rightPanel;
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(SplitViewController);
        }
    }
}
