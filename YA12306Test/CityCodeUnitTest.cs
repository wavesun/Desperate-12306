using Microsoft.VisualStudio.TestTools.UnitTesting;
using YA12306;

namespace YA12306Test
{
    [TestClass]
    public class CityCodeUnitTest
    {
        [TestMethod]
        public void given_load_from_string_should_hold_currect_data()
        {
            const string testData = "北京:BJP\n郑州:ZZJ\n";

            CityCode.LoadData(testData);

            Assert.AreEqual("BJP", CityCode.Get("北京"));
            Assert.AreEqual("ZZJ", CityCode.Get("郑州"));
        }
    }
}
