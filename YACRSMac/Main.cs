using System;
using AppKit;
using ObjCRuntime;

namespace YACRSMac
{
    static class MainClass
	{
        static void Main(string[] args)
		{
            IntPtr h = Dlfcn.dlopen (Constants.CoreGraphicsLibrary, 0);
			NSApplication.Init();
			NSApplication.Main(args);
            Dlfcn.dlclose (h);
		}
	}
}

