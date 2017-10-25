
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace YACRSMac
{
    public partial class YACRSPanel : AppKit.NSPanel
    {
        public YACRSPanelController Controller;
        #region Constructors

        // Called when created from unmanaged code
        public YACRSPanel(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public YACRSPanel(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {
           
        }

        #endregion
        public override void MouseDown(NSEvent e)
        {
            base.MouseDown (e);
            Controller.showSessionID = !Controller.showSessionID;
            //theController.grabScreenAsPNG ();
        }

        public override void MouseDragged(NSEvent e)
        {
            base.MouseDragged (e);
            //Console.WriteLine("Mouse dragged " + e.AbsoluteX.ToString()+" delta "+e.DeltaX.ToString());
            CoreGraphics.CGPoint loc = this.Frame.Location;
            loc.X += e.DeltaX;
            loc.Y -= e.DeltaY;
            this.SetFrameOrigin(loc);
           
            //theController.grabScreenAsPNG ();
        }

    }
}

