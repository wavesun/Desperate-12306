using System;

namespace YA12306
{
    public class TrainCodeException : Exception
    {
        public TrainCodeException(string code) : base(code)
        {
        }
    }
}