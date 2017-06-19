using System;
using System.IO;
using MonoMac.Foundation;
using MonoMac.AppKit;

using System.Runtime.InteropServices;
using MonoMac.ObjCRuntime;

using MonoMac.CoreGraphics;
using System.Drawing;
using System.Drawing.Imaging;

namespace YACRScontrol
{
    public class YACRSUtil
    {
        [DllImport (CoreGraphicsLibrary)]
        static extern IntPtr CGWindowListCreateImage (RectangleF screenBounds, CGWindowListOption windowOption, uint windowID, CGWindowImageOption imageOption);

        private static int imgWidth = 450;

        private static CGImage screenImage;

        public YACRSUtil()
        {
        }
        public const string CoreGraphicsLibrary = "/System/Library/Frameworks/ApplicationServices.framework/Versions/A/Frameworks/CoreGraphics.framework/CoreGraphics";

        public static CGImage ScreenImage2 (int windownumber, RectangleF bounds, CGWindowListOption windowOption, CGWindowImageOption imageOption)
        {
            IntPtr imageRef = CGWindowListCreateImage(bounds, windowOption, (uint)windownumber, imageOption);
            return new CGImage(imageRef);  
        }

        public static byte[] grabScreenAsPNG(PointF containing)
        {
            // Grab screen
            // Mac stuff from http://stackoverflow.com/questions/18851247/screen-capture-on-osx-using-monomac
            NSScreen screen = NSScreen.MainScreen;
            if ((containing.X >= 0)&&(containing.Y >= 0))
            {
                int idx = 0;
                bool found = false;
                while (!found && (idx < NSScreen.Screens.Length))
                {
                    if (NSScreen.Screens[idx].Frame.Contains(containing))
                    {
                        found = true;
                        screen = NSScreen.Screens[idx];
                    }
                    idx++;
                }
            }
       
            //System.Drawing.RectangleF bounds = new RectangleF(0,0,screen.Frame.GetMaxX(),screen.Frame.GetMaxY());
            System.Drawing.RectangleF bounds = new RectangleF(screen.Frame.GetMinX() ,screen.Frame.GetMinY() ,screen.Frame.GetMaxX(),screen.Frame.GetMaxY());
            System.Drawing.Image si2;

            //  CGImage screenImage = MonoMac.CoreGraphics.CGImage.ScreenImage(0,bounds);
            screenImage = ScreenImage2(0, bounds, CGWindowListOption.All, CGWindowImageOption.Default);


#pragma warning disable XS0001 // Find usages of mono todo items
            using(NSBitmapImageRep imageRep = new NSBitmapImageRep(screenImage))
            {
                NSDictionary properties = NSDictionary.FromObjectAndKey(new NSNumber(1.0), new NSString("NSImageCompressionFactor"));
                using(NSData tiffData = imageRep.RepresentationUsingTypeProperties(NSBitmapImageFileType.Png, properties))
                {

                    using (var ms = new MemoryStream())

                    {
                        tiffData.AsStream().CopyTo(ms);
                        si2 = System.Drawing.Image.FromStream (ms, true);
                    }
                }
            }


            int newHeight = (int)((si2.Height * imgWidth) / si2.Width);
            Bitmap resized = new Bitmap(imgWidth, newHeight, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage (resized);
            g.DrawImage (si2, 0, 0, imgWidth, newHeight);


            screenImage.Dispose ();
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                resized.Save(stream, ImageFormat.Png);
                result = stream.ToArray();
            }
            return result;
        }
#pragma warning restore XS0001 // Find usages of mono todo items

    }
}

