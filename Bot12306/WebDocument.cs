using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    internal class WebDocument
    {
        public HtmlDocument Document { get; set; }

        public void Query(DateTime value, string from, string to, string trainNumber)
        {
            var fromStation = GetElementFromMainFrame("fromStation");
            if (fromStation == null)
                return;

            fromStation.SetAttribute("value", Telecode.Parse(from));
            GetElementFromMainFrame("fromStationText").SetAttribute("value", from);

            GetElementFromMainFrame("toStation").SetAttribute("value", Telecode.Parse(to));
            GetElementFromMainFrame("toStationText").SetAttribute("value", to);

            GetElementFromMainFrame("startdatepicker").SetAttribute("value", value.ToString("yyyy-MM-dd"));
            GetElementFromMainFrame("trainCodeText").SetAttribute("value", trainNumber);

            GetElementFromMainFrame("submitQuery").InvokeMember("click");
        }

        private HtmlElement GetElementFromMainFrame(string elementId)
        {
            return Document.Window.Frames["main"].Document.All[elementId];
        }
    }
}