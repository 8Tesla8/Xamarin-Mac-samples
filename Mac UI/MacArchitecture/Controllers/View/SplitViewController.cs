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


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            splv_horizontal.MonitoringIndexSubview = 0;
            splv_horizontal.MinMonitoringSubviewWidth = 100;
            splv_horizontal.HiddenSubviewIsChanged += (sender, e) => {
                var splv = (SplitView)sender;

                if (splv.MonitoringSubviewHidden)
                    btn_horizontal.Title = _show + _rightPanel;
                else
                    btn_horizontal.Title = _hide + _rightPanel;
            };

            splv_vertical.MonitoringIndexSubview = 1;
            splv_vertical.MinMonitoringSubviewHeight = 100;
            splv_vertical.HiddenSubviewIsChanged += (sender, e) => {
                var splv = (SplitView)sender;

                if (splv.MonitoringSubviewHidden)
                    btn_vertical.Title = _show + _bottomPanel;
                else
                    btn_vertical.Title = _hide + _bottomPanel;
            };

            btn_vertical.Activated += (sender, e) => 
                splv_vertical.MonitoringSubviewHidden = !splv_vertical.MonitoringSubviewHidden;
            btn_horizontal.Activated += (sender, e) => 
                splv_horizontal.MonitoringSubviewHidden = !splv_horizontal.MonitoringSubviewHidden;

            btn_vertical.Title = _hide + _bottomPanel;
            btn_horizontal.Title = _hide + _rightPanel;
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(SplitViewController);
        }
    }
}
