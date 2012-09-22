using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YA12306
{
    public class FormData : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>(); 

        public void Add(string key, string value)
        {
            _dictionary.Add(key, value);
        }

        public override string ToString()
        {
            return _dictionary.Aggregate(string.Empty, (current, pair) => current + (pair.Key + "=" + pair.Value + "&")).TrimEnd('&');
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }
    }
}