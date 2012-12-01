using System;
using System.Collections;
using System.IO;
using System.Drawing;

namespace YA12306
{
    public class Client
    {
        private readonly IHttp _http;
        private string _seed;

        public Image Captcha { get; private set; }

        public IEnumerable Cookies
        {
            get { return _http.GetCookies(URL.LoginUrl); }
        }

        public string Root
        {
            get { return URL.Root; }
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
            Stream response = _http.Post(URL.LoginUrl, data);
            ParseResponse(response);
        }

        public void Update()
        {
            _seed = FetchSeed();
            Captcha = FetchCaptcha();
        }

        public string Query(DateTime date, string fromStation, string toStation, string trainNumber)
        {
            var formData = new FormData()
                               {
                                   {"method", "queryLeftTicket"},
                                   {"orderRequest.train_date", date.ToString("YYYY-MM-DD")},
                                   {"orderRequest.from_station_telecode", CityCode.Get(fromStation)},
                                   {"orderRequest.to_station_telecode", CityCode.Get(toStation)},
                                   {"orderRequest.train_no", trainNumber},
                                   {"trainPassType", "QB"},
                                   {"trainClass", "QB#D#Z#T#K#QT"},
                                   {"includeStudent", "00"},
                                   {"seatTypeAndNum", ""},
                                   {"orderRequest.start_time_str", "00:00--24:00"},
                               };
            return string.Format("{0}{1}", URL.Query, formData);
        }

        private Image FetchCaptcha()
        {
            return Image.FromStream(_http.Get(URL.CaptchaUrl));
        }

        private string FetchSeed()
        {
            return _http.Post(URL.Seed, string.Empty).ReadString().Split('"')[3];
        }

        private void ParseResponse(Stream response)
        {
            string html = response.ReadString();

            if (html.Contains("欢迎您"))
                return;

            if (html.Contains("密码输入错误") || html.Contains("密码长度不能少于") || html.Contains("登录名不存在"))
            {
                Update();
                throw new InvalidPasswordException(); 
            }

            if (html.Contains("当前访问用户过多，请稍后重试"))
                throw new TooManyUsersException();

            if (html.Contains("您的用户已经被锁定"))
                throw new AccountLockedException();

            if (html.Contains("请输入正确的验证码"))
                throw new InvalidCaptchaException();

            throw new Unknown12306ResponceException(html);
        }
    }
}
