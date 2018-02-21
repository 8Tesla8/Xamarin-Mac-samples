using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.Ordinary.TableElements {
    //internal abstract class BaseTableDataSource : NSTableViewDataSource {
    //    protected NSTableView _table;

    //    public Action RowsAdded;

    //    public void InitTable(NSTableView table) {
    //        _table = table;
    //    }

    //    //public abstract List<BaseRowModel> GetData();

    //    public abstract void ClearDataSource();
    //}

    public abstract class BaseTableDataSource : NSTableViewDataSource{
     
        protected NSTableView _table;

        protected BaseTableDataSource(NSTableView table) {
            _table = table;
        }

        public abstract ITableRow GetRow(int row);

        public abstract void ClearData();

        public abstract void AddRow(ITableRow tableRow);

        public override abstract nint GetRowCount(NSTableView tableView);
    }


    public class TableDataSource : BaseTableDataSource {
        public TableDataSource(NSTableView table) : base(table) {
            _data = new List<ITableRow>();       
        }


        public override ITableRow GetRow(int row) {
            return Data[row];
        }


        private List<ITableRow> _data;
        public List<ITableRow> Data {
            get { return _data; }
            set {
                _data = value;
                _table.ReloadData();
            }
        }


        public override void ClearData() {
            Data = new List<ITableRow>();
            _table.ReloadData();
        }


        public override void AddRow(ITableRow tableRow) {
            var row = Data.Count;
            Data.Add(tableRow);

            //for one row
            var columns = new NSIndexSet(row);

            var columnRange = NSIndexSet.FromNSRange(
                new NSRange(0,_table.TableColumns().Length) );

            var mutable = new NSMutableIndexSet();
            mutable.Add(new NSIndexSet(2));
            mutable.Add(new NSIndexSet(3));

            //todo tst
            //it will work well
            _table.ReloadData(new NSIndexSet(row), 
                              columnRange);
        }

        public override nint GetRowCount(NSTableView tableView) {
            return _data.Count;
        }
    }
}
