using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace YA12306
{
    public class TicketMonitor
    {
        private List<string> _trains;

        public void Parse(string html)
        {
            string tbody = GetTableBody(html);
            _trains = ParseTableBody(tbody);
        }

        internal string GetTableBody(string html)
        {
            int iTableClass = html.IndexOf("<table class=\"obj row");
            int iTableBody = html.IndexOf("<tbody>", iTableClass);
            int iTableBodyEnd = html.IndexOf("</table>", iTableBody);
            return html.Substring(iTableBody, iTableBodyEnd - iTableBody);
        }

        internal List<string> ParseTableBody(string tbody)
        {
            var root = new XmlDocument();
            root.LoadXml(tbody);
            throw new NotImplementedException();
        }

        public List<string> Trains
        {
            get { return _trains; }
        }
    }
}