using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Table.Tree.TreeTableItems {
    internal abstract class TreeTableItem : NSObject, ITreeTableItem {
        protected readonly nfloat _standartRowHeight = 16f;

        public int Id { get; set; }

        public string Identifier { get; set; }

        public bool GroupItem { get; set; }
        public bool CanSelect { get; set; } = true;

        public bool IsTextEditable { get; set; }
        public bool IsTextSelectable { get; set; }

        public virtual List<ITreeTableItem> Children { get; set; }

        #region Children

        public virtual ITreeTableItem GetChild(nint childIndex) {
            return Children[(int)childIndex];
        }

        public virtual nint GetChildrenCount() {
            return Children.Count;
        }

        #endregion


        public virtual bool Expandable() {
            if (Children == null)
                return false;
            else
                return Children.Count > 0;
        }


        public virtual nfloat GetRowHeight() {
            return _standartRowHeight;
        }


        public bool IsGroupItem() {
            return GroupItem;
        }

        #region View

        public abstract NSView CreateView(string columnIdentifier);

        public abstract void InitView(NSView view, string columnIdentifier);

        #endregion

        public virtual bool CanSelectItem() {
            return CanSelect;
        }
    }
}