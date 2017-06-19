using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace YACRSMac
{
	class MainClass
	{
		static void Main (string[] args)
		{
            IntPtr h = Dlfcn.dlopen (MonoMac.Constants.CoreGraphicsLibrary, 0);
			NSApplication.Init ();
			NSApplication.Main (args);
            Dlfcn.dlclose (h);
		}
	}
}

