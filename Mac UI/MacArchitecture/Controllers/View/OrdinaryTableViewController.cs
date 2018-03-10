using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Table.TableRow;
using MacArchitecture.UiElements.Table.Ordinary.TableElements;
using MacArchitecture.UiElements.Table.TableItem.Cell;
using System.Collections.Generic;
using System.Linq;
using MacArchitecture.UiElements.Table.ViewFactory;
using MacArchitecture.UiElements.Window;
using MacArchitecture.Utils;

namespace MacArchitecture {
    public partial class OrdinaryTableViewController : NSViewController {
        public OrdinaryTableViewController(IntPtr handle) : base(handle) {
        }

        private AlertWindow _alertWindow = new AlertWindow();
        private ClipboardMaster _clipboard = new ClipboardMaster();

        private string _cellValue = string.Empty; 

        public override void ViewDidLoad() {
            base.ViewDidLoad();


            //update selected 1 column cells
            //update deffernt cells
            //update selected row


            InitTableCell();

            InitTable();

            //create 2 table 
            //simple - all with texfields
            //create update selected column and row
            //create copy cell and copy row
            //create table with methods "copy:" and "copyRow:"

            btn_copyCell.Title = "Copy clicked cell value";
            btn_copyRow.Title = "Copy selected row value";


            tbl.Activated += (sender, e) => {
                var ds = (TableDataSource)tbl.DataSource;

                var tableRow = ds.Data[(int)tbl.ClickedRow];
                var clickedColumn = tbl.TableColumns().ToList()[(int)tbl.ClickedColumn];

                var cellValue = tableRow.GetValue(clickedColumn.Identifier).Text;
                _cellValue = cellValue;
            };

            btn_copyCell.Activated += (sender, e) => 
                _clipboard.CopyString(_cellValue);

            btn_copyRow.Activated += (sender, e) => {
                if (tbl.SelectedRow == -1)
                    return;
                
                var ds = (TableDataSource)tbl.DataSource;
                var tableRow = ds.Data[(int)tbl.SelectedRow];

                var rowValue = string.Empty;
                foreach (var column in tbl.TableColumns()) {
                    if (!string.IsNullOrEmpty(rowValue))
                        rowValue += "\t";

                    rowValue += tableRow.GetValue(column.Identifier).Text;
                }

                _clipboard.CopyString(rowValue);
            };
        }

        #region CreateData

        private List<ITableRow> CreateDataForCellTable(string[] columnIdentifier, int countRows) {
            var list = new List<ITableRow>();

            var typeCellEnum = Enum.GetValues(typeof(TypeCell)).Cast<int>().ToList();
            var rand = new Random();

            for (int i = 0; i < countRows; i++) {
                var tr = new TableRow();
                tr.RowHeight = 25;

                var wasCellTypes = new List<int>();
                foreach (var identifier in columnIdentifier) {
                    int cellType = -1;

                    while (true) {
                        cellType = rand.Next(0, typeCellEnum.Count);

                        if (!wasCellTypes.Contains(cellType)) {
                            wasCellTypes.Add(cellType);
                            break;
                        }
                    }

                    ICell cell = null;
                    switch (cellType) {
                        case 0: //TextField
                            var tf = new TextFieldCell();
                            tf.Text = nameof(TextFieldCell);

                            cell = tf;
                            break;

                        case 1: //TextView
                            var txtv = new TextViewCell();
                            txtv.Text = nameof(TextViewCell) + " change column size";

                            cell = txtv;
                            break;

                        case 2: //Button
                            var btn = new ButtonCell();
                            btn.Text = nameof(ButtonCell);
                            btn.Enabled = true;

                            btn.Activated = () => {
                                _alertWindow.ShowAlert(
                                    nameof(ButtonCell),
                                    "You activeted button",
                                    "OK");
                            };

                            cell = btn;
                            break;

                        case 3: //CheckBox
                            var ckb = new CheckboxCell();
                            ckb.Text = nameof(CheckboxCell);
                            ckb.AllowMixedState = true;
                            ckb.Enabled = true;

                            //also can use 
                            //ckb.StateChanged += (state) => {};

                            ckb.Activated = () => {
                                var state = string.Empty;

                                if (ckb.State == null)
                                    state = "mixed";
                                else
                                    state = ckb.State.ToString();

                                _alertWindow.ShowAlert(
                                        nameof(CheckboxCell),
                                        "You activeted checkbox. State: " + state,
                                        "OK");
                            };

                            cell = ckb;
                            break;

                        case 4: //PopUp
                            var btnP = new PopUpButtonCell();
                            //popup.Text = nameof(PopUpButtonCell);
                            btnP.Enabled = true;

                            btnP.MenuTitles = new string[] {
                                "Title1", "Title2", "Title3"
                            };

                            //also can use 
                            //btnP.SelectItem += (index) => {};

                            btnP.Activated = () => {
                                _alertWindow.ShowAlert(
                                      nameof(CheckboxCell),
                                      "You activeted checkbox. Selected title: " +
                                      btnP.MenuTitles[btnP.IndexOfSelectedItem],
                                      "OK");
                            };

                            cell = btnP;
                            break;
                    }

                    tr.Cells.Add(identifier, cell);
                }

                list.Add(tr);
            }

            return list;
        }


        private List<ITableRow> CreateSimpleData(string[] columnIdentifier, int countRows) {

            var rand = new Random();
            var min = 0;
            var max = 900;

            var list = new List<ITableRow>();
            for (int i = 0; i < countRows; i++) {
                var tr = new SimpleTableRow();

                foreach (var identifier in columnIdentifier) {
                    tr.DataCell.Add(identifier,
                                    nameof(SimpleTableRow) + " " + rand.Next(min, max));
                }

                list.Add(tr);
            }

            return list;
        }



        #endregion


        #region InitTable


        private void InitTableCell() {
            var ds = new TableDataSource(tbl_cells);
            var dlg = new BaseTableDelegate(ds);

            tbl_cells.Delegate = dlg;
            tbl_cells.DataSource = ds;

            var tblColumnIdentifier = new string[] { "C0", "C1", "C2", "C3", "C4" };
            InitTableColumns(tblColumnIdentifier, tbl_cells);

            var data = CreateDataForCellTable(tblColumnIdentifier, 3);
            ds.Data.AddRange(data);

            tbl_cells.ReloadData();
        }


        private void InitTable() {
            var ds = new TableDataSource(tbl);
            var dlg = new BaseTableDelegate(ds);

            tbl.Delegate = dlg;
            tbl.DataSource = ds;

            var tblColumnIdentifier = new string[] { "C0", "C1", "C2", "C3", "C4" };
            InitTableColumns(tblColumnIdentifier, tbl);

            var data = new List<ITableRow>();
            data.AddRange(CreateSimpleData(tblColumnIdentifier, 5));

            ds.Data.AddRange(data);
            tbl.ReloadData();
        }


        private void InitTableColumns(string[] columnIdentifier, NSTableView tableView) {

            var columns = tableView.TableColumns().ToList();
            foreach (var column in columns)
                tableView.RemoveColumn(column);

            for (int i = 0; i < columnIdentifier.Count(); i++) {
                var column = new NSTableColumn();
                column.Identifier = columnIdentifier[i];
                column.Title = column.Identifier;
                column.Width = 150;

                tableView.AddColumn(column);
            }
        }

        #endregion

    }
}
