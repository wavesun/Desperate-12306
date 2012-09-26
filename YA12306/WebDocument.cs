using System;
using System.Collections.Generic;
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

        public void Query(DateTime value, string from, string to, string trainCode)
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

            if (!string.IsNullOrEmpty(trainCode))
            { 
                GetElementFromMainFrame("trainCodeText").SetAttribute("value", TrainCode.QueryText(trainCode));
                GetElementFromMainFrame("trainCode").SetAttribute("value", TrainCode.QueryInternalCode(trainCode));
            }
            else
            {
                GetElementFromMainFrame("trainCodeText").SetAttribute("value", string.Empty);
                GetElementFromMainFrame("trainCode").SetAttribute("value", string.Empty);
            }

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

    public static class TrainCode
    {
        static readonly Dictionary<string, TrainInfo> TextCodeMap = new Dictionary<string, TrainInfo>()
                                                     {
                                                         {"D126", new TrainInfo {Text = "D126（汉口08:06→北京西18:19）", InternalCode = "390000D12601"}},
                                                     };
        public static string QueryText(string code)
        {
            TrainInfo trainInfo;
            if (TextCodeMap.TryGetValue(code, out trainInfo))
            {
                return trainInfo.Text;
            }
            throw new TrainCodeException(code);
        }

        public static string QueryInternalCode(string code)
        {
            TrainInfo trainInfo;
            if (TextCodeMap.TryGetValue(code, out trainInfo))
            {
                return trainInfo.InternalCode;
            }
            throw new TrainCodeException(code);
        }
    }
}