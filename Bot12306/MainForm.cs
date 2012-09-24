using System;
using System.Collections;
using System.Net;
using System.Windows.Forms;
using Bot12306.Properties;
using WebBrowserControlDialogs;
using YA12306;

namespace Bot12306
{
    public partial class MainFrame : Form
    {
        private readonly Client _client = new Client();
        private readonly LoginForm _loginForm;
        private readonly WebDocument _root = new WebDocument();
        private readonly Timer _autoQueryTimer = new Timer();

        public MainFrame()
        {
            _loginForm = new LoginForm(_client);
            InitializeComponent();
            WindowsInterop.SecurityAlertDialogWillBeShown += SecurityAlertDialogWillBeShown;

            _autoQueryTimer.Tick += AutoQueryTimerTick;
            _autoQueryTimer.Interval = 10000;
        }

        private void AutoQueryTimerTick(object sender, EventArgs e)
        {
            Query();
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
            webBrowser.DocumentCompleted += WebBrowserDocumentCompleted;
            webBrowser.Navigate(url);
        }

        void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _root.Document = webBrowser.Document;
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            Query();
        }

        private void Query()
        {
            if (!_root.Loaded)
                return;
            try
            {
                _root.Query(datePicker.Value, fromBox.Text, toBox.Text, trainBox.Text);
            }
            catch (UndefinedTelecodeException e)
            {
                MessageBox.Show(string.Format(Resources.UndefinedTelecodeMessage, e.Message));
            }
        }

        private void MainFrameLoad(object sender, EventArgs e)
        {
            Telecode.CityNames.ForEach(o =>
                                           {
                                               fromBox.Items.Add(o);
                                               toBox.Items.Add(o);
                                           });
        }

        private void AutoQueryCheckedChanged(object sender, EventArgs e)
        {
            if (autoQuery.Checked)
            {
                Query();
                _autoQueryTimer.Start();
            }
            else
            {
                _autoQueryTimer.Stop();
            }
        }

        private void QueryIntervalTextValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int result;
            e.Cancel = !Int32.TryParse(queryIntervalText.Text, out result);
        }

        private void QueryIntervalTextValidated(object sender, EventArgs e)
        {
            _autoQueryTimer.Interval = Int32.Parse(queryIntervalText.Text) * 1000;
        }
    }
}
