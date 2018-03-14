using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table.Ordinary.TableElements;

namespace MacArchitecture.UiElements.Table.Ordinary {

    [Register(nameof(BaseOrdinaryTable))]
    public class BaseOrdinaryTable : NSTableView {
        public BaseOrdinaryTable(IntPtr handle) : base(handle) { }

        public event EventHandler WasKeyDown;
        public event EventHandler SelectedRowIsChanged;


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


        public virtual void SelectedRowChanged(object sender, EventArgs e) {
            SelectedRowIsChanged?.Invoke(sender, e);
        }

        #region Delegate

        private BaseTableDelegate _delegate;

        public virtual BaseTableDelegate GetDelegate() {
            return _delegate;
        }

        public override NSObject WeakDelegate {
            get { return base.WeakDelegate; }
            set {
                if (_delegate != null) {
                    _delegate.ChangeSelectedRow -= SelectedRowChanged;
                }
                if (value is BaseTableDelegate) {
                    _delegate = (BaseTableDelegate)value;
                    _delegate.ChangeSelectedRow += SelectedRowChanged;
                }

                base.WeakDelegate = value;
            }
        }

        #endregion

        #region DataSource

        private BaseTableDataSource _dataSource;
        public virtual BaseTableDataSource GetDataSource(){
            return _dataSource;
        }

        public override NSObject WeakDataSource {
            get { return base.WeakDataSource; }
            set { 
                if(value is BaseTableDataSource){
                    _dataSource = (BaseTableDataSource)value;
                }

                base.WeakDataSource = value; 
            }
        }

        #endregion

    }
}
