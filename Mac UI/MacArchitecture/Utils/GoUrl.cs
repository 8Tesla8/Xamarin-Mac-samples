using System;
using AppKit;
using Foundation;

namespace MacArchitecture.Utils {
    public class GoUrl {
        public GoUrl() {
        }

        //open url in default browser
        public void OpenUrlInBrowser(string url) {
            //NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl("http://google.com"));

            NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(url));
        }
    }
}
