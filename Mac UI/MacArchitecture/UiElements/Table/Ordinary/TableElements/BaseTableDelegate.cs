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

            NSView view = null;

            if (tableRow.GroupItem)
                view = _viewFactory.CreateView(tableRow, string.Empty);
            else
                view = _viewFactory.CreateView(tableRow, tableColumn.Identifier);

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
}
