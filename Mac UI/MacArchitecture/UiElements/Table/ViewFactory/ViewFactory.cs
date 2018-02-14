using System;
using AppKit;
using CoreGraphics;
using MacArchitecture.UiElements.Table.Ordinary;

namespace MacArchitecture.UiElements.Table.ViewFactory {
    public class ViewFactory : IViewFactory {

        public NSView CreateView(ITableItem tableItem, string columnIdentifier) {

            var itemValue = tableItem.GetValue(columnIdentifier);

            var typeCellView = tableItem.GetTypeCellView(columnIdentifier);

            switch (typeCellView) {
                
                case TypeCellView.TextField:
                    var tf = new NSTextField();
                    tf.BackgroundColor = NSColor.Clear;
                    tf.Bordered = false;

                    tf.Editable = tableItem.Editable;
                    tf.Selectable = tableItem.Selectable;

                    tf.LineBreakMode = NSLineBreakMode.TruncatingTail;

                    tf.StringValue = itemValue.Text;
                    tf.ToolTip = itemValue.Tooltip;

                    return tf;

                case TypeCellView.Checkbox:
                    var tblCellView = new NSTableCellView();

                    tblCellView.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
                    //tblCellView.Identifier = CellIdentifier;
                    tblCellView.TextField.BackgroundColor = NSColor.Clear;
                    tblCellView.TextField.Bordered = false;

                    tblCellView.TextField.Editable = tableItem.Editable;
                    tblCellView.TextField.Selectable = tableItem.Selectable;

                    tblCellView.TextField.StringValue = itemValue.Text;
                    tblCellView.TextField.ToolTip = itemValue.Tooltip;

                    tblCellView.AddSubview(tblCellView.TextField);

                    var checkBox = new NSButton(new CGRect(5, 0, 16, 16));
                    checkBox.SetButtonType(NSButtonType.Switch);

                    //todo impl
                    //think about it state
                    //checkBox.State = CheckboxState;

                    checkBox.Enabled = true;

                    tblCellView.AddSubview(checkBox);

                    return tblCellView;

                case TypeCellView.TextView:
                    var txtv = new NSTextView();

                    txtv.BackgroundColor = NSColor.Clear;
                    txtv.Selectable = tableItem.Selectable;
                    txtv.Editable = tableItem.Editable;

                    txtv.Value = itemValue.Text;
                    txtv.ToolTip = itemValue.Tooltip;

                    return txtv;
            }


            throw new System.NotImplementedException("Do not have implementation");
        }
    }
}
