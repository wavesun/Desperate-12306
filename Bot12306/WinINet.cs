using System.Runtime.InteropServices;

namespace Bot12306
{
    internal static class WinINet
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string url, string cookieName, string cookieData);
    }
}