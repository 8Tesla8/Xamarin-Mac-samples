// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacArchitecture
{
	[Register ("FileWorkerWindowViewController")]
	partial class FileWorkerWindowViewController
	{
		[Outlet]
		AppKit.NSButton btn_filePathWindow { get; set; }

		[Outlet]
		AppKit.NSButton btn_openFileWindow { get; set; }

		[Outlet]
		AppKit.NSButton btn_saveFileWindow { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_filePathWindow { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_openFileWindow { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_saveFileWindow { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_filePathWindow != null) {
				btn_filePathWindow.Dispose ();
				btn_filePathWindow = null;
			}

			if (btn_openFileWindow != null) {
				btn_openFileWindow.Dispose ();
				btn_openFileWindow = null;
			}

			if (btn_saveFileWindow != null) {
				btn_saveFileWindow.Dispose ();
				btn_saveFileWindow = null;
			}

			if (lbl_filePathWindow != null) {
				lbl_filePathWindow.Dispose ();
				lbl_filePathWindow = null;
			}

			if (lbl_openFileWindow != null) {
				lbl_openFileWindow.Dispose ();
				lbl_openFileWindow = null;
			}

			if (lbl_saveFileWindow != null) {
				lbl_saveFileWindow.Dispose ();
				lbl_saveFileWindow = null;
			}
		}
	}
}
