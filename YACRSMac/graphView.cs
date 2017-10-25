using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using AppKit;

namespace YACRSMac
{
    public class graphView : AppKit.NSView
    {
        public Dictionary<string, int> theData;
        public string title;
         
        public graphView() : base()
        {
        }

        public override void DrawRect (CGRect dirtyRect)
        {
            NSColor.White.Set();
            NSGraphics.RectFill(this.VisibleRect());
            OnPaint();
            // draw a little cross in our view
   /*         NSColor.Black.Set ();
            NSBezierPath.StrokeLine (new PointF (-10.0f,0.0f), new PointF (10.0f,0.0f));
            NSBezierPath.StrokeLine (new PointF (0.0f,-10.0f), new PointF (0.0f,10.0f));

            NSColor.Yellow.Set();
            NSGraphics.RectFill(new RectangleF(20,20,40,60));
            NSColor.Black.Set ();
            NSGraphics.FrameRect(new RectangleF(20, 20, 40, 60));

            var objects = new object [] { NSFont.FromFontName ("Menlo", 48) };
            var keys = new object [] { NSAttributedString.FontAttributeName };
            var attributes = NSDictionary.FromObjectsAndKeys (objects, keys);
            NSString tmp = new NSString("A label");
            tmp.DrawString(new PointF(150, 150), attributes);
            NSGraphics.FrameRect(new RectangleF(150, 150, 40, 48));*/

        }

        private CGSize textSize(string str, NSDictionary attributes)
        {
            // The three components
            var storage   = new NSTextStorage ();
            var layout    = new NSLayoutManager ();
            var container = new NSTextContainer ();

            // Bind them
            layout.AddTextContainer (container);
            storage.AddLayoutManager (layout);

            storage.SetString (new NSAttributedString (str, attributes));

            // Compute
            layout.GetGlyphRange (container);

            // Get size
            CGSize size = layout.GetUsedRectForTextContainer (container).Size;
            return size;

        }

        private void DrawString(string str, NSDictionary fontInfo, NSColor color, int xpos, int ypos)
        {
            color.Set();
            NSString tmp = new NSString(str);
            tmp.DrawString(new CGPoint(xpos, ypos), fontInfo);
        }

        private void OnPaint()
        {
            int textHeight = (int)(this.Frame.Height / 15);
            var objects = new object [] { NSFont.FromFontName("Menlo", textHeight) };
            var keys = new object [] { "Helvetica" };
            NSDictionary txtFont = NSDictionary.FromObjectsAndKeys(objects, keys);

            if ((theData != null) && (theData.Count > 0))
            {
                // calculate sizes
                int colWidth = (int)(this.Frame.Width / (theData.Count + 2));
                int maxval = 1;
                foreach (KeyValuePair<string, int> dp in theData)
                {
                    maxval = (dp.Value > maxval) ? dp.Value : maxval;
                }
                int baseline = (int)(2 * textHeight);
				float heightMultiplier = ((float)this.Frame.Height - (4 * textHeight)) / maxval;
                CGSize stringSize = textSize(maxval.ToString(), txtFont);
                int lxpos = colWidth - (int)stringSize.Width - 10;
                int lypos = (int)(baseline + (heightMultiplier * maxval) - (stringSize.Height / 2));
                DrawString(maxval.ToString(), txtFont, NSColor.Black, lxpos, lypos);


                NSColor.Black.Set();
                NSBezierPath.StrokeLine(new CGPoint(colWidth, baseline), new CGPoint(colWidth * (theData.Count + 1), baseline));
                NSBezierPath.StrokeLine(new CGPoint(colWidth, baseline), new CGPoint(colWidth, baseline + (heightMultiplier * maxval)));
                NSBezierPath.StrokeLine(new CGPoint(colWidth - 5, baseline + (heightMultiplier * maxval)), new CGPoint(colWidth, baseline + (heightMultiplier * maxval)));

                DrawString(title, txtFont, NSColor.Black, 5, lypos + (int)stringSize.Height);

                int colPos = 0;
                foreach (KeyValuePair<string, int> dp in theData)
                {
                    colPos += colWidth;
                    int colCentre = colPos + colWidth / 2;
                    stringSize = textSize(dp.Key, txtFont);
                    lxpos = colCentre - (int)(stringSize.Width / 2);
                    lypos = baseline - -textHeight - textHeight / 4;
                    DrawString(dp.Key, txtFont, NSColor.Black, lxpos, lypos);
                    if (dp.Value > 0)
                    {
                        CGRect colRect = new CGRect(colPos, baseline, colWidth - 1, heightMultiplier * dp.Value);
                        NSColor.Blue.Set();
                        NSGraphics.RectFill(colRect);
                        NSColor.Black.Set();
                        NSGraphics.FrameRect(colRect);

                        //e.Graphics.FillRectangle(Brushes.Blue, colPos, baseline - heightMultiplier * dp.Value, colWidth - 1, heightMultiplier * dp.Value);
                
                    }
                }
            }
            else
            {
                CGSize stringSize = textSize("Ay", txtFont);
                int lypos = (int)this.Frame.Height - 2 * (int)stringSize.Height;
                if(title != null)
                    DrawString(title, txtFont, NSColor.Black, 5, lypos + (int)stringSize.Height);
                DrawString("No data to display", txtFont, NSColor.Black, 5, lypos + 2*(int)stringSize.Height);

            }
        }

    }
    
  
}

