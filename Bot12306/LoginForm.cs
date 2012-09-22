using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class LoginForm : Form
    {
        private readonly Client _client = new Client();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            _client.Update();
            captchaPicture.Update();
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            captchaPicture.Update();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
