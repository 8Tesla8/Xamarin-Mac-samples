using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace MacArchitecture.UiElements.SplitView {
    [Register(nameof(SplitView))]
    internal class SplitView : NSSplitView {
        public SplitView(IntPtr handle) : base(handle) {

            var dlg = new SplitViewDelegate();
            Delegate = dlg;

            dlg.DidResizeView += (sender, e) => {
                if (MonitoringIndexSubview != -1) {
                    var subview = Subviews[MonitoringIndexSubview];

                    if (MonitoringSubviewHidden != subview.Hidden)
                        MonitoringSubviewHidden = subview.Hidden;

                    //orientation is vertical
                    if (!IsVertical && 
                        MinMonitoringSubviewHeight != -1 &&
                        subview.Frame.Height < MinMonitoringSubviewHeight) {
                        MonitoringSubviewHidden = true;

                    }
                    //orientation is horizontal
                    else if (IsVertical && 
                        MinMonitoringSubviewWidth != -1 &&
                        subview.Frame.Width < MinMonitoringSubviewWidth) {
                        MonitoringSubviewHidden = true;
                    }
                }
            };
        }

        private readonly nfloat _min = 50;

        //property IsVertical tell diveder position

        public nfloat MinMonitoringSubviewHeight { get; set; } = -1;
        public nfloat MinMonitoringSubviewWidth { get; set; } = -1;

        public nint MonitoringIndexSubview { get; set; } = -1;

        private bool _monitoringHiddenSubview = false;
        public bool MonitoringSubviewHidden {
            get {
                return _monitoringHiddenSubview;
            }
            set {
                _monitoringHiddenSubview = value;

                if (MonitoringIndexSubview == -1)
                    return;

                Subviews[MonitoringIndexSubview].Hidden = value;

                if (value) { //subview is hidding
                    var currentFrame = Subviews[MonitoringIndexSubview].Frame;

                    var newFrame = new CGRect(currentFrame.X, currentFrame.Y,
                                              currentFrame.Width, currentFrame.Height);

                    //orientation is vertical
                    if (!IsVertical && 
                        MinMonitoringSubviewHeight != -1 && 
                        currentFrame.Height <= MinMonitoringSubviewHeight) {

                        newFrame.Height = MinMonitoringSubviewHeight + _min;
                        Subviews[MonitoringIndexSubview].Frame = newFrame;
                    }
                    //orientation is horizontal
                    else if (IsVertical && 
                        MinMonitoringSubviewWidth != -1 &&
                        currentFrame.Width <= MinMonitoringSubviewWidth) {

                        newFrame.Width = MinMonitoringSubviewWidth + _min;
                        Subviews[MonitoringIndexSubview].Frame = newFrame;
                    }
                }

                HiddenSubviewIsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler HiddenSubviewIsChanged;
    }
}
