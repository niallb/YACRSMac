// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace YACRSMac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton allowGuestsChk { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton allowQuReviewChk { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton allowTeacherQuChk { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton cancelBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField courseIdentifierEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField defaultQuActiveSecs { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox DefaultQuSel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField maxMessageLenghtEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton newSessionBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton OKBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox questionModeSel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox sessionListSel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton startBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField titleEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox ublogRoomSel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton visibleChk { get; set; }

		[Action ("newSessionBtn_Click:")]
		partial void newSessionBtn_Click (MonoMac.Foundation.NSObject sender);

		[Action ("onCancel:")]
		partial void onCancel (MonoMac.Foundation.NSObject sender);

		[Action ("OnGrabScreen:")]
		partial void OnGrabScreen (MonoMac.AppKit.NSButton sender);

		[Action ("OnListSelection:")]
		partial void OnListSelection (MonoMac.Foundation.NSObject sender);

		[Action ("onOK:")]
		partial void onOK (MonoMac.Foundation.NSObject sender);

		[Action ("OnSelectSession:")]
		partial void OnSelectSession (MonoMac.Foundation.NSObject sender);

		[Action ("settingChanged:")]
		partial void settingChanged (MonoMac.Foundation.NSObject sender);

		[Action ("startBtn_Click:")]
		partial void startBtn_Click (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (defaultQuActiveSecs != null) {
				defaultQuActiveSecs.Dispose ();
				defaultQuActiveSecs = null;
			}

			if (allowGuestsChk != null) {
				allowGuestsChk.Dispose ();
				allowGuestsChk = null;
			}

			if (allowQuReviewChk != null) {
				allowQuReviewChk.Dispose ();
				allowQuReviewChk = null;
			}

			if (allowTeacherQuChk != null) {
				allowTeacherQuChk.Dispose ();
				allowTeacherQuChk = null;
			}

			if (cancelBtn != null) {
				cancelBtn.Dispose ();
				cancelBtn = null;
			}

			if (courseIdentifierEdt != null) {
				courseIdentifierEdt.Dispose ();
				courseIdentifierEdt = null;
			}

			if (DefaultQuSel != null) {
				DefaultQuSel.Dispose ();
				DefaultQuSel = null;
			}

			if (maxMessageLenghtEdt != null) {
				maxMessageLenghtEdt.Dispose ();
				maxMessageLenghtEdt = null;
			}

			if (newSessionBtn != null) {
				newSessionBtn.Dispose ();
				newSessionBtn = null;
			}

			if (OKBtn != null) {
				OKBtn.Dispose ();
				OKBtn = null;
			}

			if (questionModeSel != null) {
				questionModeSel.Dispose ();
				questionModeSel = null;
			}

			if (sessionListSel != null) {
				sessionListSel.Dispose ();
				sessionListSel = null;
			}

			if (startBtn != null) {
				startBtn.Dispose ();
				startBtn = null;
			}

			if (titleEdt != null) {
				titleEdt.Dispose ();
				titleEdt = null;
			}

			if (ublogRoomSel != null) {
				ublogRoomSel.Dispose ();
				ublogRoomSel = null;
			}

			if (visibleChk != null) {
				visibleChk.Dispose ();
				visibleChk = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
