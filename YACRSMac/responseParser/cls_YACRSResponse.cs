/* cls_YACRSResponse.cs */
using System;
using System.Collections.Generic;
//USERCODE-SECTION-extra-includes-YACRSResponse
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-YACRSResponse

namespace YACRScontrol
{
    public class cls_YACRSResponse : cls_YACRSResponse_part
    {
        #region XMLpg_generated_variables
        
        //private Dictionary<string, string> namespaces;
        //private string namespaceURI;
        private string version;
        private string messageName;
        private List<string> m_error;
        private cls_data m_data;
        #endregion 
//USERCODE-SECTION-YACRSResponse-uservars
// Put code here.
//ENDUSERCODE-SECTION-YACRSResponse-uservars
        
        #region XMLpg_generated_code

        public cls_YACRSResponse() : this (null) {}

        public cls_YACRSResponse(cls_YACRSResponse_part parent)
        {
            __parent = parent;
            if (__parent == null)
                __owner = this;
            else
                __owner = __parent.getOwner();
            messageName = null;
            m_error = new List<string>();
            m_data = new cls_data(this);
        }

        public string M_version
        {
            get { return version; }
            set { version = value; }
        }

        public string M_messageName
        {
            get { return messageName; }
            set { messageName = value; }
        }

        public List<string> M_error
        {
            get { return m_error; }
            set { m_error = value; }
        }

        public bool Add_error(string n_error)
        {
            m_error.Add(n_error);
            return true;
        }

        public cls_data M_data
        {
            get { return m_data; }
            set
            {
                m_data = value;
                m_data.setOwner(__owner);
                m_data.setParent(this);
            }
        }

        internal override void setOwner(cls_YACRSResponse n_owner)
        {
            __owner = n_owner;
            m_data.setOwner(__owner);
        }

        public string toXML(bool neat)
        {
            return toXML(neat, 0);
        }

        public string toXML(bool neat, int indent)
        {
            string pad = "";
            if (neat) for (int n = 0; n < indent; n++) pad += "    ";
            string output = "<?xml version=\"1.0\"?>";
            if (neat) output += "\n" +  pad;
            output += "<YACRSResponse";
            // attributes
            output += " version=\"" + version.ToString().Replace("\"", "&quot;") + "\"";
            if(messageName != null)
			    output += " messageName=\"" + messageName.ToString().Replace("\"", "&quot;") + "\"";
            output += ">";
            // content
            if (neat) output += "\n" + pad + "    ";
            output += "<errors>";
            foreach (string tmp_error in m_error)
            {
                if (neat) output += "\n" + pad + "    ";
                output += "<error>" + tmp_error.ToString() + "</error>";
            }
            if (neat) output += "\n" + pad + "    ";
            output += "</errors>";
            output += m_data.toXML(neat, indent + 1);
            if (neat) output += "\n" + pad;
            output += "</YACRSResponse>";
            return output;
        }

        public override string getElementName()
        {
            return "YACRSResponse";
        }

        public override cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname)
        {
	        switch (elementid)
	        {
                case YACRSResponse_parser.ID_error:
                    m_error.Add("");
                    return this;
                    //break;
                case YACRSResponse_parser.ID_data:
                    m_data = new cls_data(this);
                    m_data.parseAttributes(atts);
                    return m_data;
                    //break;
	        }
	        return this;
        }

        public override void parseAttributes(Dictionary<string, string> atts)
        {
            if (atts.ContainsKey("version"))
            {
                version = atts["version"];
            }
            if (atts.ContainsKey("messageName"))
            {
                messageName = atts["messageName"];
            }
            else
            {
                messageName = null;
            }
        }

        public override void content(string chars, int elementid)
        {
            if (chars.Length > 0)
            {
                switch (elementid)
                {
                case YACRSResponse_parser.ID_error:
				    m_error[m_error.Count - 1] += chars;
                    break;
                }
            }
        }

        public override void endElement(string name)
        {
//USERCODE-SECTION-endElement-YACRSResponse
// Put code here.
//ENDUSERCODE-SECTION-endElement-YACRSResponse
        }
        #endregion
        
//USERCODE-SECTION-userMethods-YACRSResponse
// Put code here.
//ENDUSERCODE-SECTION-userMethods-YACRSResponse
    }
}

