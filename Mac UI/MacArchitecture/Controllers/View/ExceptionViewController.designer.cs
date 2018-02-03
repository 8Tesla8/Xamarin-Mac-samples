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
	[Register ("ExceptionViewController")]
	partial class ExceptionViewController
	{
		[Outlet]
		AppKit.NSButton btn_exception { get; set; }

		[Outlet]
		AppKit.NSButton btn_nsException { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_exception != null) {
				btn_exception.Dispose ();
				btn_exception = null;
			}

			if (btn_nsException != null) {
				btn_nsException.Dispose ();
				btn_nsException = null;
			}
		}
	}
}
