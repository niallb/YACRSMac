/* cls_sessionInfo.cs */
using System;
using System.Collections.Generic;

namespace YACRScontrol
{
    public partial class cls_sessionInfo
    {
        public override string ToString()
        {
            return m_title + " (Created " + m_created + ")";
        }
        
    }
}

