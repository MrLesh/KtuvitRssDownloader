using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RssPareserAndDownloader
{
    class SubtitleDownloader
    {
        const string subtitleDownloadUrl = @"http://www.ktuvit.com/downloadsubtitle.php?id={0}";
        const string loginUrl = @"http://www.ktuvit.com/login.php";
        private CookieCollection _cookies = null;
        const string Dir = @"C:\tmp";
        public void Download(string id, string fileName)
        {
            if (_cookies == null)
                _cookies = DoLogin();
            var request = (HttpWebRequest)WebRequest.Create(string.Format(subtitleDownloadUrl, id));
            request.Method = "GET";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(_cookies);
            var collection = new NameValueCollection
            {
                {"Cache-Control", " max-age=0"},
                {"Accept-Encoding","gzip,deflate"},
                {"Accept-Language","en-US,en;q=0.8,he;q=0.6"},
                {"Origin",@"http://www.ktuvit.com"},
                {"DNT","1"}

            };
            request.KeepAlive = true;
            request.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8}";
            request.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2162.0 Safari/537.36";
            request.Headers = new WebHeaderCollection { collection };
            var response = request.GetResponse();
            
            var fileNameFromResponse = response.Headers["Content-Disposition"].Substring(response.Headers["Content-Disposition"].IndexOf("Subtitle"));
            var newFileName = Path.Combine(Dir, fileNameFromResponse);
            if (File.Exists(newFileName))
            {
                File.Delete(newFileName);
            }
            FileStream os = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write);
            byte[] buff = new byte[102400];
            int c = 0;
            Stream s = response.GetResponseStream();
            while ((c = s.Read(buff, 0, 10400)) > 0)
            {
                os.Write(buff, 0, c);
                os.Flush();
            }
            os.Close();
            s.Close();
            response.Close();
        }

        private CookieCollection DoLogin()
        {
            var request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            var collection = new NameValueCollection
            {
                {"Cache-Control", " max-age=0"},
                {"Accept-Encoding","gzip,deflate"},
                {"Accept-Language","en-US,en;q=0.8,he;q=0.6"},
                {"Origin",@"http://www.ktuvit.com"},
                {"DNT","1"}

            };
            request.AllowAutoRedirect = false;
            request.KeepAlive = true;
            request.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8}";
            request.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2162.0 Safari/537.36";
            request.Headers = new WebHeaderCollection { collection };
            request.ContentType = "application/x-www-form-urlencoded";
            var buffer = Encoding.ASCII.GetBytes(@"email=alonmatat%40gmail.com&password=alon2580&Login=%D7%94%D7%AA%D7%97%D7%91%D7%A8");
            request.ContentLength = buffer.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();

            request.CookieContainer = new CookieContainer();
            
            var response = request.GetResponse();
            foreach (var header in response.Headers)
            {
                Console.WriteLine(string.Format("Name of header:{0}.\t Value of header:{1}",header.ToString(),response.Headers[header.ToString()]));
            }
            foreach (Cookie cookie in ((HttpWebResponse)response).Cookies)
            {
                Console.WriteLine(cookie);
            }
            response.Close();
            return ((HttpWebResponse)response).Cookies;
        }
    }
}
