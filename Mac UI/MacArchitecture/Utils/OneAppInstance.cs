using System;
using AppKit;
using Foundation;

namespace MacArchitecture.Utils {
    public static class OneAppInstance {

        //should call this method in AppDelegate
        public static void CheckAppInstance() {
            //run one instanse of app
            var bundleId = (NSString)NSBundle.MainBundle.BundleIdentifier;
            var launcedApps = NSWorkspace.SharedWorkspace.LaunchedApplications;
            var countSameApp = 0;

            foreach (var app in launcedApps) {
                var appBundleId = (NSString)app["NSApplicationBundleIdentifier"];

                if (bundleId.Equals(appBundleId))
                    ++countSameApp;
            }

            if (countSameApp > 1)
                NSApplication.SharedApplication.Terminate(
                    (AppDelegate)NSApplication.SharedApplication.Delegate);
        }
    }
}
