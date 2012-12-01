using System;

namespace YA12306.Model
{
    public class TrainCodeException : Exception
    {
        public TrainCodeException(string code) : base(code)
        {
        }
    }
}