/* cls_YACRSResponse_part.cs */

using System;
using System.Collections.Generic;
using System.Text;
//USERCODE-SECTION-extra-includes-YACRSResponse-part
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-YACRSResponse-part

namespace YACRScontrol
{
    public abstract class cls_YACRSResponse_part
    {
        internal cls_YACRSResponse_part __parent;
        internal cls_YACRSResponse __owner;

        public cls_YACRSResponse_part getParent()
        {
            return __parent;
        }

        public cls_YACRSResponse getOwner()
        {
            return __owner;
        }

        internal void setParent(cls_YACRSResponse_part n_parent)
        {
            __parent = n_parent;
        }

        abstract internal void setOwner(cls_YACRSResponse n_owner);
        abstract public cls_YACRSResponse_part startElement(int elementid, Dictionary<string, string> atts, string nsuri, string elementname);
        abstract public void endElement(string name);
        abstract public void parseAttributes(Dictionary<string, string> atts);
        abstract public void content(string chars, int elementid);
        abstract public string getElementName();
        
//USERCODE-SECTION-userMethods-YACRSResponse-part
// Put code here.
//ENDUSERCODE-SECTION-userMethods-YACRSResponse-part
    }
}
