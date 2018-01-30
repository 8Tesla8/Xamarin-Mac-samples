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
	[Register ("TextFieldViewController")]
	partial class TextFieldViewController
	{
		[Outlet]
		AppKit.NSTextField lbl_delegate { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_formatter { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_inputController { get; set; }

		[Outlet]
		AppKit.NSStepper stp { get; set; }

		[Outlet]
		AppKit.NSTextField tf { get; set; }

		[Outlet]
		AppKit.NSTextField tf_delegate { get; set; }

		[Outlet]
		AppKit.NSTextField tf_increment { get; set; }

		[Outlet]
		AppKit.NSTextField tf_max { get; set; }

		[Outlet]
		AppKit.NSTextField tf_min { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tf != null) {
				tf.Dispose ();
				tf = null;
			}

			if (stp != null) {
				stp.Dispose ();
				stp = null;
			}

			if (tf_min != null) {
				tf_min.Dispose ();
				tf_min = null;
			}

			if (tf_max != null) {
				tf_max.Dispose ();
				tf_max = null;
			}

			if (tf_increment != null) {
				tf_increment.Dispose ();
				tf_increment = null;
			}

			if (lbl_inputController != null) {
				lbl_inputController.Dispose ();
				lbl_inputController = null;
			}

			if (lbl_formatter != null) {
				lbl_formatter.Dispose ();
				lbl_formatter = null;
			}

			if (lbl_delegate != null) {
				lbl_delegate.Dispose ();
				lbl_delegate = null;
			}

			if (tf_delegate != null) {
				tf_delegate.Dispose ();
				tf_delegate = null;
			}
		}
	}
}
