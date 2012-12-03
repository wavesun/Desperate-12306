using Microsoft.VisualStudio.TestTools.UnitTesting;
using YA12306;
using YA12306.Model;

namespace YA12306Test
{
    [TestClass]
    public class MapUnitTest
    {
        [TestMethod]
        public void given_load_from_string_should_hold_currect_data()
        {
            var sut = new Map("");
            const string testData = "北京,BJP\n郑州,ZZJ\n";

            sut.LoadData(testData);

            Assert.AreEqual("BJP", sut["北京"]);
            Assert.AreEqual("ZZJ", sut["郑州"]);
        }
    }
}
