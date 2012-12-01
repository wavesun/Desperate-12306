using System;
using System.Windows.Forms;

namespace YA12306.View
{
    public interface IViewEvents
    {
        void OnFillCities();
        void OnQuery(DateTime startDate, string from, string to, string trainCode);

        void OnDocumentCompleted(HtmlDocument document);
    }
}