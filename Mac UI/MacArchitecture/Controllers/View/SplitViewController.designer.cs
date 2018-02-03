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
	[Register ("SplitViewController")]
	partial class SplitViewController
	{
		[Outlet]
		AppKit.NSButton btn_horizontal { get; set; }

		[Outlet]
		AppKit.NSButton btn_vertical { get; set; }

		[Outlet]
		AppKit.NSSplitView splv_horizontal { get; set; }

		[Outlet]
		AppKit.NSSplitView splv_vertical { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (splv_horizontal != null) {
				splv_horizontal.Dispose ();
				splv_horizontal = null;
			}

			if (splv_vertical != null) {
				splv_vertical.Dispose ();
				splv_vertical = null;
			}

			if (btn_horizontal != null) {
				btn_horizontal.Dispose ();
				btn_horizontal = null;
			}

			if (btn_vertical != null) {
				btn_vertical.Dispose ();
				btn_vertical = null;
			}
		}
	}
}
