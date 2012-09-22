using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace YA12306
{
    public interface IHttp
    {
        Stream Post(string url, string data);
        Stream Get(string url);
        IEnumerable GetCookies(string url);
    }
}