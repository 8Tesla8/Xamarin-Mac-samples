using System;
using System.Diagnostics;

namespace MacArchitecture.Utils {
    public class Startup {

        //another example
        //https://stackoverflow.com/questions/35339277/make-swift-cocoa-app-launch-on-startup-on-os-x-10-11


        public void AddAppToStartupList() {
            var args = String.Format(
                @"-e 'tell application ""System Events"" to make login item at end with properties {{path:""{0}"", hidden:false}}'", 
                @"/Applications/Lapp.app");

            var processInfo = new ProcessStartInfo { 
                FileName = @"/usr/bin/osascript", 
                Arguments = args, 
                CreateNoWindow = false, 
                UseShellExecute = false, 
                ErrorDialog = true, 
                WindowStyle = ProcessWindowStyle.Normal, 
                RedirectStandardError = true, 
                RedirectStandardInput = true, 
                RedirectStandardOutput = true, 
            };
            
            var prc = Process.Start(processInfo);
            prc.WaitForExit();
        }


        public void RemoveAppFromStartupList() {
            var args = String.Format(@"-e 'tell application ""System Events"" to delete login item ""{0}""'", 
                                     "Lapp"); //after, "Your App.app" 
           
            var processInfo = new ProcessStartInfo { 
                FileName = @"/usr/bin/osascript", 
                Arguments = args, 
                CreateNoWindow = false, 
                UseShellExecute = false, 
                ErrorDialog = true, 
                WindowStyle = ProcessWindowStyle.Normal, 
                RedirectStandardError = true, 
                RedirectStandardInput = true, 
                RedirectStandardOutput = true, 
            };
            
            var prc = Process.Start(processInfo);
            prc.WaitForExit();
        }
       
    }
}
