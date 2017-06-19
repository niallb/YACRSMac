/* cls_optionInfo.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-optionInfo
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-optionInfo

namespace YACRScontrol
{
    public class cls_optionInfo : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string m_title;
        private int m_count;
        private bool? m_isCorrect;
        #endregion 
//USERCODE-SECTION-optionInfo-uservars
// Put code here.
//ENDUSERCODE-SECTION-optionInfo-uservars
        
        #region XMLpg_generated_code

        public cls_optionInfo() : this (null) {}

        public cls_optionInfo(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_title = "";
            m_isCorrect = null;
        }

        public string M_title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        public int M_count
        {
            get { return m_count; }
            set { m_count = value; }
        }

        public bool? M_isCorrect
        {
            get { return m_isCorrect; }
            set { m_isCorrect = value; }
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
            output += "<optionInfo";
            // attributes
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            output += "<title>" + m_title.ToString() + "</title>";
            if (neat) output += "\n" + pad + "    ";
            output += "<count>" + m_count.ToString() + "</count>";
            if (m_isCorrect != null)
            {
                if (neat) output += "\n" + pad + "    ";
                if (m_isCorrect == true)
                    output += "<isCorrect>true</isCorrect>";
                else
                    output += "<isCorrect>false</isCorrect>";
            }
            if (neat) output += "\n" + pad;
            output += "</optionInfo>";
            return output;
        }

        public override string getElementName()
        {
            return "optionInfo";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
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
                case YACRSResponse_parser.ID_title:
				    m_title += chars;
                    break;
                case YACRSResponse_parser.ID_count:
				    m_count = int.Parse(chars);
                    break;
                case YACRSResponse_parser.ID_isCorrect:
                    if ((chars.Equals("true", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("yes", StringComparison.OrdinalIgnoreCase))
                                || (chars.Equals("1")))
                        m_isCorrect = true;
                    else
                        m_isCorrect = false;
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-optionInfo
// Put code here.
//ENDUSERCODE-SECTION-endElement-optionInfo
        }
        #endregion
        
//USERCODE-SECTION-userMethods-optionInfo
// Put code here.
//ENDUSERCODE-SECTION-userMethods-optionInfo
    }
}

