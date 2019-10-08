
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using YACRScontrol;

namespace YACRSMac
{
    public partial class graphDisplayController : AppKit.NSWindowController
    {
        private graphView theGraph;

        private List<int> quids;
        private int cqid;

        #region Constructors

        // Called when created from unmanaged code
        public graphDisplayController(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public graphDisplayController(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }
		
        // Call to load from the XIB/NIB file
        public graphDisplayController()
            : base("graphDisplay")
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {
            graphDisplay tmp = this.Window;
            tmp.theController = this;

            theGraph = new graphView();
            theGraph.Frame = placeHolder2.Frame;
            if (graphBox != null)
            {
                graphBox.AddSubview(theGraph);
            }
            //placeHolder2.RemoveFromSuperview();

            float x = NSUserDefaults.StandardUserDefaults.FloatForKey("graphDisplayX");
            float y = NSUserDefaults.StandardUserDefaults.FloatForKey("graphDisplayY");
            float w = NSUserDefaults.StandardUserDefaults.FloatForKey("graphDisplayW");
            float h = NSUserDefaults.StandardUserDefaults.FloatForKey("graphDisplayH");
            if ((w > 0) && (h > 0))
            {
                CoreGraphics.CGRect restoreTo = new CoreGraphics.CGRect(x, y, w, h);
                tmp.SetFrame(restoreTo, false);
                resizeGraph();
            }

            showLatest();
        }

        #endregion

        public void showLatest()
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            cqid = YACRSSession.Instance.LastQuInstanceID;
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        public void resizeGraph()
        {
            theGraph.Frame = placeHolder2.Frame;
            theGraph.Display();
        }

        partial void backBtn_Click (Foundation.NSObject sender)
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            int nidx = quids.IndexOf(cqid)-1;
            if(nidx>=0)
                cqid = quids[nidx];
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        partial void closeBtn_Click (Foundation.NSObject sender)
        {
			NSUserDefaults.StandardUserDefaults.SetFloat((float)this.Window.Frame.X, "graphDisplayX");
            NSUserDefaults.StandardUserDefaults.SetFloat((float)this.Window.Frame.Y, "graphDisplayY");
            NSUserDefaults.StandardUserDefaults.SetFloat((float)this.Window.Frame.Width, "graphDisplayW");
            NSUserDefaults.StandardUserDefaults.SetFloat((float)this.Window.Frame.Height, "graphDisplayH");
            this.Window.Close();
        }

        partial void forwardBtn_Click (Foundation.NSObject sender)
        {
            quids = YACRSSession.Instance.getSessionQuestionIDs();
            int nidx = quids.IndexOf(cqid)+1;
            if((nidx>=0)&&(nidx < quids.Count))
                cqid = quids[nidx];
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo(cqid);
            setData(ri);
        }

        public void setData(cls_questionResponseInfo ri)
        {
            if (ri != null)
            {
                cqid = ri.M_id;
                theGraph.title = ri.M_questiontype;

                //quWebInfo.Hidden = false;
                //quWebInfo.MainFrameUrl = "http://www.gla.ac.uk/";

                Dictionary<string, int> data = new Dictionary<string, int>();

                if ((ri.M_displayURL != null) && (ri.M_displayURL != ""))
                {
                    quWebInfo.Hidden = false;
                    theGraph.Hidden = true;
                    quWebInfo.MainFrameUrl = YACRSSession.Instance.baseURL + ri.M_displayURL;
                }
                else
                {
                    quWebInfo.Hidden = true;
                    theGraph.Hidden = false;
                    foreach (cls_optionInfo oi in ri.M_optionInfo)
                    {
                        if (!data.ContainsKey(oi.M_title))
                        {
                            data.Add(oi.M_title, oi.M_count);
                        }
                    }
                }
                theGraph.theData = data;
                backBtn.Enabled = false;
                forwardBtn.Enabled = false;
                if ((quids != null) && (quids.Count > 1))
                {
                    if (cqid != quids[0])
                        backBtn.Enabled = true;
                    if (cqid != quids[quids.Count - 1])
                        forwardBtn.Enabled = true;
                }
                if (!theGraph.Hidden)
                {
                    theGraph.Display();

                }//theGraph.DrawRect(new System.Drawing.RectangleF(theGraph.Frame.Location, theGraph.Frame.Size));
                 //Invalidate();
            }
        }


        //strongly typed window accessor
        public new graphDisplay Window
        {
            get
            {
                return (graphDisplay)base.Window;
            }
        }
    }
}

