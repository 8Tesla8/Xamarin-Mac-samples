using System;
using AppKit;

namespace MacArchitecture.UiElements.Window {
    internal class AlertWindow {
        /// <summary>
        /// Shows the alert window with 1 choise.
        /// </summary>
        public bool ShowAlert(string title, string information, string okBtnText) {

            NSApplication.SharedApplication.InvokeOnMainThread(() => {
                var alert = CreateAlert(title, information, okBtnText, null);
                alert.RunModal();
            });

            return false;
        }


        /// <summary>
        /// Shows the confirm window with 2 choises.
        /// </summary>
        public bool ShowAlert(string title, string information, string okBtnText, string canselBtnText) {
            nint result = 0;

            NSApplication.SharedApplication.InvokeOnMainThread(() => {
                var alert = CreateAlert(title, information, okBtnText, canselBtnText);
                result = alert.RunModal();
            });

            if (result == 1000)
                return true;

            return false;
        }


        public bool ShowConfirm(string title, string information, string okBtnText, string canselBtnText) {
            return ShowAlert(title, information, okBtnText, canselBtnText);
        }


        private NSAlert CreateAlert(string title, string information, string okBtnText, string canselBtnText) {
            var alertStyle = NSAlertStyle.Critical;

            if (!string.IsNullOrEmpty(canselBtnText)) {
                alertStyle = NSAlertStyle.Informational;
            }

            var alert = new NSAlert() {
                MessageText = title,
                InformativeText = information,
                AlertStyle = alertStyle,
            };

            switch (alertStyle) {
                case NSAlertStyle.Critical:
                    alert.AddButton(okBtnText);     //1000
                    break;

                case NSAlertStyle.Informational:
                    alert.AddButton(okBtnText);     //1000
                    alert.AddButton(canselBtnText); //1001

                    var alert1 = new NSAlert();
                    alert1.AddButton("OK");
                    alert1.AddButton("Cancel");

                    alert.Buttons[1].KeyEquivalent = alert1.Buttons[1].KeyEquivalent;
                    break;
            }

            return alert;
        }
    }
}
