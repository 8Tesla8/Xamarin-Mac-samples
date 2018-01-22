using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.TextView.Delagate{
    internal class TextViewDelegate : NSTextViewDelegate {
        public NSUndoManager UndoManager { get; private set; } = new NSUndoManager();

        public override NSUndoManager GetUndoManager(NSTextView view) {
            return UndoManager;
        }

        public event EventHandler TextChanged;
        public override void TextDidChange(NSNotification notification) {
            TextChanged?.Invoke(notification.Object, EventArgs.Empty);
        }
    }
}
