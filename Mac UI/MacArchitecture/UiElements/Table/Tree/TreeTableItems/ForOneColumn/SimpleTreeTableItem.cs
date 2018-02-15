using System;
using AppKit;
using Foundation;
using System.Collections.Generic;

namespace MacArchitecture.UiElements.Table.Tree.TreeTableItems.OneColumn {
    // can be a group item
    internal class SimpleTreeTableItem : TreeTableItem {
        public string Title { get; set; }
        public bool Editable { get; set; }
        public bool Selectable { get; set; }


        public override NSView CreateView(string columnIdentifier) {
            var tf = new NSTextField();
            tf.BackgroundColor = NSColor.Clear;
            tf.Bordered = false;

            tf.Editable = IsTextEditable;
            tf.Selectable = IsTextSelectable;

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
