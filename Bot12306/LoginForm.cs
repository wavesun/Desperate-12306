using System;
using System.Windows.Forms;

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
