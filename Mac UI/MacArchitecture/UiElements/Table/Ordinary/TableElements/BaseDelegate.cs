using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Simple.Delegate {
    internal abstract class BaseTableDelegate : NSTableViewDelegate {
        protected NSTableView _table;

        public string SelectedCellinfo { get; private set; } = string.Empty;

        public void InitTable(NSTableView table) {
            _table = table;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row) {

            NSTextField view = (NSTextField)tableView.MakeView("something", this);
            if (view == null) {
                view = new NSTextField();
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Editable = false;
                view.Selectable = false;

                view.LineBreakMode = NSLineBreakMode.TruncatingTail;
            }
            view.StringValue = GetDataForCell((int)row, tableColumn);
            view.ToolTip = view.StringValue;

            return view;
        }

        protected void SelectTF() {
            var rowIndex = _table.ClickedRow;
            var columnIndex = _table.ClickedColumn;

            if (rowIndex == -1 || columnIndex == -1) {
                SelectedCellinfo = string.Empty;
                return;
            }

            SelectedCellinfo = GetDataForCell((int)rowIndex, _table.TableColumns()[columnIndex]);

            //worked well everywhere except MainFilterTable
            //SelectedTextField = (NSTextField)_table.GetRowView(rowIndex, false).Subviews[columnIndex];
        }

        protected abstract string GetDataForCell(int row, NSTableColumn tableColumn);
    }
}
