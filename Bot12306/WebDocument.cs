using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    internal class WebDocument
    {
        public HtmlDocument Document { get; set; }

        public bool Loaded
        {
            get { return GetElementFromMainFrame("fromStation") != null; }
        }

        public void Query(DateTime value, string from, string to, string trainNumber)
        {
            if (!Loaded)
                return;

            GetElementFromMainFrame("fromStation").SetAttribute("value", Telecode.Parse(from));
            GetElementFromMainFrame("fromStationText").SetAttribute("value", from);

            GetElementFromMainFrame("toStation").SetAttribute("value", Telecode.Parse(to));
            GetElementFromMainFrame("toStationText").SetAttribute("value", to);

            GetElementFromMainFrame("startdatepicker").SetAttribute("value", value.ToString("yyyy-MM-dd"));
            GetElementFromMainFrame("trainCodeText").SetAttribute("value", trainNumber);

            GetElementFromMainFrame("submitQuery").InvokeMember("click");
        }

        private HtmlElement GetElementFromMainFrame(string elementId)
        {
            if (Document == null || Document.Window == null || Document.Window.Frames["main"] == null)
                return null;
            return Document.Window.Frames["main"].Document.All[elementId];
        }
    }
}