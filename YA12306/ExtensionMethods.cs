using System.IO;

namespace YA12306
{
    static class ExtensionMethods
    {
        static public string ReadString(this Stream self)
        {
            return new StreamReader(self).ReadToEnd();
        }
    }
}