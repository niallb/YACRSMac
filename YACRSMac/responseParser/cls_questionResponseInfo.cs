/* cls_questionResponseInfo.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-questionResponseInfo
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-questionResponseInfo

namespace YACRScontrol
{
    public class cls_questionResponseInfo : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string questiontype;
        private int id;
        private string questionClass;
        private string displayURL;
        private int m_activeUsers;
        private int m_totalUsers;
        private int? m_responseCount;
        private int? m_timeToGo;
        private int? m_timeGone;
        private List<cls_optionInfo> m_optionInfo;
        #endregion 
//USERCODE-SECTION-questionResponseInfo-uservars
// Put code here.
//ENDUSERCODE-SECTION-questionResponseInfo-uservars
        
        #region XMLpg_generated_code

        public cls_questionResponseInfo() : this (null) {}

        public cls_questionResponseInfo(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            questionClass = null;
            displayURL = null;
            m_responseCount = null;
            m_timeToGo = null;
            m_timeGone = null;
            m_optionInfo = new List<cls_optionInfo>();
        }

        public string M_questiontype
        {
            get { return questiontype; }
            set { questiontype = value; }
        }

        public int M_id
        {
            get { return id; }
            set { id = value; }
        }

        public string M_questionClass
        {
            get { return questionClass; }
            set { questionClass = value; }
        }

        public string M_displayURL
        {
            get { return displayURL; }
            set { displayURL = value; }
        }

        public int M_activeUsers
        {
            get { return m_activeUsers; }
            set { m_activeUsers = value; }
        }

        public int M_totalUsers
        {
            get { return m_totalUsers; }
            set { m_totalUsers = value; }
        }

        public int? M_responseCount
        {
            get { return m_responseCount; }
            set { m_responseCount = value; }
        }

        public int? M_timeToGo
        {
            get { return m_timeToGo; }
            set { m_timeToGo = value; }
        }

        public int? M_timeGone
        {
            get { return m_timeGone; }
            set { m_timeGone = value; }
        }

        public List<cls_optionInfo> M_optionInfo
        {
            get { return m_optionInfo; }
            set
            {
                m_optionInfo = value;
                foreach (cls_optionInfo tmp_optionInfo in m_optionInfo)
                {
                    tmp_optionInfo.setOwner(__owner);
                    tmp_optionInfo.setParent(this);
                }
            }
        }

        public bool Add_optionInfo(cls_optionInfo n_optionInfo)
        {
            n_optionInfo.setParent(this);
            n_optionInfo.setOwner(__owner);
            m_optionInfo.Add(n_optionInfo);
            return true;
        }

        internal override void setOwner(cls_YACRSResponse n_owner)
        {
            __owner = n_owner;
            foreach (cls_optionInfo tmp_optionInfo in m_optionInfo)
            {
                tmp_optionInfo.setOwner(__owner);
            }
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
            output += "<questionResponseInfo";
            // attributes
            output += " questiontype=\"" + questiontype.ToString().Replace("\"", "&quot;") + "\"";
            output += " id=\"" + id.ToString() + "\"";
            if(questionClass != null)
			    output += " questionClass=\"" + questionClass.ToString().Replace("\"", "&quot;") + "\"";
            if(displayURL != null)
			    output += " displayURL=\"" + displayURL.ToString().Replace("\"", "&quot;") + "\"";
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            output += "<activeUsers>" + m_activeUsers.ToString() + "</activeUsers>";
            if (neat) output += "\n" + pad + "    ";
            output += "<totalUsers>" + m_totalUsers.ToString() + "</totalUsers>";
            if (m_responseCount != null)
            {
            if (neat) output += "\n" + pad + "    ";
            output += "<responseCount>" + m_responseCount.ToString() + "</responseCount>";
            }
            if (m_timeToGo != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<timeToGo>" + m_timeToGo.ToString() + "</timeToGo>";
            }
            if (m_timeGone != null)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<timeGone>" + m_timeGone.ToString() + "</timeGone>";
            }
            foreach (cls_optionInfo tmp_optionInfo in m_optionInfo)
            {
                output += tmp_optionInfo.toXML(neat, indent + 1);
            }
            if (neat) output += "\n" + pad;
            output += "</questionResponseInfo>";
            return output;
        }

        public override string getElementName()
        {
            return "questionResponseInfo";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
	        switch (elementid)
	        {
                case YACRSResponse_parser.ID_optionInfo:
                    cls_optionInfo tmp_optionInfo = new cls_optionInfo(this);
                    tmp_optionInfo.parseAttributes(atts);
                    m_optionInfo.Add(tmp_optionInfo);
                    return tmp_optionInfo;
                    //break;
	        }
	        return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("questiontype"))
            {
                questiontype = atts["questiontype"];
            }
            if (atts.ContainsKey("id"))
            {
                id = int.Parse(atts["id"]);
            }
            if (atts.ContainsKey("questionClass"))
            {
                questionClass = atts["questionClass"];
            }
            else
            {
                questionClass = null;
            }
            if (atts.ContainsKey("displayURL"))
            {
                displayURL = atts["displayURL"];
            }
            else
            {
                displayURL = null;
            }
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case YACRSResponse_parser.ID_activeUsers:
				    m_activeUsers = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_totalUsers:
				    m_totalUsers = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_responseCount:
				    m_responseCount = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_timeToGo:
				    m_timeToGo = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_timeGone:
				    m_timeGone = int.Parse(chars);
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-questionResponseInfo
// Put code here.
//ENDUSERCODE-SECTION-endElement-questionResponseInfo
        }
        #endregion
        
//USERCODE-SECTION-userMethods-questionResponseInfo
// Put code here.
//ENDUSERCODE-SECTION-userMethods-questionResponseInfo
    }
}

