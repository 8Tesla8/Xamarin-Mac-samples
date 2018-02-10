using System;
using Foundation;

namespace MacArchitecture.UiElements.TextView {
    [Register(nameof(HtmlTextView))]
    public class HtmlTextView : BaseTextView {
        public HtmlTextView(IntPtr handle) : base(handle) {
            DisplaysLinkToolTips = false;
        }

        public void SetHtmlString(string text) {
            NSDictionary dictionary;
            NSError error;

            var atts = new NSAttributedStringDocumentAttributes {
                DocumentType = NSDocumentType.HTML,
                StringEncoding = NSStringEncoding.UTF8
            };

            var htmlText = string.Concat("<font face=\"Helvetica\" style=\"font-size:10pt\"", text, "</font>");

            TextStorage.SetString(new NSAttributedString(NSData.FromString(htmlText), atts, out dictionary, out error));

            RemoveAllToolTips();
        }
    }
}
