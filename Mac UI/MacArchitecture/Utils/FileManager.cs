using System;
using System.IO;
using AppKit;
using Foundation;

namespace MacArchitecture.Utils {
    public class FileManager {
        public FileManager() {
        }

        public void CopyFolder(string source, string dest) {
            var fm = NSFileManager.DefaultManager;

            NSError error;

            var sourceFiles = fm.GetDirectoryContent(source, out error);
            fm.CreateDirectory(dest, true, null);

            foreach (var file in sourceFiles) {
                var filePath = source + "/" + file;

                if (fm.GetAttributes(filePath).Type == NSFileType.Directory)
                    CopyFolder(source + "/" + file, dest + "/" + file);

                else {
                    if (!NSFileManager.DefaultManager.Copy(filePath, dest + "/" + file, out error)) 
                        Console.WriteLine(error.LocalizedDescription);
                }
            }
        }


        public bool OpenApp(string name) {

            var path = GetAppPath(name + ".app");

            if (!string.IsNullOrEmpty(path))
                return NSWorkspace.SharedWorkspace.LaunchApplication(path);

            return false;
        }


        public string GetAppPath(string fullAppName) {

            string fullPath = NSWorkspace.SharedWorkspace.FullPathForApplication(fullAppName);

            if (!string.IsNullOrEmpty(fullPath) && !fullPath.StartsWith("/Volumes/"))
                return fullPath;

            return string.Empty;
        }


        public bool OpenFile(string filePath){
            if(File.Exists(filePath))
                return NSWorkspace.SharedWorkspace.SelectFile(filePath, filePath);
                //NSWorkspace.SharedWorkspace.OpenFile(filePath);

            return false;
        }


        public void GetPath(){
            var path = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.ApplicationDirectory, 
                                                            NSSearchPathDomain.All);

            //NSTemporaryDirectory

            var path1 = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.ApplicationDirectory, 
                                                             NSSearchPathDomain.User);

        }
    }
}
