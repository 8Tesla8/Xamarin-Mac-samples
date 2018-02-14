using System;
using MacArchitecture.UiElements.Table.ViewFactory;

namespace MacArchitecture.UiElements.Table.Ordinary {
    public class TableItem {
        public TableItem() {
        }
    }

    //row maybe rename to TableRow
    public interface ITableItem {
        int Id { get; set; }
        string Identifier { get; set; }

        nfloat RowHeight { get; set; } 
        bool IsGroupItem { get; set; }
        bool Editable { get; set; }
        bool Selectable { get; set; }

        //TypeCellView TypeCellView { get; set; } //for cell
        TypeCellView GetTypeCellView(string columnIdentifier);


        (string Text, string Tooltip) GetValue(string columnIdentifier);
    }


    public interface ITreeTableItem : ITableItem {
        bool Expandeble { get; set; }
    
        ITreeTableItem GetChild(nint childIndex);
        nint GetChildrenCount();
    }

    //todo impl
    //map
    //abstract class TreeTableItem : NSObject, ITreeTableItem
}
