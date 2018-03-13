﻿using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.Ordinary.TableElements {
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
            Data.Add(tableRow);
            //impl reload row 
        }

        public override nint GetRowCount(NSTableView tableView) {
            return _data.Count;
        }
    }
}
