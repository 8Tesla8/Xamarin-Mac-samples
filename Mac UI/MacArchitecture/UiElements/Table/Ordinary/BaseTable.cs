using System;
using AppKit;
using Foundation;
using MacArchitecture.UiElements.Utils;

namespace MacArchitecture.UiElements.Table.Simple {

    //todo ipv
    //создать мултиселект для танной таблицы???

    [Register(nameof(BaseTable))]
    internal class BaseTable : NSTableView {
        public BaseTable(IntPtr handle) : base(handle) {

        }

        public override void KeyDown(NSEvent theEvent) {
            base.KeyDown(theEvent);

            if (KeyDefinder.CmdC(theEvent))
                CopyCellValue();
        }

        [Action("copy:")]
        public void CopyAction(NSObject sender) {
            CopyCellValue();
        }

        protected virtual void CopyCellValue(){
            
        }
    }
}
