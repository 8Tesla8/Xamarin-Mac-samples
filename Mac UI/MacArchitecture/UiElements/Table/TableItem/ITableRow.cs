using System;
using System.Collections.Generic;
using MacArchitecture.UiElements.Table.TableItem.Cell;

namespace MacArchitecture.UiElements.Table.TableRow {

    public interface ITableRow {
        int Id { get; set; }
        string Identifier { get; set; }

        nfloat RowHeight { get; set; }
        bool GroupItem { get; set; }
        bool Selectable { get; set; }

        ICell GetCell(string columnIdentifier);

        (string Text, string Tooltip) GetValue(string columnIdentifier);
    }


    public class TableRow : ITableRow {
        public TableRow() {
            RowHeight = 16f;
            Cells = new Dictionary<string, ICell>();

            GroupItem = false;
            Selectable = true;
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public nfloat RowHeight { get; set; }
        public bool GroupItem { get; set; }
        public bool Selectable { get; set; }

        public Dictionary<string, ICell> Cells { get; set; }


        public ICell GetCell(string columnIdentifier) {
            return Cells[columnIdentifier];
        }


        public (string Text, string Tooltip) GetValue(string columnIdentifier) {
            return (Cells[columnIdentifier].Text,
                    Cells[columnIdentifier].Tooltip);
        }
    }


    public class SimpleTableRow : ITableRow {
        public SimpleTableRow() {
            RowHeight = 16f;

            GroupItem = false;
            Selectable = true;

            _cell = new TextFieldCell();
            DataCell = new Dictionary<string, string>();
        }

        private TextFieldCell _cell;

        public int Id { get; set; }
        public string Identifier { get; set; }
        public nfloat RowHeight { get; set; }
        public bool GroupItem { get; set; }
        public bool Selectable { get; set; }

        public Dictionary<string, string> DataCell { get; set; }


        public ICell GetCell(string columnIdentifier) {
            return _cell;
        }

        public (string Text, string Tooltip) GetValue(string columnIdentifier) {
            return (DataCell[columnIdentifier],
                    DataCell[columnIdentifier]);
        }
    }
}



