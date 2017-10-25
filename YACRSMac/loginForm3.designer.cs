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
	[Register ("loginForm3Controller")]
	partial class loginForm3Controller
	{
		[Outlet]
		AppKit.NSTextField messageEdt { get; set; }

		[Outlet]
		AppKit.NSSecureTextField PasswordEdt { get; set; }

		[Outlet]
		AppKit.NSTextField URLEdt { get; set; }

		[Outlet]
		AppKit.NSTextField UsernameEdt { get; set; }

		[Action ("onCancel:")]
		partial void onCancel (Foundation.NSObject sender);

		[Action ("onOK:")]
		partial void onOK (Foundation.NSObject sender);

		[Action ("onURL:")]
		partial void onURL (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (URLEdt != null) {
				URLEdt.Dispose ();
				URLEdt = null;
			}

			if (UsernameEdt != null) {
				UsernameEdt.Dispose ();
				UsernameEdt = null;
			}

			if (PasswordEdt != null) {
				PasswordEdt.Dispose ();
				PasswordEdt = null;
			}

			if (messageEdt != null) {
				messageEdt.Dispose ();
				messageEdt = null;
			}
		}
	}

	[Register ("loginForm3")]
	partial class loginForm3
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
