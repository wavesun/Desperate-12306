using System.IO;
using System.Drawing;
using System.Net;

namespace YA12306
{
    public class Client
    {
        private const string CaptchaUrl = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand";

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
    }
}
