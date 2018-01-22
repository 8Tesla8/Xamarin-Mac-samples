using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree.TrTblItems.OneColumn {
    internal class SimpleTextFieldTreeTableItem : SimpleTreeTableItem {

        public override NSView CreateView(string columnIdentifier) {
            var tf = new NSTextField();
            tf.BackgroundColor = NSColor.Clear;
            tf.Bordered = false;

            tf.Editable = Editable;
            tf.Selectable = Selectable;

            tf.LineBreakMode = NSLineBreakMode.TruncatingTail;

            return tf;
        }
        public override void InitView(NSView view, string columnIdentifier) {
            var tf = (NSTextField)view;
            tf.StringValue = Title;
            tf.ToolTip = Title;
        }
    }
}
