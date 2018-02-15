using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree.TreeTableItems {

    //todo impr
    //remove this class have ITreeTableRow
    //create examples шаблонным методом

    //NOTE: IMPLEMENTATION MUST BE INHERIT FROM NSObject
    internal interface ITreeTableItem {
        ITreeTableItem GetChild(nint childIndex);
        nint GetChildrenCount();

        bool IsGroupItem();

        nfloat GetRowHeight();

        bool Expandable();

        bool CanSelectItem();

        //view
        NSView CreateView(string columnIdentifier);
        void InitView(NSView view, string columnIdentifier);
    }
}
