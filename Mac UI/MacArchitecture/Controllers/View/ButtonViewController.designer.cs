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
	[Register ("ButtonViewController")]
	partial class ButtonViewController
	{
		[Outlet]
		MacArchitecture.UiElements.Button.CancelButton btn_cancel { get; set; }

		[Outlet]
		MacArchitecture.UiElements.Button.DefaultButton btn_default { get; set; }

		[Outlet]
		MacArchitecture.UiElements.Button.LinkButton btn_link { get; set; }

		[Outlet]
		MacArchitecture.UiElements.Button.StateButton btn_state { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_cancel { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_default { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_link { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_state { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_cancel != null) {
				btn_cancel.Dispose ();
				btn_cancel = null;
			}

			if (lbl_cancel != null) {
				lbl_cancel.Dispose ();
				lbl_cancel = null;
			}

			if (btn_default != null) {
				btn_default.Dispose ();
				btn_default = null;
			}

			if (lbl_default != null) {
				lbl_default.Dispose ();
				lbl_default = null;
			}

			if (btn_link != null) {
				btn_link.Dispose ();
				btn_link = null;
			}

			if (lbl_link != null) {
				lbl_link.Dispose ();
				lbl_link = null;
			}

			if (btn_state != null) {
				btn_state.Dispose ();
				btn_state = null;
			}

			if (lbl_state != null) {
				lbl_state.Dispose ();
				lbl_state = null;
			}
		}
	}
}
