using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace YA12306
{
    public class QueryWebDocument : WebDocument
    {
        public override bool Loaded
        {
            get { return GetMainFrameElement("fromStation") != null; }
        }

        public void Query(DateTime startDate, string from, string to, string trainCode, string fromStationTelecode, string toStationTelecode)
        {
            if (string.IsNullOrEmpty(fromStationTelecode))
                throw new UndefinedTelecodeException(from);

            FromStation = fromStationTelecode;
            FromStationText = from;

            if (string.IsNullOrEmpty(toStationTelecode))
                throw new UndefinedTelecodeException(to);

            ToStation = toStationTelecode;
            ToStationText = to;

            StartTime = startDate;

            if (!string.IsNullOrEmpty(trainCode))
            {
                TrainCodeText = TrainCode.QueryText(trainCode);
                TrainCodeValue = TrainCode.QueryInternalCode(trainCode);
            }
            else
            {
                TrainCodeText = string.Empty;
                TrainCodeValue = string.Empty;
            }

            SubmitQuery();
        }

        private void SubmitQuery()
        {
            GetMainFrameElement("submitQuery").InvokeMember("click");
        }

        protected string TrainCodeText
        {
            set { SetMainFrameElementValue("trainCodeText", value); }
        }

        protected string TrainCodeValue
        {
            set { SetMainFrameElementValue("trainCode", value); }
        }

        protected DateTime StartTime
        {
            set { SetMainFrameElementValue("startdatepicker", value.ToString("yyyy-MM-dd")); }
        }

        protected string ToStation
        {
            set { SetMainFrameElementValue("toStation", value); }
        }

        protected string ToStationText
        {
            set { SetMainFrameElementValue("toStationText", value); }
        }

        protected string FromStationText
        {
            set { SetMainFrameElementValue("fromStationText", value); }
        }

        private string FromStation
        {
            set { SetMainFrameElementValue("fromStation", value); }
        }

        private void SetMainFrameElementValue(string elementId, string value)
        {
            GetMainFrameElement(elementId).SetAttribute("value", value);
        }

        private HtmlElement GetMainFrameElement(string elementId)
        {
            HtmlWindow mainFrame;
            if (!TryGetMainFrame(out mainFrame)) 
                return null;

            if (mainFrame.Document == null)
            {
                Debug.Print("Document of main frame is null");
                return null;
            }

            var result = mainFrame.Document.All[elementId];
            if (result == null)
                Debug.Print("Element {0} on main frame is absent.", elementId);
            return result;
        }

        protected bool TryGetMainFrame(out HtmlWindow mainFrame)
        {
            mainFrame = null;

            if (Document == null)
                return false;

            if (Document.Window == null)
                return false;

            if (Document.Window.Frames == null)
                return false;

            mainFrame = GetFrame("main");
            return mainFrame != null;
        }
    }
}