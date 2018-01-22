using System.Collections.Generic;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree.TrTblItems {
    internal class MultiColumnsTreeTableItem : TreeTableItem {
        public bool NeedExpand { get; set; }


        // columnIdentifier, value 
        public virtual Dictionary<string, string> Title { get; set; }


        public override bool Expandable() {
            if (Children == null)
                return false;
            else
                return Children.Count > 0;
        }


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
            tf.StringValue = Title[columnIdentifier];
            tf.ToolTip = Title[columnIdentifier];
        }
    }
}