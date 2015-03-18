using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KtuvitRssDownloader
{
    class SubtitleDownloader
    {
        const string subtitleDownloadUrl = @"http://www.ktuvit.com/downloadsubtitle.php?id={0}";
        const string loginUrl = @"http://www.ktuvit.com/login.php";
        public void Download(string id, string fileName)
        {
            DoLogin();
            var request = (HttpWebRequest)WebRequest.Create(string.Format(subtitleDownloadUrl, id));




            request.Credentials = new NetworkCredential();
            var response = request.GetResponse();
        }

        private void DoLogin()
        {
            var request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.Method = "POST";
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
            response.Close();
        }
    }
}
