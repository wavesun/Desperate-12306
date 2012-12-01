using System.Collections.Generic;

namespace YA12306
{
    public class Ya12306 : IViewEvents
    {
        private readonly Map _cityCodes = new Map("CityCode.txt");
        private IView _view;

        public Ya12306(IView view)
        {
            _view = view;
        }

        public IEnumerable<string> Cities { get { return _cityCodes.Keys; } }

        public void OnFillCities()
        {
            _view.FillCities(Cities);
        }
    }
}
