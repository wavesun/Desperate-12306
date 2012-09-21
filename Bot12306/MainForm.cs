using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            var client = new Client();
            captchaDisplay.Image = client.FetchCaptcha();
        }
    }
}
