using System;
using AppKit;

namespace MacArchitecture.UiElements.Button {

    //This class is made for sharing logic which must be in all inherits classes
    //min width of all buttons must be 80

    abstract internal class BaseButton : NSButton {
        public BaseButton(IntPtr handle) : base(handle)  { }


    }
}
