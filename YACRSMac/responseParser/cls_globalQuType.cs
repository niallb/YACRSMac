/* cls_globalQuType.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-globalQuType
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-globalQuType

namespace YACRScontrol
{
    public partial class cls_globalQuType : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private int id;
        private string m_globalQuType;
        #endregion 
//USERCODE-SECTION-globalQuType-uservars
// Put code here.
//ENDUSERCODE-SECTION-globalQuType-uservars
        
        #region XMLpg_generated_code

        public cls_globalQuType() : this (null) {}

        public cls_globalQuType(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = null;
            else
                __owner = __parent.getOwner();
            m_globalQuType = "";
        }

        public int M_id
        {
            get { return id; }
            set { id = value; }
        }

        public string get_globalQuType()
        {
            return m_globalQuType;
        }

        public void set_globalQuType(string value)
        {
            m_globalQuType = value;
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
            output += "<globalQuType";
            // attributes
            output += " id=\"" + id.ToString() + "\"";
            output += ">";
            // content
            output += m_globalQuType.ToString();
            output += "</globalQuType>";
            return output;
        }

        public override string getElementName()
        {
            return "globalQuType";
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
            m_globalQuType += chars;
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-globalQuType
// Put code here.
//ENDUSERCODE-SECTION-endElement-globalQuType
        }
        #endregion
        
//USERCODE-SECTION-userMethods-globalQuType
// Put code here.
//ENDUSERCODE-SECTION-userMethods-globalQuType
    }
}

