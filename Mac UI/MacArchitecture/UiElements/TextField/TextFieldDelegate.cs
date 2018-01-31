using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.TextField {

    [Register(nameof(TextFieldDelegate))]
    public class TextFieldDelegate : NSTextFieldDelegate {

        public event EventHandler PressedEscKey;
        public event EventHandler PressedEnterKey;
       
        public event EventHandler EndEditing;
        public event EventHandler TextChanged;


        public override void Changed(NSNotification notification) {
            TextChanged?.Invoke(notification.Object, EventArgs.Empty);
        }


        public override bool DoCommandBySelector(NSControl control, NSTextView textView, ObjCRuntime.Selector commandSelector) {
            if (commandSelector.Name.Equals("cancelOperation:"))      //Esc
                PressedEscKey?.Invoke(control, EventArgs.Empty);
            
            else if (commandSelector.Name.Equals("insertNewline:"))   //Enter
                PressedEnterKey?.Invoke(control, EventArgs.Empty);
            
            else if (commandSelector.Name.Equals("insertLineBreak:")) //Ctrl + Enter
                return true;
            
            else if (commandSelector.Name.Equals("insertNewlineIgnoringFieldEditor:")) //Alt + Enter
                return true;

            return false;
        }


        public override void EditingEnded(NSNotification notification) {
            EndEditing?.Invoke(notification.Object, EventArgs.Empty);
        }
    }
}
