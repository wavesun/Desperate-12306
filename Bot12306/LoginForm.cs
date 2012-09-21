using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void RefreshCaptcha()
        {
            var client = new Client();
            captchaDisplay.Image = client.FetchCaptcha();
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
