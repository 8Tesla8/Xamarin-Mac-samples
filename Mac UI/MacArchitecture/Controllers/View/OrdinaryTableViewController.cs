using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Table.Ordinary.TableElements;

namespace MacArchitecture {
    public partial class OrdinaryTableViewController : NSViewController {
        public OrdinaryTableViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();


            //update selected 1 column cells
            //update deffernt cells
            //update selected row

            //create base delegate with IViewFactory
            //create base data source with dynamic

            //create table with methods "copy:" and "copyRow:"

            //create all types of cell

            var ds = new DataSource(tbl_cells);
            var dlg = new BaseTableDelegate(ds);


            tbl_cells.Delegate = dlg;
            tbl_cells.DataSource = ds;
        }
    }
}
