using System;
using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class mainFrame : Form
    {
        public mainFrame()
        {
            InitializeComponent();
        }

        private void mainFrame_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
