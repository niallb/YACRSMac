
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace YACRSMac
{
	public partial class loginForm3 : AppKit.NSWindow
	{
		#region Constructors

		// Called when created from unmanaged code
		public loginForm3 (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public loginForm3 (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion
	}
}

