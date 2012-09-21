using Microsoft.VisualStudio.TestTools.UnitTesting;
using YA12306;

namespace YA12306Test
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public void should_captcha_be_availible()
        {
            var sut = new Client();
            Assert.IsNotNull(sut.FetchCaptcha());
        }
    }
}
