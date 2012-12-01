using System;

namespace YA12306.Model
{
    public class UndefinedTelecodeException : Exception
    {
        public UndefinedTelecodeException(string nameOfPlace)
            : base(nameOfPlace)
        {
        }
    }
}