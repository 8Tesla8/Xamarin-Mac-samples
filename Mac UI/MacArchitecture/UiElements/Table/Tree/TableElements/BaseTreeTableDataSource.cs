using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.TableItem;

namespace MacArchitecture.UiElements.Table.Tree.TableElements {
    public abstract class BaseTreeTableDataSource : NSOutlineViewDataSource {

        protected NSOutlineView _table;

        protected BaseTreeTableDataSource(NSOutlineView table) {
            _table = table;
        }

        public abstract ITreeTableRow GetItem(nint childIndex);


        public abstract nint GetDataCount();


        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item) {
            if (item == null)
                return GetDataCount();

            var treeTableItem = (ITreeTableRow)item;
            return treeTableItem.GetChildrenCount();
        }


        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item) {
            ITreeTableRow child = null;

            if (item == null) 
                child = GetItem(childIndex);
            else {
                var treeTableItem = (ITreeTableRow)item;
                child = treeTableItem.GetChild(childIndex);
            }

            return (NSObject)child;
        }


        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item) {
            ITreeTableRow treeTableItem = null;

            if (item == null) 
                treeTableItem = GetItem(0);
            else 
                treeTableItem = (ITreeTableRow)item;

            return treeTableItem.Expandable;
        }
    }


    public class TreeTableDataSource : BaseTreeTableDataSource {

        public TreeTableDataSource(NSOutlineView table) : base(table) {
            Data = new List<ITreeTableRow>();
        }

        public List<ITreeTableRow> Data { get; set; }


        public override ITreeTableRow GetItem(nint childIndex) {
            return Data[(int)childIndex];
        }


        public override nint GetDataCount() {
            return Data.Count;
        }
    }
}
