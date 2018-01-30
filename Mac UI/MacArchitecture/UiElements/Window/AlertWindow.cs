using System;
using AppKit;

namespace MacArchitecture.UiElements.Window {
    internal class AlertWindow {

        public bool ShowAlert(string title, string information, string okBtnText, string canselBtnText = null) {
            return ShowWindow(NSAlertStyle.Warning, title, information, okBtnText, canselBtnText);
        }


        public bool ShowConfirm(string title, string information, string okBtnText, string canselBtnText = null) {
            return ShowWindow(NSAlertStyle.Informational, title, information, okBtnText, canselBtnText);
        }


        public bool ShowWindow(NSAlertStyle alertStyle, string title, string information, string okBtnText, string canselBtnText = null) {
            nint result = 0;

            NSApplication.SharedApplication.InvokeOnMainThread(() => {
                var alert = CreateAlert(alertStyle, title, information, okBtnText, canselBtnText);
                result = alert.RunModal();
            });

            if (result == 1000)
                return true;

            return false;
        }


        private NSAlert CreateAlert(NSAlertStyle alertStyle, string title, string information, string okBtnText, string canselBtnText) {

            var alert = new NSAlert() {
                MessageText = title,
                InformativeText = information,
                AlertStyle = alertStyle,
            };

            alert.AddButton(okBtnText); //10001

            if (!string.IsNullOrEmpty(canselBtnText)) {
                alert.AddButton(canselBtnText); //1001

                var alert1 = new NSAlert();
                alert1.AddButton("OK");
                alert1.AddButton("Cancel");

                alert.Buttons[1].KeyEquivalent = alert1.Buttons[1].KeyEquivalent;                
            }

            return alert;
        }
    }
}
