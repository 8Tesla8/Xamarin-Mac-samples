using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.TextView.Delagate;

namespace MacArchitecture.UiElements.TextView {
    [Register(nameof(EditableTextView))]
    internal class EditableTextView : BaseTextView {
        private TextViewDelegate _textViewDelegate;

        public EditableTextView(IntPtr handle) : base(handle) {
            _textViewDelegate = new TextViewDelegate();
            Delegate = _textViewDelegate;
        }

        public void ClearUndoManager() {
            _textViewDelegate.UndoManager.RemoveAllActions();
        }
    }
}
