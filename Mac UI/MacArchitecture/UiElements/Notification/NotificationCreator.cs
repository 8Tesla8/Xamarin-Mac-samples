using System;
using System.Collections.Generic;
using System.Threading;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Notification {
    public class NotificationCreator {


        public void CreateBannerNotification(string title, string subtitle, string text) {
            CreateSimpleNotification(title, subtitle, text, false, string.Empty, string.Empty);
        }


        public void CreateButtonsNotification(string title, string subtitle, string text, string bottomBtnTitle, 
                                              (string Identifier, string Title, Action Action)[] additionalActions) {
            
            var notification = CreateNotification(title, subtitle, text);
            notification.HasActionButton = true;
            notification.ActionButtonTitle = bottomBtnTitle;     //bottom button

            var actionList = new List<NSUserNotificationAction>();

            foreach (var notifiAction in additionalActions) {
                var notificationAction = NSUserNotificationAction
                    .GetAction(notifiAction.Identifier, notifiAction.Title);

                actionList.Add(notificationAction);
            }

            notification.AdditionalActions = actionList.ToArray();

            var defaultNotiCenter = CreateNotificationCentre();
            defaultNotiCenter.DidActivateNotification += (sender, e) => {
                if (e.Notification.ActivationType == NSUserNotificationActivationType.AdditionalActionClicked) {

                    var selectedNotificationIdentifier = e.Notification.AdditionalActivationAction.Identifier;

                    foreach (var notifiAction in additionalActions) {
                        if (notifiAction.Identifier == selectedNotificationIdentifier)
                            notifiAction.Action();
                    }
                }
            };

            defaultNotiCenter.DeliverNotification(notification);
        }


        public void CreateTimerNotification(string title, string subtitle, string text, int showDuration) {
            var notification = CreateNotification(title, subtitle, text);

            var defaultNotiCenter = CreateNotificationCentre();
            defaultNotiCenter.DidDeliverNotification += (sender, e) => {
                var timer = new Timer((state) => {
                    defaultNotiCenter.RemoveDeliveredNotification(notification);
                }, null, showDuration, 0);
            };

            defaultNotiCenter.DeliverNotification(notification);
        }


        public void CreateReplyNotification(string title, string subtitle, string text, string replyText) {
            var notification = CreateNotification(title, subtitle, text);

            notification.HasReplyButton = true;
            notification.ResponsePlaceholder = replyText;

            var defaultNotiCenter = CreateNotificationCentre();
            defaultNotiCenter.DidActivateNotification += (sender, e) => {
                if (e.Notification.ActivationType == NSUserNotificationActivationType.Replied) {

                    var response = e.Notification.Response.Value;

                    var alert = new NSAlert() {
                        MessageText = "Response",
                        InformativeText = response,
                        AlertStyle = NSAlertStyle.Informational,
                    };
                    alert.RunModal();
                }
            };


            defaultNotiCenter.DeliverNotification(notification);
        }


        public void CreateSimpleNotification(string title, string subtitle, string text, bool hasButtons, string topBtnTitle, string bottomBtnTitle) {
            var notification = CreateNotification(title, subtitle, text);

            notification.HasActionButton = hasButtons;
            notification.OtherButtonTitle = topBtnTitle;         //top button
            notification.ActionButtonTitle = bottomBtnTitle;     //bottom button

            var defaultNotiCenter = CreateNotificationCentre();
            defaultNotiCenter.DidActivateNotification += (sender, e) => {
                if (e.Notification.ActivationType == NSUserNotificationActivationType.ActionButtonClicked) {
                    //bottom button is clicked
                }
                else if (e.Notification.ActivationType == NSUserNotificationActivationType.ContentsClicked) {
                    defaultNotiCenter.RemoveDeliveredNotification(notification);
                }
            };

            defaultNotiCenter.DeliverNotification(notification);
        }


        private NSUserNotification CreateNotification(string title, string subtitle, string text) {
            var notification = new NSUserNotification();
            notification.Title = title;
            notification.Subtitle = subtitle;
            notification.InformativeText = text;
            notification.SoundName = "NSUserNotificationDefaultSoundName";

            //also you can use 
            //notification.Identifier;
            //notification.ContentImage

            return notification;
        }


        private NSUserNotificationCenter CreateNotificationCentre() {
            var defaultNotiCenter = NSUserNotificationCenter.DefaultUserNotificationCenter;
            defaultNotiCenter.ShouldPresentNotification = (c, n) => true;
            return defaultNotiCenter;
        }
    }
}
