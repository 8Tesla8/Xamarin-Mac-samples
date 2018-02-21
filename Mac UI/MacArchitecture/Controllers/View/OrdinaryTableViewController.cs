using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Table.TableRow;
using MacArchitecture.UiElements.Table.Ordinary.TableElements;
using MacArchitecture.UiElements.Table.TableItem.Cell;

namespace MacArchitecture {
    public partial class OrdinaryTableViewController : NSViewController {
        public OrdinaryTableViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            btn_reloadData.Activated += (sender, e) => 
                tbl_cells.ReloadData();

            //update selected 1 column cells
            //update deffernt cells
            //update selected row

            //create base delegate with IViewFactory
            //create base data source with dynamic

            //create table with methods "copy:" and "copyRow:"

            //create all types of cell


                     

            var ds = new TableDataSource(tbl_cells);
            var dlg = new BaseTableDelegate(ds);

            var tr = new TableRow();

            tr.Cells.Add("C0", new TextFieldCell() {
                Text = "TF",
            });
            tr.Cells.Add("C1", new TextFieldCell() {
                Text = "TF",
            });
            tr.Cells.Add("C2", new TextFieldCell() {
                Text = "TF",
            });

            ds.Data.Add(tr);
            //ds.AddRow(tr);


            tbl_cells.Delegate = dlg;
            tbl_cells.DataSource = ds;

            var cl = tbl_cells.TableColumns()[0];
            cl.Identifier = "C0";
            cl.Title = cl.Identifier;

            //tbl_cells.RemoveColumn(tbl_cells.TableColumns()[0]);
            //for (int i = 0; i < 3; i++) {
            //    var column = new NSTableColumn();
            //    column.Identifier = "C" + i;
            //    column.Title = column.Identifier;

            //    tbl_cells.AddColumn(column);
            //}

 

            tbl_cells.ReloadData();
        }
    }
}
