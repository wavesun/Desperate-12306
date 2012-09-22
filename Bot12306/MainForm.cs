using System;
using System.Collections;
using System.Net;
using System.Windows.Forms;
using WebBrowserControlDialogs;
using YA12306;

namespace Bot12306
{
    public partial class MainFrame : Form
    {
        private readonly Client _client = new Client();

        public MainFrame()
        {
            InitializeComponent();
            WindowsInterop.SecurityAlertDialogWillBeShown += SecurityAlertDialogWillBeShown;
        }

        private bool SecurityAlertDialogWillBeShown(bool param)
        {
            return true;
        }

        private void MainFrameShown(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_client);
            while (loginForm.ShowDialog() == DialogResult.OK)
            {
                if (loginForm.LoggedIn)
                {
                    loginForm.Close();
                    Navigate(_client.QueryUrl, _client.Cookies);
                }
            }   
            Close();
        }

        private void Navigate(string url, IEnumerable cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                WinINet.InternetSetCookie("https://" + cookie.Domain, cookie.Name, cookie.Value + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
            webBrowser.Navigate(url);
        }
    }
}
