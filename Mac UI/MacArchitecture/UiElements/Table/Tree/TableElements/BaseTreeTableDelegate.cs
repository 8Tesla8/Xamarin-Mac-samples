using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.TableItem;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.UiElements.Table.Tree.TableElements {
    public class BaseTreeTableDelegate : NSOutlineViewDelegate {
        protected IViewFactory _viewFactory;
       
        public BaseTreeTableDelegate() {
            _viewFactory = Autofac.Injection.Resolve<IViewFactory>();
        }

        public event EventHandler ChangeSelectedRow;


        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item) {
            var tableRow = (ITreeTableRow)item;

            NSView view = null;

            if(tableRow.GroupItem)
                view = _viewFactory.CreateView(tableRow, string.Empty);
            else
                view = _viewFactory.CreateView(tableRow, tableColumn.Identifier);

            return view;
        }


        public override nfloat GetRowHeight(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableRow)item;
            return baseTreeTableItem.RowHeight;
        }


        public override bool IsGroupItem(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableRow)item;
            return baseTreeTableItem.GroupItem;
        }


        public override void SelectionDidChange(NSNotification notification) {
            ChangeSelectedRow?.Invoke(notification.Object, EventArgs.Empty);
        }


        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item) {
            var baseTreeTableItem = (ITreeTableRow)item;
            return baseTreeTableItem.Selectable;
        }
    }
}
