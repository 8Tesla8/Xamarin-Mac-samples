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
	[Register ("OrdinaryTableViewController")]
	partial class OrdinaryTableViewController
	{
		[Outlet]
		AppKit.NSButton btn_reloadData { get; set; }

		[Outlet]
		AppKit.NSTableView tbl_cells { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tbl_cells != null) {
				tbl_cells.Dispose ();
				tbl_cells = null;
			}

			if (btn_reloadData != null) {
				btn_reloadData.Dispose ();
				btn_reloadData = null;
			}
		}
	}
}
