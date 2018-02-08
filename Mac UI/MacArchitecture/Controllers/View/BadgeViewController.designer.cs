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
	[Register ("BadgeViewController")]
	partial class BadgeViewController
	{
		[Outlet]
		AppKit.NSButton btn_addBadge { get; set; }

		[Outlet]
		AppKit.NSButton btn_clear { get; set; }

		[Outlet]
		AppKit.NSButton ckb_showBadge { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ckb_showBadge != null) {
				ckb_showBadge.Dispose ();
				ckb_showBadge = null;
			}

			if (btn_addBadge != null) {
				btn_addBadge.Dispose ();
				btn_addBadge = null;
			}

			if (btn_clear != null) {
				btn_clear.Dispose ();
				btn_clear = null;
			}
		}
	}
}
