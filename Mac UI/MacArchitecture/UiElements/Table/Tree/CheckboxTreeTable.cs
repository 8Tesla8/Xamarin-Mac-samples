using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.UI.Table.Tree;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.UiElements.Table.Tree {
    //todo impl
    //create example
    [Register(nameof(CheckboxTreeTable))]
    internal class CheckboxTreeTable : BaseTreeTable {
        public CheckboxTreeTable(IntPtr handle) : base(handle) { }


        public override void KeyDown(NSEvent theEvent) {
            base.KeyDown(theEvent);


            if (KeyDefinder.SpaceKey(theEvent)) {
                if (SelectedRowCount != 1)
                    return;

                var indexSelectedRow = SelectedRow;

                //var rowView = GetRowView(SelectedRow, false);
                var cellView = GetView(0, indexSelectedRow, false);

                foreach (var view in cellView.Subviews) {
                    if (view is NSButton) {
                        var ckb = (NSButton)view;
                        ckb.PerformClick(ckb);
                    }
                }
            }
        }

    }
}
