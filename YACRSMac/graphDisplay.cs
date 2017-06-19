
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace YACRSMac
{
    public partial class graphDisplay : MonoMac.AppKit.NSPanel
    {
        public graphDisplayController theController;
        #region Constructors

        // Called when created from unmanaged code
        public graphDisplay(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public graphDisplay(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {

        }

       

        #endregion

        private void fixResize()
        {

            if (theController != null)
                theController.resizeGraph();
            //resizeArea.SetFrameOrigin(new System.Drawing.PointF(this.Frame.Bottom-resizeArea.Frame.Height, this.Frame.Right-resizeArea.Frame.Width));

        }

        public override void MouseDragged(NSEvent e)
        {
            base.MouseDragged (e);
            System.Drawing.PointF loc = this.Frame.Location;
            System.Drawing.PointF tl = new System.Drawing.PointF(this.Frame.Top, this.Frame.Left);

            if (resizeArea.Frame.Contains(e.LocationInWindow))
            {
                Console.WriteLine("Mouse dragged " + e.AbsoluteX.ToString()+" delta "+e.DeltaX.ToString());
                tl.X += e.DeltaX;
                loc.Y -= e.DeltaY;
                tl.Y += e.DeltaY;
     
                this.SetContentSize(new System.Drawing.SizeF(this.Frame.Width+e.DeltaX, this.Frame.Height+e.DeltaY));
                this.SetFrameOrigin(loc);
                fixResize();
                //this.SetFrameTopLeftPoint(tl);

            }
            else
            {
                loc.X += e.DeltaX;
                loc.Y -= e.DeltaY;
                this.SetFrameOrigin(loc);
            }

        }
    }
}

