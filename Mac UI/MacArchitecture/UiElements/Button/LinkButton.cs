using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Button {
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


		public void SetLinkString(string title, bool smallTitlesize = false) {
			//AttributedTitle = new NSAttributedString(title, _linkDict);

			var attrStr = new NSMutableAttributedString(title);
			var range = new NSRange(0, attrStr.Length);
			//attrStr.AddAttribute(NSStringAttributeKey.Link, new NSUrl("http://www.google.com/"), range);
			attrStr.AddAttribute(NSStringAttributeKey.ForegroundColor, NSColor.Blue, range);
			attrStr.AddAttribute(NSStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);

			if(smallTitlesize)
				attrStr.AddAttribute(NSStringAttributeKey.Font, NSFont.SystemFontOfSize(NSFont.SmallSystemFontSize) , range);

			AttributedTitle = attrStr;
		}

    }
}
