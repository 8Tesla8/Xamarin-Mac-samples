using System;
using Foundation;

namespace MacArchitecture.Utils {
    public class ConsoleParameters {
        
        //https://forums.xamarin.com/discussion/comment/178452#Comment_178452


        public void RunConsoleParameters(string[] consoleParams, string pathToApp) {
            //string[] args = new string[] { "-p", " sp" };
            string[] args = consoleParams;

            NSTask task = new NSTask();

            //path to app
            //task.LaunchPath = "/Applications/MyApp.app/Contents/MacOS/MyApp";
            task.LaunchPath = pathToApp;

            task.Arguments = args;

            NSPipe pipe = new NSPipe();
            task.StandardOutput = pipe;
            task.Launch();
        }
    }
}
