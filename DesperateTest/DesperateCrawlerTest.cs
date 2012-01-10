using Desperate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesperateTest
{
    [TestClass]
    public class DesperateCrawlerTest
    {
        [TestMethod]
        public void Contructor_Typical()
        {
            var sut = new Crawler();

            Assert.IsNotNull(sut);
        }
    }
}
