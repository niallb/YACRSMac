// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace YACRSMac
{
	[Register ("YACRSPanelController")]
	partial class YACRSPanelController
	{
		[Outlet]
		AppKit.NSButton addTimeBtn { get; set; }

		[Outlet]
		AppKit.NSTextField captionLabel { get; set; }

		[Outlet]
		AppKit.NSComboBox currentQuSel { get; set; }

		[Outlet]
		AppKit.NSButton ExpandBtn { get; set; }

		[Outlet]
		AppKit.NSButton grapgBtn { get; set; }

		[Outlet]
		AppKit.NSButton newQuBtn { get; set; }

		[Outlet]
		AppKit.NSTextField numberLabel { get; set; }

		[Outlet]
		AppKit.NSTextField QuID { get; set; }

		[Action ("addTimeBtn_Click:")]
		partial void addTimeBtn_Click (Foundation.NSObject sender);

		[Action ("closeBtn_Click:")]
		partial void closeBtn_Click (Foundation.NSObject sender);

		[Action ("currentQuSelChanged:")]
		partial void currentQuSelChanged (Foundation.NSObject sender);

		[Action ("ExpandBtn_click:")]
		partial void ExpandBtn_click (Foundation.NSObject sender);

		[Action ("graphBtn_Click:")]
		partial void graphBtn_Click (Foundation.NSObject sender);

		[Action ("newQuBtn_Click:")]
		partial void newQuBtn_Click (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (addTimeBtn != null) {
				addTimeBtn.Dispose ();
				addTimeBtn = null;
			}

			if (captionLabel != null) {
				captionLabel.Dispose ();
				captionLabel = null;
			}

			if (currentQuSel != null) {
				currentQuSel.Dispose ();
				currentQuSel = null;
			}

			if (ExpandBtn != null) {
				ExpandBtn.Dispose ();
				ExpandBtn = null;
			}

			if (grapgBtn != null) {
				grapgBtn.Dispose ();
				grapgBtn = null;
			}

			if (newQuBtn != null) {
				newQuBtn.Dispose ();
				newQuBtn = null;
			}

			if (numberLabel != null) {
				numberLabel.Dispose ();
				numberLabel = null;
			}

			if (QuID != null) {
				QuID.Dispose ();
				QuID = null;
			}
		}
	}

	[Register ("YACRSPanel")]
	partial class YACRSPanel
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
