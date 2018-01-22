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
	[Register ("TreeTableController")]
	partial class TreeTableController
	{
		[Outlet]
		MacArchitecture.UiElements.Table.Tree.CheckboxTreeTable tblT_checkbox { get; set; }

		[Outlet]
		AppKit.NSTextView txtv_checkbox { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tblT_checkbox != null) {
				tblT_checkbox.Dispose ();
				tblT_checkbox = null;
			}

			if (txtv_checkbox != null) {
				txtv_checkbox.Dispose ();
				txtv_checkbox = null;
			}
		}
	}
}
