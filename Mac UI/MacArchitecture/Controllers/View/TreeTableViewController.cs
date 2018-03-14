using System;
using Foundation;
using AppKit;
using MacArchitecture.UiElements.Table.Tree.TableElements;
using MacArchitecture.UiElements.Table.TableRow;
using System.Collections.Generic;
using MacArchitecture.UiElements.Table.TableItem;
using System.Linq;
using MacArchitecture.UiElements.Table.TableItem.Cell;
using MacArchitecture.UiElements.Window;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture {
    public partial class TreeTableViewController : NSViewController {
        public TreeTableViewController(IntPtr handle) : base(handle) {
        }

        private AlertWindow _alertWindow = new AlertWindow();


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            var columnIdentifiers = new List<string>();

            var columns = tblT.TableColumns().ToList();
            for (int i = 0; i < columns.Count; i++) {
                columns[i].Identifier = "C" + i.ToString();
                columns[i].Title = columns[i].Identifier;

                columnIdentifiers.Add(columns[i].Identifier);
            }

            var data = new List<ITreeTableRow>();
            data.AddRange(
                CreateTreeTableRows(columnIdentifiers));

            data.AddRange(
                CreateSimpleTreeTableRows(columnIdentifiers));


            var dlg = new BaseTreeTableDelegate();
            var ds = new TreeTableDataSource(tblT);

            tblT.Delegate = dlg;
            tblT.DataSource = ds;

            ds.Data = data;
            tblT.ReloadData();
        }


        public List<ITreeTableRow> CreateTreeTableRows(List<string> columnIdentifiers){
            var data = new List<ITreeTableRow>();

            var typeCellEnum = Enum.GetValues(typeof(TypeCell)).Cast<int>().ToList();

            var tableRow = new TreeTableRow();
            foreach (var columnIdentifier in columnIdentifiers) {
                var tf = new TextFieldCell();
                tf.Text = nameof(TextFieldCell);

                tableRow.Cells.Add(columnIdentifier, tf);
            }


            var children = new List<ITreeTableRow>();

            for (int i = 0; i < typeCellEnum.Count; i++) {
                var tr = new TreeTableRow();
                tr.RowHeight = 25;

                foreach (var columnIdentifier in columnIdentifiers) {
                    tr.Cells.Add(
                        columnIdentifier, 
                        CreateCell(i));
                }
                children.Add(tr);
            }

            tableRow.Children = children;

            data.Add(tableRow);

            return data;
        }


        public List<ITreeTableRow> CreateSimpleTreeTableRows(List<string> columnIdentifiers) {
            var data = new List<ITreeTableRow>();

            var tableRow = new SimpleTreeTableRow();
            tableRow.GroupItem = true;

            var key = "GroupItem";
            tableRow.DataCell.Add(
                key,
                nameof(SimpleTreeTableRow) + " " + key);

            var children = new List<ITreeTableRow>();
            for (int i = 0; i < 3; i++) {
                var tr = new SimpleTreeTableRow();

                foreach (var columnIdentifier in columnIdentifiers) {
                    tr.DataCell.Add(
                        columnIdentifier,
                        nameof(SimpleTreeTableRow) + " child " + i.ToString());
                }

                children.Add(tr);
            }

            tableRow.Children = children;

            data.Add(tableRow);

            return data;
        }


        public ICell CreateCell(int cellType){
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


            return cell;
        }
    }
}
