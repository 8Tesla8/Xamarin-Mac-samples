using System;
namespace MacArchitecture.UiElements.Window.FileWindow {

    [Flags]
    public enum FileType {
        None = 0x0,
        AllFiles = 0x1,
        TXT = 0x2,
        // = 0x4,
        //XLSX = 0x8,
        //CSV = 0x10,
    }


    public class FileWindowResult {

        public bool? DialogRezult { get; }
        public string FilePath { get; }
        public string[] FilePaths { get; }

        public FileWindowResult() {
            DialogRezult = null;
            FilePath = "";
            FilePaths = new string[] { };
        }


        public FileWindowResult(bool? dialogRezult) : this() {
            DialogRezult = dialogRezult;
        }


        public FileWindowResult(bool? dialogRezult, string filePath) {
            DialogRezult = dialogRezult;
            FilePath = filePath;
            FilePaths = new string[] { };
        }


        public FileWindowResult(bool? dialogRezult, string[] filePaths) {
            DialogRezult = dialogRezult;
            FilePath = "";
            FilePaths = filePaths;
        }
    }
}
