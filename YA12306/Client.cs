using System.Collections;
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
        private const string LoginUrl = "https://dynamic.12306.cn/otsweb/loginAction.do?method=login";

        public Image Captcha { get; private set; }

        public IEnumerable Cookies
        {
            get { return _http.GetCookies(LoginUrl); }
        }

        public string QueryUrl
        {
            get { return "https://dynamic.12306.cn/otsweb/"; }
        }

        public Client(IHttp http)
        {
            _http = http;
            Update();
        }

        public Client() : this(new Http())
        {
        }

        public void Login(string account, string password, string captcha)
        {
            var data = string.Format("loginRand={3}&loginUser.user_name={0}&nameErrorFocus=&user.password={1}&passwordErrorFocus=&randCode={2}&randErrorFocus=",
                account, password, captcha, _seed);
            Stream response = _http.Post(LoginUrl, data);
            ParseResponse(response);
        }

        public void Update()
        {
            _seed = FetchSeed();
            Captcha = FetchCaptcha();
        }

        private Image FetchCaptcha()
        {
            return Image.FromStream(_http.Get(CaptchaUrl));
        }

        private string FetchSeed()
        {
            return _http.Post(SeedUrl, string.Empty).ReadString().Split('"')[3];
        }

        private void ParseResponse(Stream response)
        {
            string html = response.ReadString();

            if (html.Contains("欢迎您"))
                return;

            if (html.Contains("密码输入错误"))
                throw new IncorrectPasswordException();

            if (html.Contains("当前访问用户过多，请稍后重试"))
                throw new TooManyUsersException();

            if (html.Contains("您的用户已经被锁定"))
                throw new AccountLockedException();

            throw new Unknown12306ResponceException(html);
        }
    }
}
