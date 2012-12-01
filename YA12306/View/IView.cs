using System.Collections.Generic;

namespace YA12306.View
{
    public interface IView
    {
        void FillCities(IEnumerable<string> cities);
    }
}