using System;
using AppKit;
using Foundation;
using System.Collections.Generic;

namespace MacArchitecture.UiElements.Table.Tree.TrTblItems {
    internal abstract class BaseTreeTableItem : NSObject {

        //data source do not use that methods
        public abstract ICollection<BaseTreeTableItem> GetChildren();
        public abstract void SetChildren(ICollection<BaseTreeTableItem> newChildren);
        //

        //
        public abstract nint GetChildrenCount();
        public abstract BaseTreeTableItem GetChild(nint childIndex);

        public abstract bool Expandeble();

        //view
        public abstract NSView CreateView(string columnIdentifier);
        public abstract void InitView(NSView view, string columnIdentifier);
        //

        //
        public abstract nfloat GetRowHeight(); //standart row height 16 }
    }
}
