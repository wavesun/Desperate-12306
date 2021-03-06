﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using YA12306.Model;
using YA12306.Properties;
using YA12306.View.WebBrowserControlDialogs;

namespace YA12306.View
{
    public partial class MainFrame : Form, IView
    {
        private readonly Client _client = new Client();
        private readonly LoginForm _loginForm;
        private readonly Timer _autoQueryTimer = new Timer();

        private readonly IViewEvents _ya12306;

        public MainFrame()
        {
            _ya12306 = new Ya12306(this);

            _loginForm = new LoginForm(_client);
            InitializeComponent();
            WindowsInterop.SecurityAlertDialogWillBeShown += _ => true;

            _autoQueryTimer.Tick += AutoQueryTimerTick;
            _autoQueryTimer.Interval = 10000;
        }

        private void AutoQueryTimerTick(object sender, EventArgs e)
        {
            Query();
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
            _ya12306.OnDocumentCompleted(webBrowser.Document);
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            Query();
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

        private void MainFrameLoad(object sender, EventArgs e)
        {
            _ya12306.OnFillCities();
        }

        private void Query()
        {
            try
            {
                _ya12306.OnQuery(datePicker.Value, fromBox.Text, toBox.Text, trainBox.Text);
            }
            catch (UndefinedTelecodeException e)
            {
                MessageBox.Show(string.Format(Resources.UndefinedTelecodeMessage, e.Message));
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

        public void FillCities(IEnumerable<string> cities)
        {
            cities.ForEach(o =>
            {
                fromBox.Items.Add(o);
                toBox.Items.Add(o);
            });
        }
    }
}
