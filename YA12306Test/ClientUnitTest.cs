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
        private Stream EmptyStream = new MemoryStream(Encoding.UTF8.GetBytes(string.Empty));
        private const string Account = "TestUser";
        private const string Password = "55AA55AA";
        private const string LoginForm = @"loginRand=4422&loginUser.user_name=TestUser&nameErrorFocus=&user.password=55AA55AA&passwordErrorFocus=&randCode=4423&randErrorFocus=";
        private const string Captcha = "4423";

        public ClientUnitTest()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>())).Returns(EmptyStream);

            _mockHttp.Setup(o => o.Post(@"https://dynamic.12306.cn/otsweb/loginAction.do?method=loginAysnSuggest", 
                    It.Is<string>(s => string.IsNullOrEmpty(s))))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("dummy\"dummy\"dummy\"4422")));

            _sut = new Client(_mockHttp.Object);
        }

        [TestMethod]
        public void should_login_succeed_without_exception_when_response_contains_welcome()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(),
                    It.Is<string>(data => data == LoginForm)))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("欢迎您")));

            _sut.Login(Account, Password, Captcha);
        }

        [TestMethod, ExpectedException(typeof(IncorrectPasswordException))]
        public void should_login_throw_invalid_password_exception_when_response_contains_incorrect_password()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("密码输入错误")));

            _sut.Login(Account, Password, null);
        }
    }
}
