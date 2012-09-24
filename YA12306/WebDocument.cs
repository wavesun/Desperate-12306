using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace YA12306
{
    public class WebDocument
    {
        public HtmlDocument Document { get; set; }

        public bool Loaded
        {
            get { return GetElementFromMainFrame("fromStation") != null; }
        }

        public void Query(DateTime value, string from, string to, string trainNumber)
        {
            var fromStationTelecode = Telecode.Parse(from);
            if (string.IsNullOrEmpty(fromStationTelecode))
                throw new UndefinedTelecodeException(from);
            GetElementFromMainFrame("fromStation").SetAttribute("value", fromStationTelecode);
            GetElementFromMainFrame("fromStationText").SetAttribute("value", from);

            var toStationTelecode = Telecode.Parse(to);
            if (string.IsNullOrEmpty(toStationTelecode))
                throw new UndefinedTelecodeException(to);
            GetElementFromMainFrame("toStation").SetAttribute("value", toStationTelecode);
            GetElementFromMainFrame("toStationText").SetAttribute("value", to);

            GetElementFromMainFrame("startdatepicker").SetAttribute("value", value.ToString("yyyy-MM-dd"));
            GetElementFromMainFrame("trainCodeText").SetAttribute("value", trainNumber);

            GetElementFromMainFrame("submitQuery").InvokeMember("click");
        }

        private HtmlElement GetElementFromMainFrame(string elementId)
        {
            HtmlWindow mainFrame;
            if (TryGetMainFrame(out mainFrame)) 
                return null;

            if (mainFrame.Document == null)
            {
                Debug.Print("Document of main frame is null");
                return null;
            }

            var result = mainFrame.Document.All[elementId];
            if (result == null)
                Debug.Print(string.Format("Element {0} on main frame is absent.", elementId));
            return result;
        }

        private bool TryGetMainFrame(out HtmlWindow mainFrame)
        {
            mainFrame = null;

            if (Document == null)
                return true;

            if (Document.Window == null)
                return true;

            if (Document.Window.Frames == null)
                return true;

            mainFrame = Document.Window.Frames["main"];
            return mainFrame == null;
        }
    }
}