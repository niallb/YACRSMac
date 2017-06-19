
using System;
using System.Collections.Generic;
using System.ComponentModel;
using MonoMac.Foundation;
using MonoMac.AppKit;
using YACRScontrol;

namespace YACRSMac
{
	public partial class loginForm3Controller : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public loginForm3Controller (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public loginForm3Controller (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public loginForm3Controller () : base ("loginForm3")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			//URLEdt.StringValue = "URL here";
		}

		#endregion

		//strongly typed window accessor
		public new loginForm3 Window {
			get {
				return (loginForm3)base.Window;
			}
		}

		partial void onCancel (MonoMac.Foundation.NSObject sender)
		{
			NSApplication.SharedApplication.StopModalWithCode(0);
			Window.Close();
		}

		partial void onOK (MonoMac.Foundation.NSObject sender)
		{
			messageEdt.TextColor = NSColor.Black;
			messageEdt.StringValue = "Logging in";
			if(YACRSSession.Instance.AttemptLogin(UsernameEdt.StringValue, PasswordEdt.StringValue))
			{
                NSUserDefaults.StandardUserDefaults.SetString(UsernameEdt.StringValue, "username");
				NSApplication.SharedApplication.StopModalWithCode(1);
				Window.Close();
			}
			else
			{
				messageEdt.TextColor = NSColor.Red;
				messageEdt.StringValue = YACRSSession.Instance.LastError;
				PasswordEdt.StringValue = "";
			}
		}

		public void loadSettings()
		{
            string url = NSUserDefaults.StandardUserDefaults.StringForKey("ServerURL");
            if (url != null) {
                URLEdt.StringValue = url;
                Window.MakeFirstResponder(UsernameEdt);
            }
            string username = NSUserDefaults.StandardUserDefaults.StringForKey("username");
            if (username != null) {
                UsernameEdt.StringValue = username;
                Window.MakeFirstResponder(PasswordEdt);
            }
		}

		partial void onURL (MonoMac.Foundation.NSObject sender)
		{
			messageEdt.TextColor = NSColor.Black;
			//Console.WriteLine("URL Event?");
            string fixedURL;
            messageEdt.StringValue = YACRSSession.Instance.SetAndCheckURL(URLEdt.StringValue, out fixedURL);
			if(YACRSSession.Instance.ServerOK)
			{
				//NSString url = new NSString(URLEdt.StringValue);
				//NSUserDefaults.StandardUserDefaults.SetValueForKey(url, new NSString("ServerURL"));
				NSUserDefaults.StandardUserDefaults.SetString(URLEdt.StringValue, "ServerURL");
			}
		}

	}
}

