using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Button {
    //в X-code необходимо создать ImageButton

    [Register(nameof(LinkButton))]
    internal class LinkButton : BaseButton {
        readonly NSMutableDictionary _linkDict;

        public LinkButton(IntPtr handle) : base(handle) {
            AddTrackingRect(Bounds, this, handle, true);

            _linkDict = new NSMutableDictionary() {
                { NSStringAttributeKey.ForegroundColor, NSColor.Blue },
                { NSStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single)}
            };
        }

        //SetLinkTitle
        public void SetLinkString(string text) {
            AttributedTitle = new NSAttributedString(text, _linkDict);
        }

        public override void ResetCursorRects() {
            base.ResetCursorRects();
        }

        public override void MouseEntered(NSEvent theEvent) {
            AddCursorRect(Bounds, NSCursor.PointingHandCursor);
            base.MouseEntered(theEvent);
        }

        public override void MouseExited(NSEvent theEvent) {
            RemoveCursorRect(Bounds, NSCursor.PointingHandCursor);
            base.MouseExited(theEvent);
        }

    }
}
