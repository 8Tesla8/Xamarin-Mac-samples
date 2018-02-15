using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.Tree.TreeTableItems;
using MacArchitecture.UiElements.UI.Table.Tree;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.UiElements.Table.Tree.TreeTableElements {
    internal class BaseTreeTableDelegate : NSOutlineViewDelegate {
        private bool _rowAlwaysMustBeSelected;

        public event EventHandler ChangeSelectedRow;

        public BaseTreeTableDelegate() { }
        public BaseTreeTableDelegate(BaseTreeTable table, bool rowAlwaysMustBeSelected = false) { //not for Multiselect
            table.IgnoresMultiClick = true;

            _rowAlwaysMustBeSelected = rowAlwaysMustBeSelected;

            if (_rowAlwaysMustBeSelected) {
                table.WasKeyDown += (sender, e) => {
                    var keyEvent = (NSEvent)sender;

                    //todo impl
                    //if can not select item +2 
                    //or foreach item at row

                    //if can multi select do not run algorithm

                    if (KeyDefinder.UpKey(keyEvent) && table.SelectedRow - 1 >= 0)
                        table.SelectRow(table.SelectedRow - 1, false);
                    else if (KeyDefinder.DownKey(keyEvent) && table.SelectedRow + 1 <= table.RowCount)
                        table.SelectRow(table.SelectedRow + 1, false);
                };
            }
        }


        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item) {

            var baseTreeTableItem = (ITreeTableItem)item;

            NSView view = outlineView.MakeView("RowView", this);
            if (view == null) {
                if (tableColumn == null)
                    view = baseTreeTableItem.CreateView(null);
                else
                    view = baseTreeTableItem.CreateView(tableColumn.Identifier);
            }

            if (tableColumn == null)
                baseTreeTableItem.InitView(view, null);
            else
                baseTreeTableItem.InitView(view, tableColumn.Identifier);

            return view;
        }


        public override nfloat GetRowHeight(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableItem)item;
            return baseTreeTableItem.GetRowHeight();
        }


        public override bool IsGroupItem(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableItem)item;
            return baseTreeTableItem.IsGroupItem();
        }


        public override void SelectionDidChange(NSNotification notification) {
            ChangeSelectedRow?.Invoke(notification.Object, EventArgs.Empty);

            //do not call base implementation
            //base.SelectionDidChange(notification);
        }


        public override bool SelectionShouldChange(NSOutlineView outlineView) {
            if (_rowAlwaysMustBeSelected && outlineView.ClickedRow == -1)
                return false;

            return true;

            //do not call base implementation
            //return base.SelectionShouldChange(outlineView);
        }


        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableItem)item;
            return baseTreeTableItem.CanSelectItem();

            //do not call base implementation
            //base.ShouldSelectItem(notification);
        }
    }
}
