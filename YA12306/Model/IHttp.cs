using System.Collections;
using System.IO;

namespace YA12306.Model
{
    public interface IHttp
    {
        Stream Post(string url, string data);
        Stream Get(string url);
        IEnumerable GetCookies(string url);
    }
}