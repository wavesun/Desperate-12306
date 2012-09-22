using System.IO;
using System.Drawing;
using System.Net;

namespace YA12306
{
    public class Client
    {
        private readonly IHttp _http;
        private const string CaptchaUrl = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand";

        public Client(IHttp http)
        {
            _http = http;
        }

        public Image FetchCaptcha()
        {
            var stream = FetchResponseStream(CaptchaUrl);
            return Image.FromStream(stream);
        }

        private Stream FetchResponseStream(string url)
        {
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            return response.GetResponseStream();
        }

        public void Login(string account, string password, string captcha)
        {
            Stream response = _http.Post("", "");
            ParseResponse(response);
        }

        private void ParseResponse(Stream response)
        {
            string html = new StreamReader(response).ReadToEnd();

            if (html.Contains("欢迎您"))
                return;
                
            throw new IncorrectPasswordException();
        }
    }
}
