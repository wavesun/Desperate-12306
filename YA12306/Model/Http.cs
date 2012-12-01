using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;

namespace YA12306.Model
{
    class Http : IHttp
    {
        private readonly CookieContainer _cookies = new CookieContainer();

        private const string IE7Agent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET4.0C; .NET4.0E)";
        private const string ContentType = "application/x-www-form-urlencoded";
        private const string PostMethod = "POST";
        private const string AcceptHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        private const int Timeout = 50000;
        private const string GetMethod = "GET";

        static Http()
        {
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;
        }

        public Stream Post(string url, string data)
        {
            try
            {
                var req = CreateRequest(url, PostMethod);

                if (data != null)
                {
                    var encoding = new ASCIIEncoding();
                    byte[] postBytes = encoding.GetBytes(data); ;
                    req.ContentLength = postBytes.Length;
                    Stream st = req.GetRequestStream();
                    st.Write(postBytes, 0, postBytes.Length);
                    st.Close();
                }

                return req.GetResponse().GetResponseStream();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Stream Get(string url)
        {
            try
            {
                var req = CreateRequest(url, GetMethod);
                return req.GetResponse().GetResponseStream();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable GetCookies(string url)
        {
            return _cookies.GetCookies(new Uri(url));
        }

        private HttpWebRequest CreateRequest(string url, string method)
        {
            var req = (HttpWebRequest) WebRequest.Create(url);
            req.KeepAlive = true;
            req.Method = method;
            req.AllowAutoRedirect = true;
            req.CookieContainer = _cookies;
            req.ContentType = ContentType;

            req.UserAgent = IE7Agent;
            req.Accept = AcceptHeader;
            req.Timeout = Timeout;
            return req;
        }
    }
}