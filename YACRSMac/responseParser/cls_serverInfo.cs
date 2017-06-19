/* cls_serverInfo.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-serverInfo
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-serverInfo

namespace YACRScontrol
{
    public class cls_serverInfo : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private bool m_courseIdSupported;
        private List<cls_globalQuType> m_globalQuType;
        #endregion 
//USERCODE-SECTION-serverInfo-uservars
// Put code here.
//ENDUSERCODE-SECTION-serverInfo-uservars
        
        #region XMLpg_generated_code

        public cls_serverInfo() : this (null) {}

        public cls_serverInfo(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_globalQuType = new List<cls_globalQuType>();
        }

        public bool M_courseIdSupported
        {
            get { return m_courseIdSupported; }
            set { m_courseIdSupported = value; }
        }

        public List<cls_globalQuType> M_globalQuType
        {
            get { return m_globalQuType; }
            set
            {
                m_globalQuType = value;
                foreach (cls_globalQuType tmp_globalQuType in m_globalQuType)
                {
                    tmp_globalQuType.setOwner(__owner);
                    tmp_globalQuType.setParent(this);
                }
            }
        }

        public bool Add_globalQuType(cls_globalQuType n_globalQuType)
        {
            n_globalQuType.setParent(this);
            n_globalQuType.setOwner(__owner);
            m_globalQuType.Add(n_globalQuType);
            return true;
        }

        internal override void setOwner(cls_YACRSResponse n_owner)
        {
            __owner = n_owner;
            foreach (cls_globalQuType tmp_globalQuType in m_globalQuType)
            {
                tmp_globalQuType.setOwner(__owner);
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
            output += "<serverInfo";
            // attributes
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            if (m_courseIdSupported)
                output += "<courseIdSupported>true</courseIdSupported>";
            else
                output += "<courseIdSupported>false</courseIdSupported>";
            foreach (cls_globalQuType tmp_globalQuType in m_globalQuType)
            {
                output += tmp_globalQuType.toXML(neat, indent + 1);
            }
            if (neat) output += "\n" + pad;
            output += "</serverInfo>";
            return output;
        }

        public override string getElementName()
        {
            return "serverInfo";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
	        switch (elementid)
	        {
                case YACRSResponse_parser.ID_globalQuType:
                    cls_globalQuType tmp_globalQuType = new cls_globalQuType(this);
                    tmp_globalQuType.parseAttributes(atts);
                    m_globalQuType.Add(tmp_globalQuType);
                    return tmp_globalQuType;
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
                case YACRSResponse_parser.ID_courseIdSupported:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_courseIdSupported = true;
                    else
                        m_courseIdSupported = false;
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-serverInfo
// Put code here.
//ENDUSERCODE-SECTION-endElement-serverInfo
        }
        #endregion
        
//USERCODE-SECTION-userMethods-serverInfo
// Put code here.
//ENDUSERCODE-SECTION-userMethods-serverInfo
    }
}

