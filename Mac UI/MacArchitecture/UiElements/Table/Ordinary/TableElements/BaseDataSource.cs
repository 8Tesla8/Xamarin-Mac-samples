using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Simple.DataSource {
    internal abstract class BaseTableDataSource : NSTableViewDataSource {
        protected NSTableView _table;

        public Action RowsAdded;

        public void InitTable(NSTableView table) {
            _table = table;
        }

        //public abstract List<BaseRowModel> GetData();

        public abstract void ClearDataSource();
    }
}
