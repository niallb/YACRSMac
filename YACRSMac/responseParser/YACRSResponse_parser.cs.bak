/* YACRSResponse_parser.cs */

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
//USERCODE-SECTION-extra-includes-YACRSResponse-parser
// Put code here.
//ENDUSERCODE-SECTION-extra-includes-YACRSResponse-parser

namespace YACRScontrol
{
    public class YACRSResponse_parser
    {
        private cls_YACRSResponse the_YACRSResponse;
        private Stack<int> containerids;
        private cls_YACRSResponse_part tmpPart;
        private Dictionary<string, int> elementtable;
        private string[] idtable;

        public const int ID_YACRSResponse = 1;
        public const int ID_error = 2;
        public const int ID_data = 3;
        public const int ID_sessionInfo = 4;
        public const int ID_questionResponseInfo = 5;
        public const int ID_sessionDetail = 6;
        public const int ID_serverInfo = 7;
        public const int ID_qid = 8;
        public const int ID_ownerID = 9;
        public const int ID_title = 10;
        public const int ID_created = 11;
        public const int ID_activeUsers = 12;
        public const int ID_totalUsers = 13;
        public const int ID_responseCount = 14;
        public const int ID_timeToGo = 15;
        public const int ID_timeGone = 16;
        public const int ID_optionInfo = 17;
        public const int ID_count = 18;
        public const int ID_isCorrect = 19;
        public const int ID_allowGuests = 20;
        public const int ID_visible = 21;
        public const int ID_questionMode = 22;
        public const int ID_defaultQuActiveSecs = 23;
        public const int ID_allowQuReview = 24;
        public const int ID_ublogRoom = 25;
        public const int ID_maxMessagelength = 26;
        public const int ID_allowTeacherQu = 27;
        public const int ID_courseIdentifier = 28;
        public const int ID_courseIdSupported = 29;
        public const int ID_globalQuType = 30;

        public YACRSResponse_parser()
        {
            containerids = new Stack<int>();
            elementtable = new Dictionary<string, int>();
        	elementtable.Add("YACRSResponse", ID_YACRSResponse);
        	elementtable.Add("error", ID_error);
        	elementtable.Add("data", ID_data);
        	elementtable.Add("sessionInfo", ID_sessionInfo);
        	elementtable.Add("questionResponseInfo", ID_questionResponseInfo);
        	elementtable.Add("sessionDetail", ID_sessionDetail);
        	elementtable.Add("serverInfo", ID_serverInfo);
        	elementtable.Add("qid", ID_qid);
        	elementtable.Add("ownerID", ID_ownerID);
        	elementtable.Add("title", ID_title);
        	elementtable.Add("created", ID_created);
        	elementtable.Add("activeUsers", ID_activeUsers);
        	elementtable.Add("totalUsers", ID_totalUsers);
        	elementtable.Add("responseCount", ID_responseCount);
        	elementtable.Add("timeToGo", ID_timeToGo);
        	elementtable.Add("timeGone", ID_timeGone);
        	elementtable.Add("optionInfo", ID_optionInfo);
        	elementtable.Add("count", ID_count);
        	elementtable.Add("isCorrect", ID_isCorrect);
        	elementtable.Add("allowGuests", ID_allowGuests);
        	elementtable.Add("visible", ID_visible);
        	elementtable.Add("questionMode", ID_questionMode);
        	elementtable.Add("defaultQuActiveSecs", ID_defaultQuActiveSecs);
        	elementtable.Add("allowQuReview", ID_allowQuReview);
        	elementtable.Add("ublogRoom", ID_ublogRoom);
        	elementtable.Add("maxMessagelength", ID_maxMessagelength);
        	elementtable.Add("allowTeacherQu", ID_allowTeacherQu);
        	elementtable.Add("courseIdentifier", ID_courseIdentifier);
        	elementtable.Add("courseIdSupported", ID_courseIdSupported);
        	elementtable.Add("globalQuType", ID_globalQuType);
            idtable = new string[elementtable.Count+1];
            foreach (KeyValuePair<string, int> entry in elementtable)
            {
                 idtable[entry.Value] = entry.Key;
            }
        }

        public int LookupElementID(string name)
        {
            if(elementtable.ContainsKey(name))
            {
                int elementid = elementtable[name];
                return elementid;
            }
            else
            {
                return 0;
            }
        }

        public string LookupElementName(int id)
        {
            if(id <= idtable.GetUpperBound(0))
            {
                string name = idtable[id];
                return name;
            }
            else
            {
                return null;
            }
        }
    
        public cls_YACRSResponse parseIn(string source)
        {
            XmlTextReader parser;
            string elementname;
            StringReader sr = new StringReader(source);
            parser = new XmlTextReader(sr);
            the_YACRSResponse = null;
                while (parser.Read())
                {
                    switch (parser.NodeType)
                    {
                        case XmlNodeType.XmlDeclaration:
                            break;
                        case XmlNodeType.Element:
                            elementname = parser.LocalName;
                            int elementid = LookupElementID(elementname);
                            containerids.Push(elementid);
                            Dictionary<string, string> atts2 = new Dictionary<string, string>();
                            if (parser.HasAttributes)
                            {
                                while (parser.MoveToNextAttribute())
                                {
                                    atts2.Add(parser.Name, parser.Value);
                                }
                                parser.MoveToElement();
                            }
                            if (elementid == ID_YACRSResponse)
                            {
                                tmpPart = new cls_YACRSResponse();
                                tmpPart.parseAttributes(atts2);
                            }
                            else
                            {
                            if(tmpPart != null)
                                    tmpPart = tmpPart.startElement(elementid, atts2, parser.NamespaceURI, elementname);
                            }
                        if ((parser.IsEmptyElement) && (elementname.Equals(tmpPart.getElementName())))
                            {
                                containerids.Pop();
                            tmpPart.endElement(elementname);
                                tmpPart = tmpPart.getParent();
                            }
                            break;
                        case XmlNodeType.EndElement:
                            containerids.Pop();
                            elementname = parser.LocalName;
                            tmpPart.endElement(elementname);
                            if ((tmpPart.getParent() == null) && (tmpPart.getElementName().Equals("YACRSResponse")) && (elementname.Equals(tmpPart.getElementName())))
                            {
                                the_YACRSResponse = (cls_YACRSResponse)tmpPart;
                                tmpPart = null;
                            }
                            else if (elementname.Equals(tmpPart.getElementName()))
                            {
                                tmpPart = tmpPart.getParent();
                            }
                            break;
                        case XmlNodeType.Whitespace:
                        case XmlNodeType.Text:
                        if(tmpPart != null)
                                tmpPart.content(parser.Value, containerids.Peek());
                            break;
                        default:
                            Console.Out.WriteLine("Node: " + parser.NodeType.ToString());
                            break;
                    }
                }
                return the_YACRSResponse;
            }
        
//USERCODE-SECTION-extraMethods-YACRSResponse_parser
// Put code here.
//ENDUSERCODE-SECTION-extraMethods-YACRSResponse_parser
    }
}

