using System;
using System.IO;
using Foundation;
using AppKit;
using ImageIO;

using System.Runtime.InteropServices;
using ObjCRuntime;

using CoreGraphics;
//using System.Drawing.Imaging;

namespace YACRScontrol
{
    public class YACRSUtil
    {
        [DllImport (CoreGraphicsLibrary)]
        static extern IntPtr CGWindowListCreateImage (CGRect screenBounds, CGWindowListOption windowOption, uint windowID, CGWindowImageOption imageOption);

        private static int imgWidth = 450;

        private static CGImage screenImage;

        public YACRSUtil()
        {
        }

        public const string CoreGraphicsLibrary = "/System/Library/Frameworks/ApplicationServices.framework/Versions/A/Frameworks/CoreGraphics.framework/CoreGraphics";

        public static CGImage ScreenImage2 (int windownumber, CGRect bounds, CGWindowListOption windowOption, CGWindowImageOption imageOption)
        {
            IntPtr imageRef = CGWindowListCreateImage(bounds, windowOption, (uint)windownumber, imageOption);
            return new CGImage(imageRef);  
        }

        public static byte[] grabScreenAsPNG(CGPoint containing)
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
            CGRect bounds = new CGRect((float)screen.Frame.GetMinX() ,(float)screen.Frame.GetMinY() ,(float)screen.Frame.GetMaxX(),(float)screen.Frame.GetMaxY());
			//System.Drawing.Image si2;
			//NSImage si2;

            //  CGImage screenImage = MonoMac.CoreGraphics.CGImage.ScreenImage(0,bounds);
            screenImage = ScreenImage2(0, bounds, CGWindowListOption.All, CGWindowImageOption.Default);


            #pragma warning disable XS0001 // Find usages of mono todo items
            /*using(NSBitmapImageRep imageRep = new NSBitmapImageRep(screenImage))
            {
                NSDictionary properties = NSDictionary.FromObjectAndKey(new NSNumber(1.0), new NSString("NSImageCompressionFactor"));
                using(NSData tiffData = imageRep.RepresentationUsingTypeProperties(NSBitmapImageFileType.Png, properties))
                {

                    using (var ms = new MemoryStream())

                    {
                        tiffData.AsStream().CopyTo(ms);
                        si2 = NSImage.FromStream(ms);
                        //si2 = System.Drawing.Image.FromStream (ms, true);
                    }
                }
            }*/
			NSBitmapImageRep si2 = new NSBitmapImageRep(screenImage);



            int newHeight = (int)((si2.Size.Height * imgWidth) / si2.Size.Width);
			CGSize destSize = new CGSize(imgWidth, newHeight);
			NSImage resized2 = new NSImage(destSize);
            resized2.LockFocus();
            CGRect sz = new CGRect(0, 0, imgWidth, newHeight);
            //si2.DrawInRect(sz, new CGRect(0, 0, si2.Size.Width, si2.Size.Height), NSCompositingOperation.SourceOver, 1);
            si2.DrawInRect(sz);
            resized2.UnlockFocus();
            resized2.Size = destSize;

            //Bitmap resized = new Bitmap(imgWidth, newHeight, PixelFormat.Format24bppRgb);
            //Graphics g = Graphics.FromImage (resized);
            //g.DrawImage (si2, 0, 0, imgWidth, newHeight);

            NSBitmapImageRep newRep = new NSBitmapImageRep(resized2.AsCGImage(ref sz, null, null));
            NSData pngData = newRep.RepresentationUsingTypeProperties(NSBitmapImageFileType.Png);

            screenImage.Dispose ();

            byte[] result = null;
			
            result = pngData.ToArray();
			//using (MemoryStream stream = new MemoryStream())
            //{
            //    
            //
			//	resized.Save(stream, ImageFormat.Png);
            //    result = stream.ToArray();
            //}
            return result;
        }
#pragma warning restore XS0001 // Find usages of mono todo items

    }
}

