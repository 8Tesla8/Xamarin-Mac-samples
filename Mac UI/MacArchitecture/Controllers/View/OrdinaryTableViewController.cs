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
using MacArchitecture.UiElements.Table.Ordinary;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture {
    public partial class OrdinaryTableViewController : NSViewController {
        public OrdinaryTableViewController(IntPtr handle) : base(handle) {
        }

        private AlertWindow _alertWindow = new AlertWindow();
        private ClipboardMaster _clipboard = new ClipboardMaster();

        private string _cellValue = string.Empty;

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            InitTableCell();

            InitTable();

            btn_copyCell.Title = "Copy clicked cell value";
            btn_copyRow.Title = "Copy selected row";

            btn_updateRow.Title = "Update row";
            btn_updateColumn.Title = "Update column";

            btn_addRow.Title = "Add row";

            tf_row.PlaceholderString = "RowIndex";
            tf_column.PlaceholderString = "C0";

            tbl.Activated += (sender, e) => {
                var ds = (TableDataSource)tbl.DataSource;

                var tableRow = ds.Data[(int)tbl.ClickedRow];
                var clickedColumn = tbl.TableColumns()[(int)tbl.ClickedColumn];

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


            btn_updateRow.Activated += (sender, e) => {
                if (int.TryParse(tf_row.StringValue, out int rowIndex)) {
                    var ds = (TableDataSource)tbl.DataSource;

                    if (ds.Data.Count > rowIndex &&
                        rowIndex >= 0) {
                        var tableRow = (SimpleTableRow)ds.Data[rowIndex];

                        var rand = new Random();
                        var min = 0;
                        var max = 900;

                        foreach (var column in tbl.TableColumns()) 
                            tableRow.DataCell[column.Identifier] =
                                nameof(SimpleTableRow) + " " + rand.Next(min, max);

                        var rowIndexSet = new NSIndexSet(rowIndex);

                        var columnIndexSet = new NSMutableIndexSet();
                        for (int i = 0; i < tbl.TableColumns().Length; i++) 
                            columnIndexSet.Add(new NSIndexSet(i));

                        tbl.ReloadData(rowIndexSet, columnIndexSet);
                    }
                }
            };

            btn_updateColumn.Activated += (sender, e) => {
                var foundColumnIndex = tbl.FindColumn((NSString)tf_column.StringValue);

                if (foundColumnIndex < 0)
                    return;

                var column = tbl.TableColumns()[foundColumnIndex];

                var ds = (TableDataSource)tbl.DataSource;

                var rand = new Random();
                var min = 0;
                var max = 900;

                foreach (var row in ds.Data) {
                    var tableRow = (SimpleTableRow)row;
                    tableRow.DataCell[column.Identifier] =
                                nameof(SimpleTableRow) + " " + rand.Next(min, max);
                }

                var columnIndexSet = new NSIndexSet(foundColumnIndex);

                var rowIndexSet = new NSMutableIndexSet();
                for (int i = 0; i < ds.Data.Count; i++)
                    rowIndexSet.Add(new NSIndexSet(i));

                tbl.ReloadData(rowIndexSet, columnIndexSet);
            };

            btn_addRow.Activated += (sender, e) => {
                var tableRow = new SimpleTableRow();
                foreach (var column in tbl.TableColumns()) 
                    tableRow.DataCell.Add(column.Identifier, column.Identifier);
    
                var ds = (TableDataSource)tbl.DataSource;
                ds.AddRow(tableRow); 
            };

            //ordinary table
            var ordinaryTbl = (BaseOrdinaryTable)tbl;
            ordinaryTbl.SelectedRowIsChanged += (sender, e) => 
                Console.WriteLine("Selected row is changed");   

            ordinaryTbl.WasKeyDown += (sender, e) => {
                var theEvent = (NSEvent)sender;
                Console.WriteLine("key code of pressed key: " + theEvent.KeyCode);

                if(KeyDefinder.SpaceKey(theEvent))
                    Console.WriteLine("Space key was pressed");
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


        private List<ITableRow> CreateSimpleData(string[] columnIdentifiers, int countRows) {

            var rand = new Random();
            var min = 0;
            var max = 900;

            var list = new List<ITableRow>();
            for (int i = 0; i < countRows; i++) {
                var tr = new SimpleTableRow();

                foreach (var identifier in columnIdentifiers) {
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
