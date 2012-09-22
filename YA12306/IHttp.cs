using System.IO;

namespace YA12306
{
    public interface IHttp
    {
        Stream Post(string url, string data);
        Stream Get(string url);
    }
}