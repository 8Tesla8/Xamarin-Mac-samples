using AppKit;
using Foundation;

namespace MacArchitecture {
	[Register("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate {
		public AppDelegate() {
		}


		public override void DidFinishLaunching(NSNotification notification) {
			// Insert code here to initialize your application
		}


		public override void WillTerminate(NSNotification notification) {
			// Insert code here to tear down your application
		}


        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) {
            return true;
        }


        public void CloseApp() {
            NSApplication.SharedApplication.Terminate(this);
        }


        public static AppDelegate GetAppDelegate() {
            return (AppDelegate)NSApplication.SharedApplication.Delegate;
        }
	}
}
