/* cls_sessionInfo.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-sessionInfo
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-sessionInfo

namespace YACRScontrol
{
    public partial class cls_sessionInfo : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private int id;
        private string m_ownerID;
        private string m_title;
        private string m_created;
        #endregion 
//USERCODE-SECTION-sessionInfo-uservars
// Put code here.
//ENDUSERCODE-SECTION-sessionInfo-uservars
        
        #region XMLpg_generated_code

        public cls_sessionInfo() : this (null) {}

        public cls_sessionInfo(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_ownerID = "";
            m_title = "";
            m_created = "";
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
            output += "<sessionInfo";
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
            if (neat) output += "\n" + pad;
            output += "</sessionInfo>";
            return output;
        }

        public override string getElementName()
        {
            return "sessionInfo";
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
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-sessionInfo
// Put code here.
//ENDUSERCODE-SECTION-endElement-sessionInfo
        }
        #endregion
        
//USERCODE-SECTION-userMethods-sessionInfo
// Put code here.
//ENDUSERCODE-SECTION-userMethods-sessionInfo
    }
}

