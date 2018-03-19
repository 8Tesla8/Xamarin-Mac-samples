using System;
using System.Collections.Generic;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree {
    public class OutlineViewHelper {
        public OutlineViewHelper() {
        }

        //expnding algorithms 
        //public void FirstExpand(NSOutlineView outlineTable) {
        //    outlineTable.ExpandItem(outlineTable.ItemAtRow(1), true);
        //    outlineTable.CollapseItem(outlineTable.ItemAtRow(1));
        //    outlineTable.ExpandItem(outlineTable.ItemAtRow(0), true);
        //}

        //public void ExpandIssueItemsInIssuePanel(int indexRowForExpand, NSOutlineView outlineView) {
        //    if (!outlineView.IsItemExpanded(outlineView.ItemAtRow(0)))
        //        outlineView.ExpandItem(outlineView.ItemAtRow(0));
        //    var node = ((NSTreeNode)outlineView.ItemAtRow(0)).Children[indexRowForExpand];
        //    if (!outlineView.IsItemExpanded(node))
        //        outlineView.ExpandItem(node);
        //}

        //public void ExpandItems(int index, NSOutlineView outlineView) {
        //    var mainNode = ((NSTreeNode)outlineView.ItemAtRow(0)).ParentNode;
        //    var child = mainNode.Children[index];
        //    if (!outlineView.IsItemExpanded(child))
        //        outlineView.ExpandItem(child);
        //    for (int i = 0; i < child.Children.Length; ++i) {
        //        outlineView.ExpandItem(child.Children[i]);
        //    }
        //}

        //public void Expand() {
        //    for (int i = 0; i < outlineView.RowCount; ++i) {
        //        var itemAtRow = outlineView.ItemAtRow(i);
        //        var myItem = (MyClass)itemAtRow; //cast to your represent class obj 
        //        if (myItem.IsExpanded)
        //            nameOutlineView.ExpandItem(itemAtRow);
        //    }
        //}


        //when use native binding
        //public static List<MyClass> GetSelectedIssues(NSOutlineView outlineTable) {
        //    var selectedIssues = new List<MyClass>(); 
        //    var selectedRows = outlineTable.SelectedRows;
        //    foreach (var rowIndex in selectedRows) {
        //        var selectedItem = (NSTreeNode)outlineTable.ItemAtRow((int)rowIndex);
        //        var selectedItemPath = selectedItem.IndexPath.GetIndexes();
        //        if (selectedItemPath[0] == 0) { 
        //            var item = (MyClass)selectedItem.RepresentedObject;
        //            selectedItems.AddRange(GetLeafs(item));
        //        }
        //    }
        //    return new HashSet<MyClass>(selectedItems).ToList();
        //}

        //public static List<MyClass> GetLeafsFromIssueItem(MyClass myItem) {
        //    var list = new List<MyClass>();
        //    if (myItem.IsLeafForCode)
        //        list.Add(myItem);
        //    else
        //        foreach (var item in myItem.Children) {
        //            if (item.IsLeaf)
        //                list.Add(item);
        //            else
        //                list.AddRange(GetLeafsFromIssueItem(item));
        //        }
        //    return list;
        //}
    }
}
