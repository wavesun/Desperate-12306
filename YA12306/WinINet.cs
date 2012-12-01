using System.Runtime.InteropServices;

namespace YA12306
{
    internal static class WinINet
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string url, string cookieName, string cookieData);
    }
}