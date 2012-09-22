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
        private readonly LoginForm _loginForm;

        public MainFrame()
        {
            _loginForm = new LoginForm(_client);
            InitializeComponent();
            WindowsInterop.SecurityAlertDialogWillBeShown += SecurityAlertDialogWillBeShown;
        }

        private bool SecurityAlertDialogWillBeShown(bool param)
        {
            return true;
        }

        private void MainFrameShown(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
                result = _loginForm.ShowDialog();
            } while (result == DialogResult.Retry);

            if (result == DialogResult.OK)
            {
                Navigate(_client.Root, _client.Cookies);
            }
            else
            {
                Close();
            }
        }

        private void Navigate(string url, IEnumerable cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                WinINet.InternetSetCookie("https://" + cookie.Domain, cookie.Name, cookie.Value + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
            webBrowser.Navigate(url);
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            _client.Query(datePicker.Value, fromBox.Text, toBox.Text, "");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            Telecode.CityNames.ForEach(o =>
                                           {
                                               fromBox.Items.Add(o);
                                               toBox.Items.Add(o);
                                           });
        }
    }
}
