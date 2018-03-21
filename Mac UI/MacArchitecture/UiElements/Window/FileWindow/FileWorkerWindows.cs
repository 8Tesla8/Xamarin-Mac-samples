using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace MacArchitecture.UiElements.Window.FileWindow {
    public class FileWorkerWindows {
        private string[] FileTypeConverter(FileType fileType) {
            var fileTypeList = new List<string>();

            //if (fileType.HasFlag(FileType.AllFiles)) { }
            if (fileType.HasFlag(FileType.TXT))
                fileTypeList.Add("txt");

            if (fileTypeList.Count == 0)
                throw new ArgumentException("Not entered file type");

            return fileTypeList.ToArray();
        }


        public FileWindowResult ShowChoosePathToFileWindow(string path) {
            var openWindow = new NSOpenPanel();

            if (!string.IsNullOrEmpty(path))
                openWindow.DirectoryUrl = new NSUrl(path, true);

            openWindow.CanChooseFiles = false;
            openWindow.CanCreateDirectories = true;
            openWindow.CanChooseDirectories = true;
            openWindow.AllowsMultipleSelection = false;

            if (openWindow.RunModal() == Convert.ToInt32(NSModalResponse.OK))
                return new FileWindowResult(true, openWindow.Url.Path);

            return new FileWindowResult(false);
        }


        public FileWindowResult ShowOpenFileWindow(FileType fileType, bool multiSelectOn = false) {
            var dialog = new NSOpenPanel();

            //dialog.Title = Title;
            dialog.ShowsResizeIndicator = true;
            dialog.ShowsHiddenFiles = false;
            dialog.CanChooseDirectories = false;
            dialog.CanCreateDirectories = false;
            dialog.AllowsMultipleSelection = multiSelectOn;
            dialog.AllowedFileTypes = FileTypeConverter(fileType);

            if (dialog.RunModal() == Convert.ToInt32(NSModalResponse.OK)) {

                if (multiSelectOn) {
                    var results = dialog.Urls;

                    if (results != null) {

                        var paths = new List<string>();
                        foreach (var res in dialog.Urls) {
                            if (res != null)
                                paths.Add(res.Path);
                        }

                        return new FileWindowResult(true, paths.ToArray());
                    }
                }
                else {
                    var result = dialog.Url;

                    if (result != null)
                        return new FileWindowResult(true, result.Path);
                }
            }

            return new FileWindowResult(false);
        }


        public FileWindowResult ShowSaveFileWindow(string name, string path, FileType fileType) {
            var saveWindow = NSSavePanel.SavePanel;
            saveWindow.AllowsOtherFileTypes = false;
            saveWindow.ExtensionHidden = true;
            saveWindow.CanCreateDirectories = true;
            saveWindow.CanSelectHiddenExtension = false;

            saveWindow.AllowedFileTypes = FileTypeConverter(fileType);
            saveWindow.NameFieldStringValue = name;

            var tf = NSTextField.CreateLabel("text file (*.txt)");
            saveWindow.AccessoryView = tf;

            if (!string.IsNullOrEmpty(path))
                saveWindow.DirectoryUrl = new NSUrl(path, true);

            if (saveWindow.RunModal() == Convert.ToInt32(NSModalResponse.OK))
                return new FileWindowResult(true, saveWindow.Url.Path);

            return new FileWindowResult(false);
        }
    }
}
