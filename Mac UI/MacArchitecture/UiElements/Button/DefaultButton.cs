using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Button {
 
    //кнопка которая красится в синий и реагирует на нажатие Enter
    [Register(nameof(DefaultButton))]
    internal class DefaultButton : BaseButton {
        public DefaultButton(IntPtr handle) : base(handle) {
            BezelStyle = NSBezelStyle.Rounded;
            KeyEquivalent = "\r";
        }
    }

    //width must be 80
}
