using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.TableRow;

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

    public abstract class BaseDataSource : NSTableViewDataSource{
     
        protected NSTableView _table;

        public BaseDataSource(NSTableView table) {
            _table = table;
        }

        public abstract ITableRow GetRow(int row);

        public abstract void ClearData();

        public abstract void AddRow(ITableRow tableRow);
    }

    public class DataSource : BaseDataSource {
        public DataSource(NSTableView table) : base(table) {
            _data = new List<ITableRow>();       
        }

        public override ITableRow GetRow(int row) {
            throw new NotImplementedException();
        }

        private List<ITableRow> _data;
        public List<ITableRow> Data {
            get { return _data; }
            set {
                _data = value;
                _table.ReloadData();
            }
        }

        public void ClearDataSource() {
            Data = new List<ITableRow>();
        }

        public override void ClearData() {
            throw new NotImplementedException();
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
    }
}
