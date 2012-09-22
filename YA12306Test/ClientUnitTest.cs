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

        public ClientUnitTest()
        {
            _sut = new Client(_mockHttp.Object);
        }

        [TestMethod]
        public void should_captcha_be_availible()
        {
            Assert.IsNotNull(_sut.FetchCaptcha());
        }

        [TestMethod]
        public void should_login_succeed_without_exception_when_response_contains_welcome()
        {
            _mockHttp.Setup(o => o.Post(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new MemoryStream(Encoding.UTF8.GetBytes("欢迎您")));

            _sut.Login(Account, Password, null);
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
