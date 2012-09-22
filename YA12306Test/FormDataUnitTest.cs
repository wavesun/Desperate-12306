using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YA12306Test
{
    [TestClass]
    public class FormDataUnitTest
    {
        private readonly FormData _sut = new FormData();

        [TestMethod]
        public void given_key_AAA_value_BBB_ToString_should_return_AAA_equals_BBB()
        {
            _sut.Add("AAA", "BBB");

            Assert.AreEqual("AAA=BBB", _sut.ToString());
        }
        [TestMethod]
        public void given_many_pairs_ToString_should_return_value_of_pair_connected_by_ampersand()
        {
            _sut.Add("AAA", "BBB");
            _sut.Add("CCC", "DDD");

            Assert.AreEqual("AAA=BBB&CCC=DDD", _sut.ToString());
        }
    }
}
