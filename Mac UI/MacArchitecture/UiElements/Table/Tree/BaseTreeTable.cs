using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Table;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.UiElements.UI.Table.Tree {

    [Register(nameof(BaseTreeTable))]
    internal class BaseTreeTable : NSOutlineView {
        public BaseTreeTable(IntPtr handle) : base(handle) { }

        public event EventHandler WasKeyDown;
        public event EventHandler CopyCell;


        public override void KeyDown(NSEvent theEvent) {
            base.KeyDown(theEvent);

            WasKeyDown?.Invoke(theEvent, EventArgs.Empty);

            if (KeyDefinder.CmdC(theEvent))
                CopyCellValue(null);
        }

        [Action("copy:")]
        public virtual void CopyCellValue(NSObject sender) {
            CopyCell?.Invoke(this, EventArgs.Empty);
        }
    }
}
