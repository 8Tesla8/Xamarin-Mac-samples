using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table;
using MacArchitecture.UiElements.Table.Tree.TableElements;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.UiElements.UI.Table.Tree {

    [Register(nameof(BaseTreeTable))]
    internal class BaseTreeTable : NSOutlineView {
        public BaseTreeTable(IntPtr handle) : base(handle) { }

        public event EventHandler WasKeyDown;
        public event EventHandler SelectedRowIsChanged;


        public override void KeyDown(NSEvent theEvent) {
            base.KeyDown(theEvent);

            WasKeyDown?.Invoke(theEvent, EventArgs.Empty);
        }

        public virtual void SelectedRowChanged(object sender, EventArgs e) {
            SelectedRowIsChanged?.Invoke(sender, e);
        }

        #region Delegate

        private BaseTreeTableDelegate _delegate;

        public virtual BaseTreeTableDelegate GetDelegate() {
            return _delegate;
        }

        public override NSObject WeakDelegate {
            get { return base.WeakDelegate; }
            set {
                if (_delegate != null) {
                    _delegate.ChangeSelectedRow -= SelectedRowChanged;
                }
                if (value is BaseTreeTableDelegate) {
                    _delegate = (BaseTreeTableDelegate)value;
                    _delegate.ChangeSelectedRow += SelectedRowChanged;
                }

                base.WeakDelegate = value;
            }
        }

        #endregion

        #region DataSource

        private BaseTreeTableDataSource _dataSource;
        public virtual BaseTreeTableDataSource GetDataSource() {
            return _dataSource;
        }

        public override NSObject WeakDataSource {
            get { return base.WeakDataSource; }
            set {
                if (value is BaseTreeTableDataSource) {
                    _dataSource = (BaseTreeTableDataSource)value;
                }

                base.WeakDataSource = value;
            }
        }

        #endregion

        //[Action("copy:")]
        //public virtual void CopyCellValue(NSObject sender) {
        //}
    }
}
