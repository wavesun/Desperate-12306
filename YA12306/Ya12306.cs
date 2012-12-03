using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YA12306.Model;
using YA12306.View;

namespace YA12306
{
    public class Ya12306 : IViewEvents
    {
        private readonly Map _cityCodes = new Map(@"data\CityCode.txt");
        private readonly IView _view;
        private readonly QueryWebDocument _queryDocument = new QueryWebDocument();

        public Ya12306(IView view)
        {
            _view = view;
        }

        public IEnumerable<string> Cities { get { return _cityCodes.Keys; } }

        public void OnFillCities()
        {
            _view.FillCities(Cities);
        }

        public void OnQuery(DateTime startDate, string from, string to, string trainCode)
        {
            if (_queryDocument.Loaded)
                _queryDocument.Query(startDate, from, to, trainCode, _cityCodes[from], _cityCodes[to]);
        }

        public void OnDocumentCompleted(HtmlDocument document)
        {
            _queryDocument.Document = document;
        }
    }
}
