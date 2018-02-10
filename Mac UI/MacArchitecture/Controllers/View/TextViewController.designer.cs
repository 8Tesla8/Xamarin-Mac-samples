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
	[Register ("TextViewController")]
	partial class TextViewController
	{
		[Outlet]
		MacArchitecture.UiElements.TextView.BaseTextView txtv_base { get; set; }

		[Outlet]
		MacArchitecture.UiElements.TextView.EditableTextView txtv_editable { get; set; }

		[Outlet]
		MacArchitecture.UiElements.TextView.HtmlTextView txtv_html { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtv_base != null) {
				txtv_base.Dispose ();
				txtv_base = null;
			}

			if (txtv_html != null) {
				txtv_html.Dispose ();
				txtv_html = null;
			}

			if (txtv_editable != null) {
				txtv_editable.Dispose ();
				txtv_editable = null;
			}
		}
	}
}
