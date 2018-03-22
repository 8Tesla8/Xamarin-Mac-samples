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

            var strPath = "Path: ";

            lbl_filePathWindow.StringValue = strPath;
            lbl_openFileWindow.StringValue = strPath;
            lbl_saveFileWindow.StringValue = strPath;

            btn_filePathWindow.Activated += (sender, e) => {
                var res = fileWorkerWindow.ShowChoosePathToFileWindow(null);
            
                if(res.DialogRezult == true)
                    lbl_filePathWindow.StringValue = strPath + res.FilePath;
            };

            btn_openFileWindow.Activated += (sender, e) => {
                var res = fileWorkerWindow.ShowOpenFileWindow(FileType.TXT, "/Applications/");

                if (res.DialogRezult == true)
                    lbl_openFileWindow.StringValue = strPath + res.FilePath;
            };

            btn_saveFileWindow.Activated += (sender, e) => {
                var res = fileWorkerWindow.ShowSaveFileWindow("TestName", "/Applications/", FileType.TXT);
            
                if(res.DialogRezult == true)
                    lbl_saveFileWindow.StringValue = strPath + res.FilePath;
            };
        }


        public override void ViewDidAppear() {
            base.ViewDidAppear();

            View.Window.Title = nameof(FileWorkerWindowViewController);
        }
    }
}
