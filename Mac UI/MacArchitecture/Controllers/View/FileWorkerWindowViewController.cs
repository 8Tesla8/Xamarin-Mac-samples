using System;
using AppKit;
using MacArchitecture.UiElements.Window.FileWindow;

namespace MacArchitecture {
    public partial class FileWorkerWindowViewController : NSViewController {
        public FileWorkerWindowViewController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();

            var fileWorkerWindow = new FileWorkerWindows();

            //show chosen path and file name 

            btn_test.Activated += (sender, e) => {
                fileWorkerWindow.ShowSaveFileWindow("test", "/Applications/", FileType.TXT);
            };
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(FileWorkerWindowViewController);
        }
    }
}
