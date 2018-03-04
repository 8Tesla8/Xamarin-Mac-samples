using System;
using AppKit;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.UiElements.Table.Ordinary.TableElements {

    public class BaseTableDelegate : NSTableViewDelegate {
        protected IViewFactory _viewFactory;
        protected BaseTableDataSource _dataSource;

        public event EventHandler ChangeSelectedRow;

        public BaseTableDelegate(BaseTableDataSource dataSource) {
            _dataSource = dataSource;
            _viewFactory = Autofac.Injection.Resolve<IViewFactory>();
        }


        public override nfloat GetRowHeight(NSTableView tableView, nint row) {
            var tableRow = _dataSource.GetRow((int)row);
            return tableRow.RowHeight;
        }


        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row) {
            var tableRow = _dataSource.GetRow((int)row);
            var view = _viewFactory.CreateView(tableRow, tableColumn.Identifier);

            return view;
        }


        public override bool IsGroupRow(NSTableView tableView, nint row) {
            var tableRow = _dataSource.GetRow((int)row);
            return tableRow.GroupItem;
        }


        public override bool ShouldSelectRow(NSTableView tableView, nint row) {
            var tableRow = _dataSource.GetRow((int)row);
            return tableRow.Selectable;
        }


        public override void SelectionDidChange(Foundation.NSNotification notification) {
            ChangeSelectedRow?.Invoke(notification.Object, EventArgs.Empty);
        }
    }

    //internal abstract class BaseTableDelegate : NSTableViewDelegate {
    //    protected NSTableView _table;

    //    public string SelectedCellinfo { get; private set; } = string.Empty;

    //    public void InitTable(NSTableView table) {
    //        _table = table;
    //    }

    //    public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row) {

    //        NSTextField view = (NSTextField)tableView.MakeView("something", this);
    //        if (view == null) {
    //            view = new NSTextField();
    //            view.BackgroundColor = NSColor.Clear;
    //            view.Bordered = false;
    //            view.Editable = false;
    //            view.Selectable = false;

    //            view.LineBreakMode = NSLineBreakMode.TruncatingTail;
    //        }
    //        view.StringValue = GetDataForCell((int)row, tableColumn);
    //        view.ToolTip = view.StringValue;

    //        return view;
    //    }

    //    protected void SelectTF() {
    //        var rowIndex = _table.ClickedRow;
    //        var columnIndex = _table.ClickedColumn;

    //        if (rowIndex == -1 || columnIndex == -1) {
    //            SelectedCellinfo = string.Empty;
    //            return;
    //        }

    //        SelectedCellinfo = GetDataForCell((int)rowIndex, _table.TableColumns()[columnIndex]);

    //        //worked well everywhere except MainFilterTable
    //        //SelectedTextField = (NSTextField)_table.GetRowView(rowIndex, false).Subviews[columnIndex];
    //    }

    //    protected abstract string GetDataForCell(int row, NSTableColumn tableColumn);
    //}
}
