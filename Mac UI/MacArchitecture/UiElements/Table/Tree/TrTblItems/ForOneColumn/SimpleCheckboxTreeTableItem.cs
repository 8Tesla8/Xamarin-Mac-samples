using System;
using AppKit;
using CoreGraphics;

namespace MacArchitecture.UiElements.Table.Tree.TrTblItems.OneColumn {
    internal class SimpleCheckboxTreeTableItem : SimpleTreeTableItem {

        public NSCellStateValue CheckboxState { get; set; }

        public override NSView CreateView(string columnIdentifier) {
            var tblCellView = new NSTableCellView();

            tblCellView.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
            //tblCellView.Identifier = CellIdentifier;
            tblCellView.TextField.BackgroundColor = NSColor.Clear;
            tblCellView.TextField.Bordered = false;

            tblCellView.TextField.Editable = Editable;
            tblCellView.TextField.Selectable = Selectable;

            tblCellView.AddSubview(tblCellView.TextField);

            var checkBox = new NSButton(new CGRect(5, 0, 16, 16));
            checkBox.SetButtonType(NSButtonType.Switch);
            checkBox.State = CheckboxState;
            checkBox.Enabled = false;
            tblCellView.AddSubview(checkBox);


            return tblCellView;
        }

        public override void InitView(NSView view, string columnIdentifier) {
            var tblCellView = (NSTableCellView)view;

            tblCellView.TextField.StringValue = Title;
        }
    }
}
