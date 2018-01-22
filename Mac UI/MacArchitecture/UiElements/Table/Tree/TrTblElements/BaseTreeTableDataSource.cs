using System;
using AppKit;
using Foundation;
using System.Collections.Generic;
using MacArchitecture.UiElements.Table.Tree.TrTblItems;

namespace MacArchitecture.UiElements.Table.Tree.TrTblElements {
    internal abstract class BaseTreeTableDataSource<T> : NSOutlineViewDataSource
        where T : ITreeTableItem {

        public abstract void ClearData();

        public abstract void SetData(ICollection<T> newData);
        public abstract ICollection<T> GetData();

        public abstract ITreeTableItem GetItem(nint childIndex);

        public abstract nint GetDataCount();

        //override NSOutlineViewDataSource methods
        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item) {
            if (item == null)
                return GetDataCount();

            var treeTableItem = (ITreeTableItem)item;
            return treeTableItem.GetChildrenCount();
        }

        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item) {
            ITreeTableItem child = null;

            if (item == null) {
                child = GetItem(childIndex);
            }
            else {
                var treeTableItem = (ITreeTableItem)item;
                child = treeTableItem.GetChild(childIndex);
            }

            return (NSObject)child;
        }

        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item) {
            ITreeTableItem treeTableItem = null;

            if (item == null) {
                treeTableItem = GetItem(0);
            }
            else {
                treeTableItem = (ITreeTableItem)item;
            }

            return treeTableItem.Expandable();
        }
    }
}
