using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using CoreGraphics;
using System.Text;
using System.Web;
using System.Collections.Specialized;
//using System.Drawing.Imaging;
//using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace YACRScontrol
{
    public sealed class YACRSSession
    {
        private static readonly YACRSSession instance = new YACRSSession();

        private static readonly Encoding encoding = Encoding.UTF8;
        private static YACRSResponse_parser responseParser = new YACRSResponse_parser();
        private string serverURL;
        public string baseURL { get; private set; }
        private CookieCollection cookies;
        private cls_sessionDetail currentSessionDetail;
        private bool courseIdSupported;
        private List<cls_globalQuType> availableQus;
        private int defaultQuID;
        private int lastQiID;
        private bool serverOK;
        private string lastError;

        public int serverMajorVer { get; private set; }
        public int serverMinorVer { get; private set; }

        private static Regex versionParse = new Regex(@"\A([0-9]+)\.([0-9]+)(\.([0-9]+))");

        //private int qis; // temp 

        public static YACRSSession Instance
        {
            get { return instance; }
        }

        public bool ServerOK
        { 
            get { return serverOK; }
        }

        public string LastError
        {
            get { return lastError; }
        }

        public cls_sessionDetail Detail
        {
            get { return currentSessionDetail; }
        }

        public bool CourseIdSupported
        {
            get { return courseIdSupported; }
        }

        public List<cls_globalQuType> AvailableQus
        {
            get { return availableQus; }
        }

        public int DefaultQuID
        {
            get { return defaultQuID; }
            set { defaultQuID = value; }
        }

        public int LastQuInstanceID
        {
            get { return lastQiID; }
        }

        public string loginCookie
        {
            get { return cookies["yacrs_login"].Value; }
        }

        public void newSession()
        {
            currentSessionDetail = new cls_sessionDetail();
            currentSessionDetail.M_questionMode = cls_sessionDetail.qmode.teacherled;
            currentSessionDetail.M_ublogRoom = cls_sessionDetail.ublogmode.none;
            currentSessionDetail.M_title = DateTime.Now.ToString("yyyy/MM/dd");
        }

        public void StartSession()
        {
            lastQiID = 0;
            // Check if there is an active question
            cls_questionResponseInfo qi = questionInfo(0);
            if ((qi != null) && (qi.M_id > 0))
            {
                lastQiID = qi.M_id;
            }
            else
                lastQiID = 0;
        }

        public string SetAndCheckURL(string url, out string nurl)
        {
            char[] charsToTrim = {' ' , '\t', '/', '\\', ':', '?' };
            string tidiedUrl = url.Trim(charsToTrim) + "/";
            if (tidiedUrl.IndexOf("http") != 0)
                tidiedUrl = "http://" + tidiedUrl;

            serverURL = tidiedUrl + "services.php";
            string xml = httpRequest(null, null, null, null);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if (r == null)
            {
                serverOK = false;
                baseURL = null;
                nurl = url;
                return "Incorrect URL";
            }
            else
            {
                nurl = serverURL.Substring(0, serverURL.IndexOf("services.php"));
                serverOK = true;
                baseURL = tidiedUrl;
                Match ver = versionParse.Match(r.M_version);
                if (ver.Success)
                {
                    serverMajorVer = int.Parse(ver.Groups[1].Value);
                    serverMinorVer = int.Parse(" " + ver.Groups[2].Value + " ");
                }
                else
                {
                    serverMajorVer = 0;
                    serverMinorVer = 0;
                }
                return "YACRS version " + r.M_version;
            }
        }

        public bool AttemptLogin(string username, string password)
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("uname", username);
            formData.Add("pwd", password);
            formData.Add("action", "login");
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if (r == null)
            {
                lastError = xml;
                return false;
            }
            else if (r.M_error.Count > 0)
            {
                lastError = r.M_error[0];
                return false;
            }
            else
            {
                courseIdSupported = r.M_data.M_serverInfo.M_courseIdSupported;
                availableQus = r.M_data.M_serverInfo.M_globalQuType;
                return true;
            }
        }

        public List<cls_sessionInfo> getSessionList()
        {
            Dictionary<int, string> output = new Dictionary<int, string>();
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "sessionlist");
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if (r == null)
                return null;
            else
            return r.M_data.M_sessionInfo;
        }

        public bool getSessionDetail(int id)
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "sessiondetail");
            formData.Add("id", id.ToString());
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if (r != null)
            {
            currentSessionDetail = r.M_data.M_sessionDetail;
            return !(currentSessionDetail == null);
        }
            else
                return false;
        }

        public List<int> getSessionQuestionIDs()
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "getqids");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            cls_YACRSResponse r = responseParser.parseIn(xml);            
            if (r != null)
            return r.M_data.M_qid;
            else
                return null;
        }

        public bool startNewQuestion()
        {
            return startNewQuestion(new CGPoint(-1,-1));
        }

        public bool startNewQuestion(CGPoint containing)
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "activate");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            formData.Add("qid", defaultQuID.ToString());
            String filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string xml = httpRequest(formData, "screenshot", filename, YACRSUtil.grabScreenAsPNG(containing));
            //Console.Write(xml);
			//string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            return true;
        }

        public bool stopQuestion()
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "deactivate");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            return true;
        }

        public cls_questionResponseInfo questionInfo(bool getFullInfo)
        {
            if ((!getFullInfo) && ((serverMajorVer > 1) || ((serverMajorVer == 1) && (serverMinorVer > 1))))
                return questionInfoShort();
            else
            return questionInfo(0);
        }
            
        public cls_questionResponseInfo questionInfo(int qiID)
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "quinfo");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            if (qiID > 0)
                formData.Add("qiID", qiID.ToString());
            string xml = httpRequest(formData, null, null, null);
            //if (qis==0)  // Temp variable that limits number of times this is displayed for debugging
            // {
            //    qis = 100;
            //Console.WriteLine(xml);
            //     MessageBox.Show(xml);
            // }
            // qis--;

            cls_YACRSResponse r = responseParser.parseIn(xml);
            if ((r != null) && (r.M_data.M_questionResponseInfo.Count > 0))
            {
                if (r.M_data.M_questionResponseInfo[0].M_id != 0)
                    lastQiID = r.M_data.M_questionResponseInfo[0].M_id;
                return r.M_data.M_questionResponseInfo[0];
            }
            else
                return null;
            }

        public cls_questionResponseInfo questionInfoShort()
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "quinfoshort");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            string xml = httpRequest(formData, null, null, null);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if ((r != null) && (r.M_data.M_questionResponseInfo.Count > 0))
            { 
                if (r.M_data.M_questionResponseInfo[0].M_id != 0)
                    lastQiID = r.M_data.M_questionResponseInfo[0].M_id;
                return r.M_data.M_questionResponseInfo[0];
            }
            else
                return null;
        }

        public void addTime()
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "addtime");
            formData.Add("id", currentSessionDetail.M_id.ToString());
            string xml = httpRequest(formData, null, null, null);
            cls_YACRSResponse r = responseParser.parseIn(xml);
        }

        public int updateSession()
        {
            NameValueCollection formData = new NameValueCollection();
            formData.Add("action", "sessiondetail");
            if(currentSessionDetail.M_id > 0)
                formData.Add("id", currentSessionDetail.M_id.ToString());
            formData.Add("title", currentSessionDetail.M_title.ToString());
            formData.Add("courseIdentifier", currentSessionDetail.M_courseIdentifier.ToString());
            formData.Add("allowGuests", currentSessionDetail.M_allowGuests?"1":"0");
            formData.Add("visible", currentSessionDetail.M_visible ? "1" : "0");
            formData.Add("questionMode", ((int)currentSessionDetail.M_questionMode).ToString());
            formData.Add("defaultQuActiveSecs", currentSessionDetail.M_defaultQuActiveSecs.ToString());
            formData.Add("allowQuReview", currentSessionDetail.M_allowQuReview ? "1" : "0");
            formData.Add("ublogRoom", ((int)currentSessionDetail.M_ublogRoom).ToString());
            formData.Add("maxMessagelength", currentSessionDetail.M_maxMessagelength.ToString());
            formData.Add("allowTeacherQu", currentSessionDetail.M_allowTeacherQu ? "1" : "0"); 
            string xml = httpRequest(formData, null, null, null);
            //MessageBox.Show(xml);
            cls_YACRSResponse r = responseParser.parseIn(xml);
            if (r != null)
            {
            currentSessionDetail = r.M_data.M_sessionDetail;
            if (currentSessionDetail == null)
                return 0;
            else
                return currentSessionDetail.M_id;
        }
            else
                return 0;
        }

        private string httpRequest(NameValueCollection formData, string fileFieldName, string filePath, byte[] file)
        {
            /*//# Random errors for testing purposes!
#if DEBUG
            Random r = new Random();
            int ri = r.Next(3);
            if (ri == 0)
                return "Random debugging emulated http error";
#endif
            //# End of random errors.*/
            string buffer = "";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverURL);
                request.AllowAutoRedirect = true;
                CookieContainer cookieContainer = new CookieContainer();
                if (cookies != null)
                    cookieContainer.Add(cookies);
                request.CookieContainer = cookieContainer;
                request.UserAgent = "YACRSControl 0.1";
                // Need to add stuff in here to switch between GET, POST etc.
                if ((formData != null) || (fileFieldName != null))
                {
                    request.Method = "POST";
                    if (fileFieldName != null)
                    {
                        string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                        request.ContentType = "multipart/form-data; boundary=" + boundary;
                        request.KeepAlive = true;
                        byte[] postData;
                        if (file == null)
                            postData = GetMultipartFormData(formData, fileFieldName, "image/x-png", filePath, File.ReadAllBytes(filePath), boundary);
                        else
                            postData = GetMultipartFormData(formData, fileFieldName, "image/x-png", filePath, file, boundary);
                        request.ContentLength = postData.Length;
                        using (Stream writer = request.GetRequestStream())
                        {
                            writer.Write(postData, 0, postData.Length);
                            writer.Close();
                        }
                    }
                    else
                    {
                        var parameters = new StringBuilder();

                        foreach (string key in formData.Keys)
                        {
                            parameters.AppendFormat("{0}={1}&",
                                System.Uri.EscapeDataString(key),
                                System.Uri.EscapeDataString(formData[key]));
                        }

                        parameters.Length -= 1;
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = parameters.Length;
                        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                        {
                            writer.Write(parameters.ToString());
                        }
                    }
                }

                Stream objStream = request.GetResponse().GetResponseStream();
                serverURL = request.GetResponse().ResponseUri.ToString();
                using (StreamReader objReader = new StreamReader(objStream))
                {
                    string sLine = "";
                    int i = 0;

                    while (sLine != null)
                    {
                        i++;
                        sLine = objReader.ReadLine();
                        if (sLine != null)
                            buffer += sLine + "\r\n";
                    }
                }
                cookies = request.CookieContainer.GetCookies(new Uri(serverURL));
                return buffer;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Based on http://www.briangrinstead.com/blog/multipart-form-post-in-c
        private static byte[] GetMultipartFormData(NameValueCollection postParameters, string fileFieldName, string fileType, string filePath, byte[] file, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (string key in postParameters.Keys)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                    boundary,
                    key,
                    postParameters[key]);
                formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
            }
            if (fileFieldName != null)
            {
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                   boundary,
                   fileFieldName,
                   filePath ?? fileFieldName,
                   fileType ?? "application/octet-stream");

                formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                // Write the file data directly to the Stream, rather than serializing it to a string.
                formDataStream.Write(file, 0, file.Length);
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }
    }
}
