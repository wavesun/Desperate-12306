using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YA12306.Model
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
            const string captureTrain = "<span id=\\S+ class=\\S+ onmouseout=\\S+ onmouseover=[^\\s]+\">(\\w+)";
            var regex = new Regex(captureTrain);
            var matches = regex.Matches(tbody);

            return (from Match match in matches select match.Groups[1].Value).ToList();
        }

        public List<string> Trains
        {
            get { return _trains; }
        }
    }
}