
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using YACRScontrol;

namespace YACRSMac
{
    public partial class YACRSPanelController : MonoMac.AppKit.NSWindowController
    {
        public MainWindowController mainController;
        private bool inQuestion;
        public bool showSessionID;  //# needs set

        private graphDisplayController myGraphCtrl;
        private graphDisplay myGraph;

        NSTimer timer1;

        bool expanded;


        #region Constructors

        // Called when created from unmanaged code
        public YACRSPanelController(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public YACRSPanelController(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }
		
        // Call to load from the XIB/NIB file
        public YACRSPanelController()
            : base("YACRSPanel")
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {
            YACRSPanel tmp = this.Window;
            tmp.Controller = this;
            newQuBtn.Image = NSImage.ImageNamed("qmark.png");
            grapgBtn.Image = NSImage.ImageNamed("graph.png");
            // Changes to allow graph window at start
            grapgBtn.Enabled = true;
            addTimeBtn.Enabled = false;
            expanded = false;
            timer1 = NSTimer.CreateRepeatingScheduledTimer(1, delegate
                {
                    updateInfoDisplay();
                });
        }

        #endregion

        partial void closeBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            //mainController.Window.Display();
            mainController.Window.MakeKeyAndOrderFront(sender);
            NSApplication.SharedApplication.ActivateIgnoringOtherApps(true);
            this.Window.Close();

        }

        partial void graphBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            if(myGraphCtrl == null)
            {
                myGraphCtrl = new graphDisplayController();
            }
            myGraph = myGraphCtrl.Window;
            myGraph.HidesOnDeactivate = false;
            myGraph.MakeKeyAndOrderFront (this);
            myGraph.OrderFrontRegardless();
            myGraph.Level = NSWindowLevel.Dock;
            myGraph.StyleMask = NSWindowStyle.NonactivatingPanel;
            myGraphCtrl.showLatest();
             //myGraphCtrl.mainController = this;
        }

        partial void newQuBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            if (!inQuestion)
            {
                YACRSSession.Instance.startNewQuestion(new System.Drawing.PointF(Window.Frame.Left, Window.Frame.Top));
                setInQuestion(true);
            }
            else
            {
                YACRSSession.Instance.stopQuestion();
                setInQuestion(false);
            }

        }

        partial void ExpandBtn_click (MonoMac.Foundation.NSObject sender)
        {
            int currentQuSelID = 0;
            currentQuSel.RemoveAll();
            foreach (cls_globalQuType qt in YACRSSession.Instance.AvailableQus) 
            {
                currentQuSel.Add (new NSString[] {(NSString)(qt.ToString())});
                if (qt.M_id == YACRSSession.Instance.DefaultQuID)
                    currentQuSelID = currentQuSel.Count - 1;
            }
            if (currentQuSel.Count > 0)
                currentQuSel.SelectItem(currentQuSelID);

            RectangleF r = Window.Frame;
            if(expanded)
            {
                expanded = false;
                r.Y += 30;
                r.Height -= 30;
            }
            else
            {
                expanded = true;
                r.Y -= 30;
                r.Height += 30;
            }
            Window.SetFrame(r, true);
        }

        partial void currentQuSelChanged (MonoMac.Foundation.NSObject sender)
        {
            if(expanded)
            {
                YACRSSession.Instance.DefaultQuID = YACRSSession.Instance.AvailableQus[currentQuSel.SelectedIndex].M_id;
                ExpandBtn_click(sender);
            }
        }

        partial void addTimeBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            YACRSSession.Instance.addTime();
        }

        private void setInQuestion(bool value)
        {
            if (value == true)
            {
                //newQuBtn.Image = (Image)Properties.Resources.ResourceManager.GetObject("stop");
                newQuBtn.Image = NSImage.ImageNamed("stop.png");
                //grapgBtn.Enabled = false;
            }
            else
            {

                //newQuBtn.Image = (Image)Properties.Resources.ResourceManager.GetObject("qmark");
                newQuBtn.Image = NSImage.ImageNamed("qmark.png");
                if (YACRSSession.Instance.LastQuInstanceID > 0)
                {
                    grapgBtn.Enabled = true;
                    if(myGraphCtrl != null)
                        myGraphCtrl.showLatest();
                }
            }
            inQuestion = value;
        }

        private void updateInfoDisplay()
        {
            cls_questionResponseInfo ri = YACRSSession.Instance.questionInfo();
            if (ri != null)
            {
                if (ri.M_id > 0)
                {
                    //Console.WriteLine("Response count is : " + ri.M_responseCount.ToString());
                    QuID.StringValue = ri.M_questiontype;  // Variable should really be called title, but XML needs changed
                    if (ri.M_timeToGo != null)
                    {
                        addTimeBtn.Enabled = true;
                        captionLabel.StringValue = "Time (#resp)";
                        numberLabel.StringValue = ri.M_timeToGo.ToString() + " (" + ri.M_responseCount.ToString() + ")";
                        if (ri.M_timeToGo == 0)
                        {
                            YACRSSession.Instance.stopQuestion();
                            setInQuestion(false);
                        }
                    }
                    else
                    {
                        addTimeBtn.Enabled = false;
                        captionLabel.StringValue = "#resp/#users";
                        numberLabel.StringValue = ri.M_responseCount.ToString() + " / " + ri.M_totalUsers.ToString();
                    }
                    if (myGraphCtrl != null)
                        myGraphCtrl.setData(ri);
                    //if (!inQuestion)
                    //    setInQuestion(true);
                }
                else
                {
                    if (showSessionID)
                    {
                        QuID.StringValue = "";
                        ShowSessionID();
                    }
                    else
                    {
                        QuID.StringValue = YACRSSession.Instance.Detail.M_id.ToString();
                        captionLabel.StringValue = "active/total";
                        numberLabel.StringValue = ri.M_activeUsers.ToString() + " / " + ri.M_totalUsers.ToString();
                        if (inQuestion)
                            setInQuestion(false);
                    }
                }
            }
            else
            {
                ShowSessionID();
            }
        }

        private void ShowSessionID()
        {
            if (YACRSSession.Instance.Detail.M_id > 0)
            {
                captionLabel.StringValue = "Session ID";
                numberLabel.StringValue = YACRSSession.Instance.Detail.M_id.ToString();
            }
            else
            {
                captionLabel.StringValue = "";
                numberLabel.StringValue = "";
            }
        }



        //strongly typed window accessor
        public new YACRSPanel Window
        {
            get
            {
                return (YACRSPanel)base.Window;
            }
        }
    }
}

