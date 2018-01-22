using System;
using AppKit;

namespace MacArchitecture.UiElements {
    public class AlertModel {
        public AlertModel() {
        }

        //public void CreateAlert(){
        //    var alert = new NSAlert();

        //    

        //    alert.Buttons;
        //}

        public static bool ShowConfrimAlert(string message, string okBtnTitle, string cancekBtnTitle) {
            var alert = CreateAlert(NSAlertStyle.Informational, message, okBtnTitle, cancekBtnTitle);

            var result = alert.RunModal();

            if (result == 1000) //ok click
                return true;

            return false; //cancel click
        }

        private static NSAlert CreateAlert(NSAlertStyle alertStyle, string message, string okBtnTitle, string cancekBtnTitle = null, NSView view = null) {
            var alert = new NSAlert() {
                AlertStyle = alertStyle,
                InformativeText = message,
                MessageText = "Alert title",
            };

            if (view != null)
                alert.AccessoryView = view;

            alert.AddButton(okBtnTitle);

            if (cancekBtnTitle != null) {
                alert.AddButton(cancekBtnTitle);

                //
                var alert1 = new NSAlert();
                alert1.AddButton("OK");
                alert1.AddButton("Cancel");
                //

                alert.Buttons[1].KeyEquivalent = alert1.Buttons[1].KeyEquivalent;
            }

            return alert;
        }
    }
}
