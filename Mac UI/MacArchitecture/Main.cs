using AppKit;
using MacArchitecture.Utils;

namespace MacArchitecture {
	static class MainClass {
		static void Main(string[] args) {

            //ErrorCatcher.InitCathcer();

			NSApplication.Init();
			NSApplication.Main(args);
		}
	}
}
