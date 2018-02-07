using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Notification;
using System.Collections.Generic;

namespace MacArchitecture {
    public partial class NotificationViewController : NSViewController {
        public NotificationViewController(IntPtr handle) : base(handle) {
        }

        private NotificationCreator _creator = new NotificationCreator();


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            lbl_info.StringValue =
@"Mac have 3 styles of notifications: 1) None 2) Banners(default) 3) Alert 
Alerts aren’t dismissed automatically, Banners dismiss automatically. 
If you want to use Alert style you need to go in Info.plist and add 
Property: NSUserNotificationAlertStyle  Type: String    Value: alert";

            btn_simple.Activated += (sender, e) =>
                _creator.CreateSimpleNotification(
                    "Simple notification", "Subtitle",
                    "Click here and message will gone",
                    true, "Top", "Bottom");

            btn_withButtons.Activated += (sender, e) => {
                var list = new List<(string, string, Action)>();

                for (int i = 0; i < 5; i++) {
                    var alert = new NSAlert() {
                        MessageText = "Identifier: A" + i,
                        InformativeText = "You chosen - Action " + i,
                        AlertStyle = NSAlertStyle.Informational,
                    };
                    list.Add(("A" + i, 
                              "Action " + i, 
                              () => alert.RunModal()));
                }

                _creator.CreateButtonsNotification(
                    "Notification with buttons",
                    "Subtitle",
                    "Choose action", "Hold",
                    list.ToArray());
            };

            btn_reply.Activated += (sender, e) => {
                _creator.CreateReplyNotification(
                    "Reply notification", "Subtitle",
                    "This message have reply button",
                    "Write here");
            };

            btn_timer.Activated += (sender, e) => {
                _creator.CreateTimerNotification(
                    "Timer notification", "Subtitle",
                    "Notification will stay for 5 sec",
                    5000);
            };

            btn_banner.Activated += (sender, e) => {
                _creator.CreateBannerNotification(
                "Banner", "Subtitle", "Just simple message.");

            };
        }
    }
}
