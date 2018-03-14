using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MacArchitecture.UiElements.Table.TableItem.Cell;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.TableItem {

    //NOTE: IMPLEMENTATION MUST BE INHERIT FROM NSObject
    public interface ITreeTableRow : ITableRow {
        bool Expandable { get; }

        ITreeTableRow GetChild(nint childIndex);
        nint GetChildrenCount();
    }


    public class TreeTableRow : NSObject, ITreeTableRow {
     
        public TreeTableRow() {
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

        public List<ITreeTableRow> Children { get; set; }


        public ICell GetCell(string columnIdentifier) {
            if (string.IsNullOrEmpty(columnIdentifier)) 
                return Cells.First().Value; 

            return Cells[columnIdentifier];
        }


        public (string Text, string Tooltip) GetValue(string columnIdentifier) {
            if (string.IsNullOrEmpty(columnIdentifier)) {
                var first = Cells.First();

                return (Cells[first.Key].Text,
                        Cells[first.Key].Tooltip);
            }

            return (Cells[columnIdentifier].Text,
                    Cells[columnIdentifier].Tooltip);
        }


        public bool Expandable {
            get {
                if (Children == null)
                    return false;

                return Children.Count > 0;
            }
        }


        public ITreeTableRow GetChild(nint childIndex) {
            return Children[(int)childIndex];
        }


        public nint GetChildrenCount() {
            return Children.Count;
        }
    }


    public class SimpleTreeTableRow : NSObject, ITreeTableRow {
        public SimpleTreeTableRow() {
            RowHeight = 16f;

            _cell = new TextFieldCell();

            DataCell = new Dictionary<string, string>();

            GroupItem = false;
            Selectable = true;
        }

        private TextFieldCell _cell;

        public int Id { get; set; }
        public string Identifier { get; set; }
        public nfloat RowHeight { get; set; }
        public bool GroupItem { get; set; }
        public bool Selectable { get; set; }

        public List<ITreeTableRow> Children { get; set; }

        public Dictionary<string, string> DataCell { get; set; }


        public ICell GetCell(string columnIdentifier) {
            return _cell;
        }


        public (string Text, string Tooltip) GetValue(string columnIdentifier) {
            if (string.IsNullOrEmpty(columnIdentifier)) {
                var first = DataCell.First();

                return (DataCell[first.Key],
                        DataCell[first.Key]);
            }

            return (DataCell[columnIdentifier],
                    DataCell[columnIdentifier]);
        }


        public bool Expandable {
            get {
                if (Children == null)
                    return false;

                return Children.Count > 0;
            }
        }


        public ITreeTableRow GetChild(nint childIndex) {
            return Children[(int)childIndex];
        }


        public nint GetChildrenCount() {
            return Children.Count;
        }
    }
}
