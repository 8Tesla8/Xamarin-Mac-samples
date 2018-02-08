using System;
using AppKit;

namespace MacArchitecture.UiElements.Utils {
    public static class DockTileIndicator {

        private static readonly NSDockTile _dockTile;


        static DockTileIndicator() {
            _dockTile = NSApplication.SharedApplication.DockTile;

            //NSApplication.SharedApplication.ApplicationIconImage
            //NSApplication.SharedApplication.ApplicationDockMenu
        }

 
        //show indicator should use in AppDelegate
        //public override void DidBecomeActive(NSNotification notification) {
        //    DockTileIndicator.ShowIndicator = false;
        //}
        //public override void DidResignActive(NSNotification notification) {
        //    DockTileIndicator.ShowIndicator = true;
        //}


        private static bool _showIndicator;
        public static bool ShowIndicator {
            get {
                return _showIndicator;
            }
            set {
                if (value)
                    _dockTile.BadgeLabel = _prevBadgeText;
                else
                    _dockTile.BadgeLabel = null;

                _showIndicator = value;
            }
        }


        private static string _prevBadgeText;
        public static void SetText(string badgeText) {
            _prevBadgeText = badgeText;

            if (ShowIndicator)
                _dockTile.BadgeLabel = badgeText;
            else
                _dockTile.BadgeLabel = null;

            //var view = _dockTile.ContentView;
        }
    }
}
