using System;
using System.Collections.Generic;
using System.IO;

namespace YA12306
{
    public static class CityCode
    {
        private static readonly Dictionary<string, string> Map = new Dictionary<string, string>();
        
        static CityCode()
        {
            Load("CityCode.txt");
        }

        private static void Load(string file)
        {
            if (!File.Exists(file))
                return;

            var data = File.ReadAllText(file);
            LoadData(data);
        }

        public static IEnumerable<string> CityNames
        {
            get { return Map.Keys; }
        }

        public static string Get(string value)
        {
            string result;
            return Map.TryGetValue(value, out result) ? result : string.Empty;
        }

        public static void LoadData(string data)
        {
            var lines = data.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            lines.ForEach(line =>
                {
                    var pair = line.Split(':');
                    Map.Add(pair[0], pair[1]);
                });
        }
    }
}