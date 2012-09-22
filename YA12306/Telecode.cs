using System;
using System.Collections.Generic;

namespace YA12306
{
    public static class Telecode
    {
        static readonly Dictionary<string, string> Map = new Dictionary<string, string>()
                                                    {
                                                        { "beijing", "BJP"},
                                                        { "xuchang", "XCF"},
                                                    };

        public static IEnumerable<string> CityNames
        {
            get { return Map.Keys; }
        }

        public static string Parse(string value)
        {
            return Map[value.ToLower()].ToUpper();
        }
    }
}