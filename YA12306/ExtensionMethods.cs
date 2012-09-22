using System;
using System.Collections.Generic;
using System.IO;

namespace YA12306
{
    public static class ExtensionMethods
    {
        static public string ReadString(this Stream self)
        {
            return new StreamReader(self).ReadToEnd();
        }

        static public void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var obj in self)
            {
                action(obj);
            }
        }
    }
}