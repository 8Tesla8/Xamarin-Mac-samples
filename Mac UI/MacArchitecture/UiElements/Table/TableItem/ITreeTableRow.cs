using System;
using MacArchitecture.UiElements.Table.TableRow;

namespace MacArchitecture.UiElements.Table.TableItem {
    public interface ITreeTableRow : ITableRow {
        bool Expandable { get; set; }

        ITreeTableRow GetChild(nint childIndex);
        nint GetChildrenCount();
    }

    //todo impl
    //map
    //abstract class TreeTableRow : NSObject, ITreeTableRow


}
