
using System;
using System.Collections.Generic;
using System.IO;
using MonoMac.Foundation;
using MonoMac.AppKit;

using MonoMac.CoreGraphics;
using System.Drawing;
using System.Drawing.Imaging;
using YACRScontrol;

namespace YACRSMac
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		public MainWindow theWindow;
        YACRSPanelController myPanelControl;
        YACRSPanel myPanel;

        private bool updatingSettings;
        private bool inSession;
        private bool inQuestion;
		public enum formState { nodata, unchanged, changed, unsaved }
		private formState state;
        List<cls_sessionInfo> sessions;

		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
			//Console.WriteLine ("Window controller initialised");
		}
		
		// Shared initialization code
		void Initialize ()
		{
			state = formState.nodata;
		}

		#endregion

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		public void prepare()
		{
			if (YACRSSession.Instance.CourseIdSupported) {
				courseIdentifierEdt.Enabled = true;
			} else {
				courseIdentifierEdt.Enabled = false;
			}
            int defaultQuID = NSUserDefaults.StandardUserDefaults.IntForKey("defaultQuID");
            int defaultQuSelID = 0;
			foreach (cls_globalQuType qt in YACRSSession.Instance.AvailableQus) {
				DefaultQuSel.Add (new NSString[] {(NSString)(qt.ToString())});
                if (qt.M_id == defaultQuID)
                    defaultQuSelID = DefaultQuSel.Count - 1;
			}
			if (DefaultQuSel.Count > 0)
                DefaultQuSel.SelectItem(defaultQuSelID);
			RefreshList ();
            questionModeSel.Add(new NSString("Teacher led (one question at a time)"));
            questionModeSel.Add(new NSString("Student paced"));
            ublogRoomSel.Add(new NSString("None"));
            ublogRoomSel.Add(new NSString("Full class"));
            ublogRoomSel.Add(new NSString("Personal (private)"));
            ublogRoomSel.Add(new NSString("Personal (public)"));
            OnSelectSession(this);
            enableAppropriateComponents ();
		}

        partial void startBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            YACRSSession.Instance.DefaultQuID = YACRSSession.Instance.AvailableQus[DefaultQuSel.SelectedIndex].M_id;
            NSUserDefaults.StandardUserDefaults.SetInt(YACRSSession.Instance.DefaultQuID, "defaultQuID");
            NSUserDefaults.StandardUserDefaults.SetInt(sessions[sessionListSel.SelectedIndex].M_id, "sessionID");
            YACRSSession.Instance.StartSession();
            if(myPanelControl==null)
                myPanelControl = new YACRSPanelController();
            myPanel = myPanelControl.Window;
            myPanel.HidesOnDeactivate = false;
            myPanel.MakeKeyAndOrderFront (this);
            myPanel.OrderFrontRegardless();
            myPanel.Level = NSWindowLevel.Dock;
            myPanel.StyleMask = NSWindowStyle.NonactivatingPanel;
            myPanelControl.mainController = this;
            //this.Window.OrderOut(sender);
            this.Window.Miniaturize(sender);
        }

		partial void onCancel (MonoMac.Foundation.NSObject sender)
		{
            if(state == formState.unsaved)
            {
                if(sessionListSel.SelectedIndex == -1)
                {
                    state = formState.nodata;
                    enableAppropriateComponents();                 
                }
                else
                {
                    OnSelectSession(sender);
                }
            }
            else
            {
                updateSessionEditFields();
                state = formState.unchanged;
                enableAppropriateComponents();
            }
		}

		partial void OnGrabScreen (MonoMac.AppKit.NSButton sender)
		{
		}

		partial void OnListSelection (MonoMac.Foundation.NSObject sender)
		{
            //Console.WriteLine("OnListSelection");
		}

		partial void onOK (MonoMac.Foundation.NSObject sender)
		{
            int tmpint;
            YACRSSession.Instance.Detail.M_title = titleEdt.StringValue;
            YACRSSession.Instance.Detail.M_allowGuests = allowGuestsChk.State == NSCellStateValue.On ? true : false;
            YACRSSession.Instance.Detail.M_visible = visibleChk.State == NSCellStateValue.On ? true : false;
            YACRSSession.Instance.Detail.M_questionMode = (cls_sessionDetail.qmode)questionModeSel.SelectedIndex;
            if(int.TryParse(defaultQuActiveSecs.StringValue, out tmpint))
                YACRSSession.Instance.Detail.M_defaultQuActiveSecs = tmpint;
            else
                YACRSSession.Instance.Detail.M_defaultQuActiveSecs = 0;
            YACRSSession.Instance.Detail.M_allowQuReview = allowQuReviewChk.State == NSCellStateValue.On ? true : false;
            YACRSSession.Instance.Detail.M_ublogRoom = (cls_sessionDetail.ublogmode)ublogRoomSel.SelectedIndex;
            if(int.TryParse(maxMessageLenghtEdt.StringValue, out tmpint))
                YACRSSession.Instance.Detail.M_maxMessagelength = tmpint;
            else
                YACRSSession.Instance.Detail.M_maxMessagelength = 160;
            YACRSSession.Instance.Detail.M_allowTeacherQu = allowTeacherQuChk.State == NSCellStateValue.On ? true : false;
            YACRSSession.Instance.Detail.M_courseIdentifier = courseIdentifierEdt.StringValue;
            if (YACRSSession.Instance.updateSession() > 0)
                state = formState.unchanged;
            else
                state = formState.nodata;
            RefreshList();
            enableAppropriateComponents();
		}

        partial void newSessionBtn_Click (MonoMac.Foundation.NSObject sender)
        {
            YACRSSession.Instance.newSession();
            state = formState.unsaved;
            updateSessionEditFields();
            enableAppropriateComponents();
        }

        partial void settingChanged (MonoMac.Foundation.NSObject sender)
        {
            if(!updatingSettings)
            {
                if(state == formState.unchanged)
                {
                    state = formState.changed;
                    enableAppropriateComponents();
                }
            }
        }

		partial void OnSelectSession (MonoMac.Foundation.NSObject sender)
		{
            int idx = sessionListSel.SelectedIndex;
            //Console.WriteLine("Session "+idx.ToString()+" - "+sessions[idx].M_title);
            if((idx >=0)&&(idx < sessions.Count)) 
            {
                YACRSSession.Instance.getSessionDetail(sessions[idx].M_id);
                state = formState.unchanged;
                updateSessionEditFields();
                enableAppropriateComponents();
            }
		}

        private void updateSessionEditFields()
        {
            updatingSettings = true;
            if (YACRSSession.Instance.Detail != null)
            {
                enableSessionDetailPanel(true);
                titleEdt.StringValue = YACRSSession.Instance.Detail.M_title;
                allowGuestsChk.State = YACRSSession.Instance.Detail.M_allowGuests ? NSCellStateValue.On : NSCellStateValue.Off;
                visibleChk.State = YACRSSession.Instance.Detail.M_visible ? NSCellStateValue.On : NSCellStateValue.Off;
                // tmp test
                int qmode = (int)YACRSSession.Instance.Detail.M_questionMode;
                //Console.WriteLine("qmode: "+YACRSSession.Instance.Detail.M_questionMode.ToString()+" ("+qmode.ToString()+")");
                if((qmode >= 0)&&(qmode < questionModeSel.Count))
                    questionModeSel.SelectItem(qmode);
                defaultQuActiveSecs.StringValue = YACRSSession.Instance.Detail.M_defaultQuActiveSecs.ToString();
                allowQuReviewChk.State = YACRSSession.Instance.Detail.M_allowQuReview ? NSCellStateValue.On : NSCellStateValue.Off;
                //ublogRoomSel.SelectItem((int)YACRSSession.Instance.Detail.M_ublogRoom);
                maxMessageLenghtEdt.StringValue = YACRSSession.Instance.Detail.M_maxMessagelength.ToString();
                allowTeacherQuChk.State = YACRSSession.Instance.Detail.M_allowTeacherQu ? NSCellStateValue.On : NSCellStateValue.Off;
                courseIdentifierEdt.StringValue  = YACRSSession.Instance.Detail.M_courseIdentifier;
                //ShowSessionID();
            }
            else
            {
                enableSessionDetailPanel(false);
                titleEdt.StringValue = "";
                courseIdentifierEdt.StringValue = "";
                allowGuestsChk.State = NSCellStateValue.Off;
                visibleChk.State = NSCellStateValue.On;
                //questionModeSel.SelectItem(0);
                defaultQuActiveSecs.StringValue = "0";
                allowQuReviewChk.State = NSCellStateValue.Off;
                //ublogRoomSel.SelectItem(0);
                maxMessageLenghtEdt.StringValue = "140";
                allowTeacherQuChk.State = NSCellStateValue.Off;
            }
            //endSessionChk.Enabled = false;
            updatingSettings = false;

        }

		private void RefreshList()
		{
            int defaultSessionID = NSUserDefaults.StandardUserDefaults.IntForKey("sessionID");
			sessions = YACRSSession.Instance.getSessionList();
			sessionListSel.RemoveAll ();
			foreach (cls_sessionInfo s in sessions)
			{
                sessionListSel.Add(new NSString[] {(NSString)(s.ToString())}); 
				if ((YACRSSession.Instance.Detail != null) && (YACRSSession.Instance.Detail.M_id == s.M_id))
					sessionListSel.SelectItem(sessionListSel.Count - 1);
                else if(defaultSessionID == s.M_id)
                    sessionListSel.SelectItem(sessionListSel.Count - 1);
			}
		}

		private void enableSessionDetailPanel(bool enable)
		{
			if (enable)
			{
				if (YACRSSession.Instance.CourseIdSupported) 
				{
					courseIdentifierEdt.Enabled = true;
				}
				titleEdt.Enabled = true;
				allowGuestsChk.Enabled = true;
				visibleChk.Enabled = true;
				questionModeSel.Enabled = true;
				defaultQuActiveSecs.Enabled = true;
				allowQuReviewChk.Enabled = true;
				ublogRoomSel.Enabled = true;
				maxMessageLenghtEdt.Enabled = true;
				allowTeacherQuChk.Enabled = true;
				OKBtn.Enabled = true;
				cancelBtn.Enabled = true;
			}
			else
			{
				courseIdentifierEdt.Enabled = false;
				titleEdt.Enabled = false;
				allowGuestsChk.Enabled = false;
				visibleChk.Enabled = false;
				questionModeSel.Enabled = false;
				defaultQuActiveSecs.Enabled = false;
				allowQuReviewChk.Enabled = false;
				ublogRoomSel.Enabled = false;
				maxMessageLenghtEdt.Enabled = false;
				allowTeacherQuChk.Enabled = false;
				OKBtn.Enabled = false;
				cancelBtn.Enabled = false;
			}
		}

		private void enableAppropriateComponents()
		{
			switch (state)
			{
			case formState.nodata:
				sessionListSel.Enabled = true;
				enableSessionDetailPanel(false);
				newSessionBtn.Enabled = true;
				startBtn.Enabled = false;
				OKBtn.Enabled = false;
				cancelBtn.Enabled = false;
				OKBtn.SetTitleWithMnemonic("Create");
				break;
			case formState.unchanged:
				sessionListSel.Enabled = true;
				enableSessionDetailPanel(true);
				newSessionBtn.Enabled = true;
				if ((YACRSSession.Instance.Detail.M_questionMode == cls_sessionDetail.qmode.teacherled)&&(DefaultQuSel.SelectedIndex >= 0))
					startBtn.Enabled = true;
				else
					startBtn.Enabled = false;
				OKBtn.Enabled = false;
				cancelBtn.Enabled = false;
				OKBtn.SetTitleWithMnemonic("Update");
				break;
			case formState.changed:
				sessionListSel.Enabled = false;
				enableSessionDetailPanel(true);
				newSessionBtn.Enabled = false;
				startBtn.Enabled = false;
				OKBtn.Enabled = true;
				cancelBtn.Enabled = true;
				OKBtn.SetTitleWithMnemonic("Update");
				break;
			case formState.unsaved:
				sessionListSel.Enabled = false;
				enableSessionDetailPanel(true);
				newSessionBtn.Enabled = false;
				startBtn.Enabled = false;
				if(titleEdt.StringValue.Length > 0)
					OKBtn.Enabled = true;
				else
					OKBtn.Enabled = true;
				cancelBtn.Enabled = true;
				//OKBtn.SetTitleWithMnemonic("Create");
				break;
			}
		}
            
	}
}

