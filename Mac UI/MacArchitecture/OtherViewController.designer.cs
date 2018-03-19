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
	[Register ("OtherViewController")]
	partial class OtherViewController
	{
		[Outlet]
		AppKit.NSButton btn_tst { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_tst != null) {
				btn_tst.Dispose ();
				btn_tst = null;
			}
		}
	}
}
