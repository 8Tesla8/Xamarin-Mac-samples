using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Button {
    [Register(nameof(CancelButton))]
    internal class CancelButton : BaseButton {
        public CancelButton(IntPtr handle) : base(handle) {
            var alert = new NSAlert();
            alert.AddButton("OK");
            alert.AddButton("Cancel");

            KeyEquivalent = alert.Buttons[1].KeyEquivalent;
        }
    }
}
