using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YA12306;
using Moq;

namespace YA12306Test
{
    [TestClass]
    public class ClientUnitTest
    {
        private readonly Mock<IHttp> _mockHttp = new Mock<IHttp>();
        private readonly Client _sut;
        private const string Account = "TestUser";
        private const string Password = "55AA55AA";
        private const string LoginForm = @"loginRand=4422&loginUser.user_name=TestUser&nameErrorFocus=&user.password=55AA55AA&passwordErrorFocus=&randCode=4423&randErrorFocus=";
        private const string Captcha = "4423";
        private const string CaptchaUrl = "https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=sjrand";

        public ClientUnitTest()
        {
            var image = new Bitmap(20, 20);
            var captchaStream = new MemoryStream();
            image.Save(captchaStream, ImageFormat.Bmp);
            _mockHttp.Setup(o => o.Get(CaptchaUrl)).Returns(captchaStream);

            _mockHttp.Setup(o => o.Post(It.IsAny<string>(),
                It.Is<string>(data => string.IsNullOrEmpty(data))))
                .Returns(() => CreateStream("dummy\"dummy\"dummy\"4422"));

            _sut = new Client(_mockHttp.Object);
        }

        [TestMethod]
        public void should_login_succeed_without_exception_when_response_contains_welcome()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(),
                    It.Is<string>(data => data == LoginForm)))
                .Returns(CreateStream("欢迎您"));

            _sut.Login(Account, Password, Captcha);
        }

        [TestMethod, ExpectedException(typeof(InvalidPasswordException))]
        public void should_login_throw_invalid_password_exception_when_response_contains_incorrect_password()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), 
                    It.Is<string>(data => data == LoginForm)))
                .Returns(CreateStream("密码输入错误"));

            _sut.Login(Account, Password, Captcha);
        }

        [TestMethod, ExpectedException(typeof(TooManyUsersException))]
        public void should_login_throw_too_many_users_exception_when_response_contains_too_many_users()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(CreateStream("当前访问用户过多，请稍后重试"));

            _sut.Login(Account, Password, Captcha);
        }

        [TestMethod, ExpectedException(typeof(AccountLockedException))]
        public void should_login_throw_account_locked_exception_when_response_contains_account_is_locked()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(CreateStream("您的用户已经被锁定"));

            _sut.Login(Account, Password, Captcha);
        }

        [TestMethod, ExpectedException(typeof(InvalidCaptchaException))]
        public void should_login_throw_invalid_captcha_exception_when_response_contains_invalid_captcha()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(CreateStream("请输入正确的验证码"));

            _sut.Login(Account, Password, Captcha);
        }

        private static MemoryStream CreateStream(string message)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(message));
        }
    }
}
