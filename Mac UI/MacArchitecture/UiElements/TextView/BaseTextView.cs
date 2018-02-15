using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.TextView {
    [Register(nameof(BaseTextView))]
    public class BaseTextView : NSTextView {
        public BaseTextView(IntPtr handle) : base(handle) {

            //leave only Cut Copy Paste
            string[] menuIdentifiers = {
                "_NS:9",  //Cut
                "_NS:26", //Copy
                "_NS:32"  //Paste
            };

            //removing not useful menuItems
            foreach (var menuItem in Menu.ItemArray()) {

                bool leave = false;
                foreach (var identifier in menuIdentifiers) {
                    if (identifier == menuItem.Identifier)
                        leave = true;
                }

                if (!leave)
                    Menu.RemoveItem(menuItem);
            }


            var maxSize = new CoreGraphics.CGSize();
            maxSize.Height = nfloat.MaxValue;
            maxSize.Width = TextContainer.Size.Width;
            TextContainer.Size = maxSize;
        }

        public void HideFindPanel() {
            var actionSender = new NSMenuItem();
            var tag = ((long)NSTextFinderAction.HideFindInterface);
            actionSender.Tag = (nint)tag;

            PerformFindPanelAction(actionSender);
        }
    }
}
