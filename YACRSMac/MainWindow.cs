
using System;
using System.Collections.Generic;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Timers;
using YACRScontrol;


namespace YACRSMac
{
	public partial class MainWindow : MonoMac.AppKit.NSWindow
	{
		MainWindowController theController;
		#region Constructors
		NSTimer timer1;
        YACRSPanelController myPanelControl;
        YACRSPanel myPanel;
		loginForm3Controller lfc;
		loginForm3 lf;


		// Called when created from unmanaged code
		public MainWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
			//this.SetFrameTopLeftPoint(new System.Drawing.PointF(200, 1000));
			/*myPanel = new YACRSCtrlPanel ();
			myPanel.HidesOnDeactivate = false;
			myPanel.MakeKeyAndOrderFront (this);
			myPanel.OrderFrontRegardless();
			myPanel.Level = NSWindowLevel.Dock;
			myPanel.StyleMask = NSWindowStyle.NonactivatingPanel;
			myPanel.theController = theController;*/

            /*myPanelControl = new YACRSPanelController();
            myPanel = myPanelControl.Window;
            myPanel.HidesOnDeactivate = false;
            myPanel.MakeKeyAndOrderFront (this);
            myPanel.OrderFrontRegardless();
            myPanel.Level = NSWindowLevel.Dock;
            myPanel.StyleMask = NSWindowStyle.NonactivatingPanel;*/
            //myPanel.theController = theController;

		}

		public override void MouseDown(NSEvent e)
		{
			base.MouseDown (e);
		}

		private void timer1_Tick()
		{
				//this.OrderFrontRegardless();
			    //this.Level = NSWindowLevel.Dock;
				//Console.WriteLine ("timer " + this.ToString ());
		}

		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			theController = (MainWindowController)this.WindowController;
			theController.theWindow = this;
			//Console.WriteLine ("Window initialised");
			lfc = new loginForm3Controller();
			lfc.Window.MakeKeyAndOrderFront (this);
			lfc.loadSettings ();
            if (NSApplication.SharedApplication.RunModalForWindow(lfc.Window) > 0)
            {
                theController.prepare();
            }
            else
            {
                NSApplication.SharedApplication.Terminate(this);
            }
            this.WillClose += delegate
            {
                    NSApplication.SharedApplication.Terminate(this);
            }; 
		}



		#endregion
	}
}

