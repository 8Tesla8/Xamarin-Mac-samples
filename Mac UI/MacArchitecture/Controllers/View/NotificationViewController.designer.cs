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
	[Register ("NotificationViewController")]
	partial class NotificationViewController
	{
		[Outlet]
		AppKit.NSButton btn_banner { get; set; }

		[Outlet]
		AppKit.NSButton btn_reply { get; set; }

		[Outlet]
		AppKit.NSButton btn_simple { get; set; }

		[Outlet]
		AppKit.NSButton btn_timer { get; set; }

		[Outlet]
		AppKit.NSButton btn_withButtons { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_info { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_reply != null) {
				btn_reply.Dispose ();
				btn_reply = null;
			}

			if (btn_simple != null) {
				btn_simple.Dispose ();
				btn_simple = null;
			}

			if (btn_timer != null) {
				btn_timer.Dispose ();
				btn_timer = null;
			}

			if (btn_withButtons != null) {
				btn_withButtons.Dispose ();
				btn_withButtons = null;
			}

			if (lbl_info != null) {
				lbl_info.Dispose ();
				lbl_info = null;
			}

			if (btn_banner != null) {
				btn_banner.Dispose ();
				btn_banner = null;
			}
		}
	}
}
