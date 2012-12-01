using System;
using System.Collections.Generic;
using System.IO;

namespace YA12306.Model
{
    public class Map
    {
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>();

        public Map(string file)
        {
            Load(file);
        }

        private void Load(string file)
        {
            if (!File.Exists(file))
                return;

            var data = File.ReadAllText(file);
            LoadData(data);
        }

        public IEnumerable<string> Keys
        {
            get { return _map.Keys; }
        }

        public string this[string value]
        {
            get
            {
                string result;
                return _map.TryGetValue(value, out result) ? result : string.Empty;
            }
        }

        internal void LoadData(string data)
        {
            var lines = data.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            lines.ForEach(line =>
                {
                    var pair = line.Split(':');
                    _map.Add(pair[0], pair[1]);
                });
        }
    }
}