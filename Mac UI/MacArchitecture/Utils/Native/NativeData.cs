using System;
using Foundation;

namespace MacArchitecture.Utils {
    public class NativeData {
        public NativeData() {
        }


        public NSData  CreateNSData(string str) {
            //var str = "my string";
            var macStr = new NSString(str);
            return macStr.Encode(NSStringEncoding.Unicode);
        }
    }
}
