using System;
using System.Collections.Generic;

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

    //todo impl
    //create SimpleTableItem - cells is only TextField
    //public abstract class SimpleTableItem : ITableRow { 
    //    private TextFieldCell 

    //    public int Id { get; set; }
    //    public string Identifier { get; set; }
    //    public nfloat RowHeight { get; set; }
    //    public bool GroupItem { get; set; }
    //    public bool Selectable { get; set; }

    //    public ICell GetCell(string columnIdentifier) {

    //    }

    //    public Dictionary<string, string> Value { get; set; }

    //    public (string Text, string Tooltip) GetValue(string columnIdentifier) {
    //        throw new NotImplementedException();
    //    }
    //}
    //todo impl
    //create DynamicTableItem - data is dynamic

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



    public interface ITreeTableRow : ITableRow {
        bool Expandable { get; set; }

        ITreeTableRow GetChild(nint childIndex);
        nint GetChildrenCount();
    }

    //todo impl
    //map
    //abstract class TreeTableRow : NSObject, ITreeTableRow

}



