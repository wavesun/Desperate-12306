using System.IO;
using System.Drawing;

namespace YA12306
{
    public class Client
    {
        private readonly IHttp _http;
        private string _seed;

        private const string SeedUrl = "https://dynamic.12306.cn/otsweb/loginAction.do?method=loginAysnSuggest";
        private const string CaptchaUrl = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand";

        public Client(IHttp http)
        {
            _http = http;
            _seed = FetchSeed();
        }

        private string FetchSeed()
        {
            return _http.Post(SeedUrl, string.Empty).ReadString().Split('"')[3];
        }

        public Client() : this(new Http())
        {
        }

        public Image FetchCaptcha()
        {
            return Image.FromStream(_http.Get(CaptchaUrl));
        }

        public void Login(string account, string password, string captcha)
        {
            var data = string.Format("loginRand={3}&loginUser.user_name={0}&nameErrorFocus=&user.password={1}&passwordErrorFocus=&randCode={2}&randErrorFocus=",
                account, password, captcha, _seed);
            Stream response = _http.Post("", data);
            ParseResponse(response);
        }

        private void ParseResponse(Stream response)
        {
            string html = response.ReadString();

            if (html.Contains("欢迎您"))
                return;

            if (html.Contains("密码输入错误"))
                throw new IncorrectPasswordException();

            throw new Unknown12306ResponceException(html);
        }
    }
}
