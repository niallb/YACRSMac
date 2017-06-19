/* cls_data.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-data
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-data

namespace YACRScontrol
{
    public class cls_data : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private List<cls_sessionInfo> m_sessionInfo;
        private List<cls_questionResponseInfo> m_questionResponseInfo;
        private cls_sessionDetail m_sessionDetail;
        private cls_serverInfo m_serverInfo;
        private List<int> m_qid;
        #endregion 
//USERCODE-SECTION-data-uservars
// Put code here.
//ENDUSERCODE-SECTION-data-uservars
        
        #region XMLpg_generated_code

        public cls_data() : this (null) {}

        public cls_data(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_sessionInfo = new List<cls_sessionInfo>();
            m_questionResponseInfo = new List<cls_questionResponseInfo>();
            m_sessionDetail = null;
            m_serverInfo = null;
            m_qid = new List<int>();
        }

        public List<cls_sessionInfo> M_sessionInfo
        {
            get { return m_sessionInfo; }
            set
            {
                m_sessionInfo = value;
                foreach (cls_sessionInfo tmp_sessionInfo in m_sessionInfo)
                {
                    tmp_sessionInfo.setOwner(__owner);
                    tmp_sessionInfo.setParent(this);
                }
            }
        }

        public bool Add_sessionInfo(cls_sessionInfo n_sessionInfo)
        {
            n_sessionInfo.setParent(this);
            n_sessionInfo.setOwner(__owner);
            m_sessionInfo.Add(n_sessionInfo);
            return true;
        }

        public List<cls_questionResponseInfo> M_questionResponseInfo
        {
            get { return m_questionResponseInfo; }
            set
            {
                m_questionResponseInfo = value;
                foreach (cls_questionResponseInfo tmp_questionResponseInfo in m_questionResponseInfo)
                {
                    tmp_questionResponseInfo.setOwner(__owner);
                    tmp_questionResponseInfo.setParent(this);
                }
            }
        }

        public bool Add_questionResponseInfo(cls_questionResponseInfo n_questionResponseInfo)
        {
            n_questionResponseInfo.setParent(this);
            n_questionResponseInfo.setOwner(__owner);
            m_questionResponseInfo.Add(n_questionResponseInfo);
            return true;
        }

        public cls_sessionDetail M_sessionDetail
        {
            get { return m_sessionDetail; }
            set
            {
                m_sessionDetail = value;
                if (m_sessionDetail != null)
                {
                    m_sessionDetail.setOwner(__owner);
                    m_sessionDetail.setParent(this);
                }
            }
        }

        public cls_serverInfo M_serverInfo
        {
            get { return m_serverInfo; }
            set
            {
                m_serverInfo = value;
                if (m_serverInfo != null)
                {
                    m_serverInfo.setOwner(__owner);
                    m_serverInfo.setParent(this);
                }
            }
        }

        public List<int> M_qid
        {
            get { return m_qid; }
            set { m_qid = value; }
        }

        internal override void setOwner(cls_YACRSResponse n_owner)
        {
            __owner = n_owner;
            foreach (cls_sessionInfo tmp_sessionInfo in m_sessionInfo)
            {
                tmp_sessionInfo.setOwner(__owner);
            }
            foreach (cls_questionResponseInfo tmp_questionResponseInfo in m_questionResponseInfo)
            {
                tmp_questionResponseInfo.setOwner(__owner);
            }
            if (m_sessionDetail != null)
            {
                m_sessionDetail.setOwner(__owner);
            }
            if (m_serverInfo != null)
            {
                m_serverInfo.setOwner(__owner);
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
            output += "<data";
            // attributes
            output += ">";
            // content
            foreach (cls_sessionInfo tmp_sessionInfo in m_sessionInfo)
            {
                output += tmp_sessionInfo.toXML(neat, indent + 1);
            }
            foreach (cls_questionResponseInfo tmp_questionResponseInfo in m_questionResponseInfo)
            {
                output += tmp_questionResponseInfo.toXML(neat, indent + 1);
            }
            if (m_sessionDetail != null)
            {
                output += m_sessionDetail.toXML(neat, indent + 1);
            }
            if (m_serverInfo != null)
            {
                output += m_serverInfo.toXML(neat, indent + 1);
            }
            foreach (int tmp_qid in m_qid)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<qid>" + tmp_qid.ToString() + "</qid>";
            }
            if (neat) output += "\n" + pad;
            output += "</data>";
            return output;
        }

        public override string getElementName()
        {
            return "data";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
	        switch (elementid)
	        {
                case YACRSResponse_parser.ID_sessionInfo:
                    cls_sessionInfo tmp_sessionInfo = new cls_sessionInfo(this);
                    tmp_sessionInfo.parseAttributes(atts);
                    m_sessionInfo.Add(tmp_sessionInfo);
                    return tmp_sessionInfo;
                    //break;
                case YACRSResponse_parser.ID_questionResponseInfo:
                    cls_questionResponseInfo tmp_questionResponseInfo = new cls_questionResponseInfo(this);
                    tmp_questionResponseInfo.parseAttributes(atts);
                    m_questionResponseInfo.Add(tmp_questionResponseInfo);
                    return tmp_questionResponseInfo;
                    //break;
                case YACRSResponse_parser.ID_sessionDetail:
                    m_sessionDetail = new cls_sessionDetail(this);
                    m_sessionDetail.parseAttributes(atts);
                    return m_sessionDetail;
                    //break;
                case YACRSResponse_parser.ID_serverInfo:
                    m_serverInfo = new cls_serverInfo(this);
                    m_serverInfo.parseAttributes(atts);
                    return m_serverInfo;
                    //break;
	        }
	        return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case YACRSResponse_parser.ID_qid:
				    m_qid.Add(int.Parse(chars));
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-data
// Put code here.
//ENDUSERCODE-SECTION-endElement-data
        }
        #endregion
        
//USERCODE-SECTION-userMethods-data
// Put code here.
//ENDUSERCODE-SECTION-userMethods-data
    }
}

