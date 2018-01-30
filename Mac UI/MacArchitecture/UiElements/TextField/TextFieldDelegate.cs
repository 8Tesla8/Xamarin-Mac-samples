using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.TextField {

    [Register(nameof(TextFieldDelegate))]
    public class TextFieldDelegate : NSTextFieldDelegate {
        public TextFieldDelegate(IntPtr handle) : base(handle) {
        }


        //todo impl replace event args
        public Action EscKeyAction;
        public Action EnterKeyAction;
       
        public Action EndEditing;
        public Action TextChanged;

        public override void Changed(NSNotification notification) {
            //base.EditingEnded(notification);
            TextChanged?.Invoke();
        }

        public override void EditingEnded(NSNotification notification) {
            //base.EditingEnded(notification);
            EndEditing?.Invoke();
        }

        public override bool DoCommandBySelector(NSControl control, NSTextView textView, ObjCRuntime.Selector commandSelector) {
            if (commandSelector.Name.Equals("cancelOperation:"))      //Esc
                EscKeyAction?.Invoke();
            else if (commandSelector.Name.Equals("insertNewline:"))   //Enter
                EnterKeyAction?.Invoke();
            else if (commandSelector.Name.Equals("insertLineBreak:")) //Ctrl + Enter
                return true;
            else if (commandSelector.Name.Equals("insertNewlineIgnoringFieldEditor:")) //Alt + Enter
                return true;

            return false;
        }
    }
}
