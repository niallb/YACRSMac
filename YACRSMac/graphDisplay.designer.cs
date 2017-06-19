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
	[Register ("graphDisplayController")]
	partial class graphDisplayController
	{
		[Outlet]
		MonoMac.AppKit.NSButton backBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton forwardBtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSBox graphBox { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView placeHolder { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView placeHolder2 { get; set; }

		[Outlet]
		MonoMac.WebKit.WebView quWebInfo { get; set; }

		[Outlet]
		MonoMac.AppKit.NSImageView resizeArea { get; set; }

		[Action ("backBtn_Click:")]
		partial void backBtn_Click (MonoMac.Foundation.NSObject sender);

		[Action ("closeBtn_Click:")]
		partial void closeBtn_Click (MonoMac.Foundation.NSObject sender);

		[Action ("forwardBtn_Click:")]
		partial void forwardBtn_Click (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (quWebInfo != null) {
				quWebInfo.Dispose ();
				quWebInfo = null;
			}

			if (backBtn != null) {
				backBtn.Dispose ();
				backBtn = null;
			}

			if (forwardBtn != null) {
				forwardBtn.Dispose ();
				forwardBtn = null;
			}

			if (graphBox != null) {
				graphBox.Dispose ();
				graphBox = null;
			}

			if (placeHolder != null) {
				placeHolder.Dispose ();
				placeHolder = null;
			}

			if (placeHolder2 != null) {
				placeHolder2.Dispose ();
				placeHolder2 = null;
			}

			if (resizeArea != null) {
				resizeArea.Dispose ();
				resizeArea = null;
			}
		}
	}

	[Register ("graphDisplay")]
	partial class graphDisplay
	{
		[Outlet]
		MonoMac.AppKit.NSImageView resizeArea { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (resizeArea != null) {
				resizeArea.Dispose ();
				resizeArea = null;
			}
		}
	}
}
