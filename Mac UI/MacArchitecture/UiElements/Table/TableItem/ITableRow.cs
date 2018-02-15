using System;

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
    //public class TableItem {
    //    public TableItem() {
    //    }
    //}



    public interface ITreeTableRow : ITableRow {
        bool Expandable { get; set; }

        ITreeTableRow GetChild(nint childIndex);
        nint GetChildrenCount();
    }

    //todo impl
    //map
    //abstract class TreeTableRow : NSObject, ITreeTableRow

}



