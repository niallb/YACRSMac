/* cls_sessionDetail.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-sessionDetail
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-sessionDetail

namespace YACRScontrol
{
    public class cls_sessionDetail : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private int id;
        private string m_ownerID;
        private string m_title;
        private string m_created;
        private bool m_allowGuests;
        private bool m_visible;
        private qmode m_questionMode;
        private int m_defaultQuActiveSecs;
        private bool m_allowQuReview;
        private ublogmode m_ublogRoom;
        private int m_maxMessagelength;
        private bool m_allowTeacherQu;
        private string m_courseIdentifier;
        #endregion 
//USERCODE-SECTION-sessionDetail-uservars
// Put code here.
//ENDUSERCODE-SECTION-sessionDetail-uservars

        public enum qmode {teacherled, studentpaced };

        public enum ublogmode {none, classblog, privateblog, publicblog };

        #region XMLpg_generated_code

        public cls_sessionDetail() : this (null) {}

        public cls_sessionDetail(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_ownerID = "";
            m_title = "";
            m_created = "";
            m_courseIdentifier = "";
        }

        public int M_id
        {
            get { return id; }
            set { id = value; }
        }

        public string M_ownerID
        {
            get { return m_ownerID; }
            set { m_ownerID = value; }
        }

        public string M_title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        public string M_created
        {
            get { return m_created; }
            set { m_created = value; }
        }

        public bool M_allowGuests
        {
            get { return m_allowGuests; }
            set { m_allowGuests = value; }
        }

        public bool M_visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        public qmode M_questionMode
        {
            get { return m_questionMode; }
            set { m_questionMode = value; }
        }

        public int M_defaultQuActiveSecs
        {
            get { return m_defaultQuActiveSecs; }
            set { m_defaultQuActiveSecs = value; }
        }

        public bool M_allowQuReview
        {
            get { return m_allowQuReview; }
            set { m_allowQuReview = value; }
        }

        public ublogmode M_ublogRoom
        {
            get { return m_ublogRoom; }
            set { m_ublogRoom = value; }
        }

        public int M_maxMessagelength
        {
            get { return m_maxMessagelength; }
            set { m_maxMessagelength = value; }
        }

        public bool M_allowTeacherQu
        {
            get { return m_allowTeacherQu; }
            set { m_allowTeacherQu = value; }
        }

        public string M_courseIdentifier
        {
            get { return m_courseIdentifier; }
            set { m_courseIdentifier = value; }
        }

        internal override void setOwner(cls_YACRSResponse n_owner)
        {
            __owner = n_owner;
        }

        public string toXML(bool neat)
        {
            return toXML(neat, 0);
        }

        public string toXML(bool neat, int indent)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "";
            if (neat) output += "\n" +  pad;
            output += "<sessionDetail";
            // attributes
            output += " id=\"" + id.ToString() + "\"";
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            output += "<ownerID>" + m_ownerID.ToString() + "</ownerID>";
            if (neat) output += "\n" + pad + "    ";
            output += "<title>" + m_title.ToString() + "</title>";
            if (neat) output += "\n" + pad + "    ";
            output += "<created>" + m_created.ToString() + "</created>";
            if (neat) output += "\n" + pad + "    ";
            if (m_allowGuests)
                output += "<allowGuests>true</allowGuests>";
            else
                output += "<allowGuests>false</allowGuests>";
            if (neat) output += "\n" + pad + "    ";
            if (m_visible)
                output += "<visible>true</visible>";
            else
                output += "<visible>false</visible>";
            if (neat) output += "\n" + pad + "    ";
            output += "<questionMode>" + m_questionMode.ToString() + "</questionMode>";
            if (neat) output += "\n" + pad + "    ";
            output += "<defaultQuActiveSecs>" + m_defaultQuActiveSecs.ToString() + "</defaultQuActiveSecs>";
            if (neat) output += "\n" + pad + "    ";
            if (m_allowQuReview)
                output += "<allowQuReview>true</allowQuReview>";
            else
                output += "<allowQuReview>false</allowQuReview>";
            if (neat) output += "\n" + pad + "    ";
            output += "<ublogRoom>" + m_ublogRoom.ToString() + "</ublogRoom>";
            if (neat) output += "\n" + pad + "    ";
            output += "<maxMessagelength>" + m_maxMessagelength.ToString() + "</maxMessagelength>";
            if (neat) output += "\n" + pad + "    ";
            if (m_allowTeacherQu)
                output += "<allowTeacherQu>true</allowTeacherQu>";
            else
                output += "<allowTeacherQu>false</allowTeacherQu>";
            if (neat) output += "\n" + pad + "    ";
            output += "<courseIdentifier>" + m_courseIdentifier.ToString() + "</courseIdentifier>";
            if (neat) output += "\n" + pad;
            output += "</sessionDetail>";
            return output;
        }

        public override string getElementName()
        {
            return "sessionDetail";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
	        return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("id"))
            {
                id = int.Parse(atts["id"]);
            }
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case YACRSResponse_parser.ID_ownerID:
				    m_ownerID += chars;
                    break;
                case YACRSResponse_parser.ID_title:
				    m_title += chars;
                    break;
                case YACRSResponse_parser.ID_created:
				    m_created += chars;
                    break;
                case YACRSResponse_parser.ID_allowGuests:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_allowGuests = true;
                    else
                        m_allowGuests = false;
                    break;
                case YACRSResponse_parser.ID_visible:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_visible = true;
                    else
                        m_visible = false;
                    break;
                case YACRSResponse_parser.ID_questionMode:
				    m_questionMode = (qmode)Enum.Parse(typeof(qmode), chars);
                    break;
                case YACRSResponse_parser.ID_defaultQuActiveSecs:
				    m_defaultQuActiveSecs = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_allowQuReview:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_allowQuReview = true;
                    else
                        m_allowQuReview = false;
                    break;
                case YACRSResponse_parser.ID_ublogRoom:
				    m_ublogRoom = (ublogmode)Enum.Parse(typeof(ublogmode), chars);
                    break;
                case YACRSResponse_parser.ID_maxMessagelength:
				    m_maxMessagelength = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_allowTeacherQu:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_allowTeacherQu = true;
                    else
                        m_allowTeacherQu = false;
                    break;
                case YACRSResponse_parser.ID_courseIdentifier:
				    m_courseIdentifier += chars;
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-sessionDetail
// Put code here.
//ENDUSERCODE-SECTION-endElement-sessionDetail
        }
        #endregion
        
//USERCODE-SECTION-userMethods-sessionDetail
// Put code here.
//ENDUSERCODE-SECTION-userMethods-sessionDetail
    }
}

