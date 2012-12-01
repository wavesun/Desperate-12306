using System.Collections.Generic;

namespace YA12306
{
    public interface IView
    {
        void FillCities(IEnumerable<string> cities);
    }
}