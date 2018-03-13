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
	[Register ("TreeTableViewController")]
	partial class TreeTableViewController
	{
		[Outlet]
		AppKit.NSOutlineView tblT { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tblT != null) {
				tblT.Dispose ();
				tblT = null;
			}
		}
	}
}
