using System.Collections.Generic;

namespace YA12306
{
    public static class Telecode
    {
        static readonly Dictionary<string, string> Map = new Dictionary<string, string>()
                                                    {
                                                        { "北京", "BJP" },
                                                        { "许昌", "XCF" },
                                                        { "漯河", "LON" },
                                                        { "郑州", "ZZF" },
                                                        { "平顶山", "PEN" },
                                                    };

        public static IEnumerable<string> CityNames
        {
            get { return Map.Keys; }
        }

        public static string Parse(string value)
        {
            string result;
            return Map.TryGetValue(value, out result) ? result : string.Empty;
        }
    }
}