using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree.TreeTableItems.OneColumn {
    internal class SimpleTextViewTreeTableItem : SimpleTreeTableItem {
        public int CountStandartRows { get; set; }

        //override methods
        public override nint GetChildrenCount() {
            return Children.Count;
        }
        public override ITreeTableItem GetChild(nint childIndex) {
            return Children[(int)childIndex];
        }
        //

        //work with view
        public override NSView CreateView(string columnIdentifier) {
            var txtv = new NSTextView();

            txtv.BackgroundColor = NSColor.Clear;
            txtv.Selectable = false;
            txtv.Editable = Editable;

            return txtv;
        }
        public override void InitView(NSView view, string columnIdentifier) {
            var txtv = (NSTextView)view;
            txtv.Value = Title;
        }
        //

        public override nfloat GetRowHeight() {
            if (CountStandartRows > 0)
                return _standartRowHeight * CountStandartRows;

            return _standartRowHeight;
        }
    }
}
