using System;
using Foundation;

namespace MacArchitecture.Utils {
    public class AppInfo {

        public string BuildVersion { get; private set; }
        public string AppVersion { get; private set; }


        public AppInfo() {
            //take infrormation from Info.plist

            //get build version
            var builVers = NSBundle.MainBundle.InfoDictionary["CFBundleVersion"];

            //get version
            var version = NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"];

            BuildVersion = (NSString)builVers;
            AppVersion = (NSString)version;
        }
    }
}
