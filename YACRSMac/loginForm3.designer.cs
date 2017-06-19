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
	[Register ("loginForm3Controller")]
	partial class loginForm3Controller
	{
		[Outlet]
		MonoMac.AppKit.NSTextField messageEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSecureTextField PasswordEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField URLEdt { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField UsernameEdt { get; set; }

		[Action ("onCancel:")]
		partial void onCancel (MonoMac.Foundation.NSObject sender);

		[Action ("onOK:")]
		partial void onOK (MonoMac.Foundation.NSObject sender);

		[Action ("onURL:")]
		partial void onURL (MonoMac.Foundation.NSObject sender);
		
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
