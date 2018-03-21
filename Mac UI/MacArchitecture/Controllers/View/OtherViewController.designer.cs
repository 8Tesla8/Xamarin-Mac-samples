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
	[Register ("OtherViewController")]
	partial class OtherViewController
	{
		[Outlet]
		AppKit.NSButton btn_runApp { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_appPath { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_appVersion { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_buildVersion { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_currentUser { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_localization { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_osVersion { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_serialNumber { get; set; }

		[Outlet]
		AppKit.NSSegmentedControl sgm { get; set; }

		[Outlet]
		AppKit.NSTextField tf_appName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_appVersion != null) {
				lbl_appVersion.Dispose ();
				lbl_appVersion = null;
			}

			if (lbl_buildVersion != null) {
				lbl_buildVersion.Dispose ();
				lbl_buildVersion = null;
			}

			if (lbl_currentUser != null) {
				lbl_currentUser.Dispose ();
				lbl_currentUser = null;
			}

			if (lbl_localization != null) {
				lbl_localization.Dispose ();
				lbl_localization = null;
			}

			if (lbl_osVersion != null) {
				lbl_osVersion.Dispose ();
				lbl_osVersion = null;
			}

			if (lbl_serialNumber != null) {
				lbl_serialNumber.Dispose ();
				lbl_serialNumber = null;
			}

			if (sgm != null) {
				sgm.Dispose ();
				sgm = null;
			}

			if (tf_appName != null) {
				tf_appName.Dispose ();
				tf_appName = null;
			}

			if (lbl_appPath != null) {
				lbl_appPath.Dispose ();
				lbl_appPath = null;
			}

			if (btn_runApp != null) {
				btn_runApp.Dispose ();
				btn_runApp = null;
			}
		}
	}
}
