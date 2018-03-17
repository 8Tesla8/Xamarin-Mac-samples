using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using Foundation;

namespace MacArchitecture.Utils {
    internal class FingerPrintService {
        public string Hardware { get; private set; }
        public string SerialNumber { get; private set; }
        public string CurrentUser { get; private set; }


        public FingerPrintService() {

            SerialNumber = GetSerialNumber();
            Hardware = GetHardware();
            CurrentUser = GetCurrentUser();
        }

        #region DLL Import
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern uint IOServiceGetMatchingService(uint masterPort, IntPtr matching);
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern IntPtr IOServiceMatching(string s);
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern IntPtr IORegistryEntryCreateCFProperty(uint entry, IntPtr key, IntPtr allocator, uint options);
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        static extern int IOObjectRelease(uint o);
        #endregion


        private string GetSerialNumber() {
            var serial = string.Empty;
            var platformExpert = IOServiceGetMatchingService(0, IOServiceMatching("IOPlatformExpertDevice"));
            if (platformExpert != 0) {
                var key = (NSString)"IOPlatformSerialNumber";
                var serialNumber = IORegistryEntryCreateCFProperty(platformExpert, key.Handle, IntPtr.Zero, 0);
                if (serialNumber != IntPtr.Zero) {
                    serial = NSString.FromHandle(serialNumber);
                }
                IOObjectRelease(platformExpert);
            }

            return serial;
        }


        private string GetHardware() {
            var args = new string[] { "-rd1", "-c", "IOPlatformExpertDevice", "|", "grep", "model" };
            var task = new NSTask();
            task.LaunchPath = @"/usr/sbin/ioreg";
            task.Arguments = args;
            var pipe = new NSPipe();
            task.StandardOutput = pipe;
            task.Launch();
            var args2 = new string[] { "/IOPlatformUUID/ { split($0, line, \"\\\"\"); printf(\"%s\\n\", line[4]); }" };
            var task2 = new NSTask();
            task2.LaunchPath = @"/usr/bin/awk";
            task2.Arguments = args2;
            var pipe2 = new NSPipe();
            task2.StandardInput = pipe;
            task2.StandardOutput = pipe2;
            var fileHandle2 = pipe2.ReadHandle;
            task2.Launch();
            var data = fileHandle2.ReadDataToEndOfFile();
            var uuid = NSString.FromData(data, NSStringEncoding.UTF8);
            return uuid.ToString().Replace("\n", "");
        }


        private string GetCurrentUser() {
            return Environment.UserName;
        }
    }
}
