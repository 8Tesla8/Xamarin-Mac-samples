using System;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Table.Ordinary {

    [Register(nameof(BaseOrdinaryTable))]
    public class BaseOrdinaryTable : NSTableView {
        public BaseOrdinaryTable(IntPtr handle) : base(handle) {
        }

        public event EventHandler WasKeyDown;

        //public event EventHandler SelectedRowIsChanged;
        //public override NSObject WeakDelegate {
        //    get { return base.WeakDelegate; }
        //    set {
        //        if (base.WeakDelegate != null &&
        //            base.WeakDelegate is BaseTableDelegate) {
        //            var dlg = (BaseTableDelegate)base.WeakDelegate;
        //            dlg.SelectionIsChanged -= SelectedRowChanged;
        //        }
        //        if (value is BaseTableDelegate) {
        //            var dlg = (BaseTableDelegate)value;
        //            dlg.SelectionIsChanged += SelectedRowChanged;
        //        }
        //        base.WeakDelegate = value;
        //    }
        //}
        //public override NSObject WeakDataSource {
        //    get { return base.WeakDataSource; }
        //    set { base.WeakDataSource = value; }
        //}


        public override void KeyDown(NSEvent theEvent) {
            base.KeyDown(theEvent);

            WasKeyDown?.Invoke(theEvent, EventArgs.Empty);
        }


        public virtual void RemoveAllColumns() {
            foreach (var column in TableColumns()) {
                DrawFocusRingMask(); //for 10.13 do not remove
                RemoveColumn(column);
            }
        }


        public virtual void ScrollToColumn(string columnIdentifer) {
            var columnIndex = FindColumn((NSString)columnIdentifer);

            if (columnIndex >= 0)
                ScrollColumnToVisible(columnIndex);
        }
    }
}
