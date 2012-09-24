using System;

namespace YA12306
{
    public class UndefinedTelecodeException : Exception
    {
        public UndefinedTelecodeException(string nameOfPlace)
            : base(nameOfPlace)
        {
        }
    }
}