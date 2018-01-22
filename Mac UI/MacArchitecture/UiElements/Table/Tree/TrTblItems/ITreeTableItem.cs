using System;
using AppKit;

namespace MacArchitecture.UiElements.Table.Tree.TrTblItems {
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
