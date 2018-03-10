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
		AppKit.NSButton btn_copyCell { get; set; }

		[Outlet]
		AppKit.NSButton btn_copyRow { get; set; }

		[Outlet]
		AppKit.NSButton btn_updateColumn { get; set; }

		[Outlet]
		AppKit.NSButton btn_updateRow { get; set; }

		[Outlet]
		AppKit.NSTableView tbl { get; set; }

		[Outlet]
		AppKit.NSTableView tbl_cells { get; set; }

		[Outlet]
		AppKit.NSTextField tf_column { get; set; }

		[Outlet]
		AppKit.NSTextField tf_row { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tbl != null) {
				tbl.Dispose ();
				tbl = null;
			}

			if (tbl_cells != null) {
				tbl_cells.Dispose ();
				tbl_cells = null;
			}

			if (btn_updateColumn != null) {
				btn_updateColumn.Dispose ();
				btn_updateColumn = null;
			}

			if (btn_copyCell != null) {
				btn_copyCell.Dispose ();
				btn_copyCell = null;
			}

			if (btn_copyRow != null) {
				btn_copyRow.Dispose ();
				btn_copyRow = null;
			}

			if (tf_row != null) {
				tf_row.Dispose ();
				tf_row = null;
			}

			if (tf_column != null) {
				tf_column.Dispose ();
				tf_column = null;
			}

			if (btn_updateRow != null) {
				btn_updateRow.Dispose ();
				btn_updateRow = null;
			}
		}
	}
}
