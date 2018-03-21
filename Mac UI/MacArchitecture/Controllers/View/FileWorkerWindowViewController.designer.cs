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
		AppKit.NSButton btn_test { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_test != null) {
				btn_test.Dispose ();
				btn_test = null;
			}
		}
	}
}
