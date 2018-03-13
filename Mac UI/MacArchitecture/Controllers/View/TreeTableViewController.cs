using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Table.Tree.TableElements;
using MacArchitecture.UiElements.Table.TableRow;
using System.Collections.Generic;
using MacArchitecture.UiElements.Table.TableItem;
using System.Linq;

namespace MacArchitecture {
    public partial class TreeTableViewController : NSViewController {
        public TreeTableViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            //create different types of TreeTableItem
            //in one table

            //simple items in one table

      

            var f = tblT.TableColumns().ToList();

            var row = new SimpleTreeTableRow();
            row.DataCell.Add("0", "0");
            row.DataCell.Add("1", "1");
          

            var data = new List<ITreeTableRow>();
            data.Add(row);

         
            var columns = tblT.TableColumns().ToList();
            for (int i = 0; i < columns.Count; i++) {
                columns[i].Identifier = i.ToString();
                columns[i].Title = i.ToString();
            }


            var dlg = new BaseTreeTableDelegate();
            var ds = new TreeTableDataSource(tblT);

            tblT.Delegate = dlg;
            tblT.DataSource = ds;

            ds.Data = data;
            tblT.ReloadData();
        }
    }
}
