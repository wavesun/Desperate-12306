using System;
using System.Diagnostics;
using System.Windows.Forms;
using Bot12306.Properties;
using YA12306;

namespace Bot12306
{
    public partial class LoginForm : Form
    {
        private readonly Client _client;
        private const int MaxRetry = 999999;

        public LoginForm(Client client)
        {
            InitializeComponent();

            _client = client;
            captchaPicture.Client = client;
        }

        public bool LoggedIn { get; private set; }

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
            if (Login())
            {
                LoggedIn = true;
                Close();
            }
        }

        private bool Login()
        {
            for (int i = 0; i < MaxRetry; ++i)
            {
                try
                {
                    messageLabel.Text = string.Format(Resources.RetryMessage, i + 1);
                    Application.DoEvents();
                    _client.Login(accountBox.Text, passwordBox.Text, captchaBox.Text);
                    return true;
                }
                catch (TooManyUsersException)
                {
                }
                catch(Unknown12306ResponceException e)
                {
                    Debug.WriteLine(e.Message);
                }
                catch (IncorrectPasswordException)
                {
                    messageLabel.Text = Resources.InvalidPasswordMessage;
                }
                catch (AccountLockedException)
                {
                    messageLabel.Text = Resources.AccountLockedMessage;
                }
            }
            messageLabel.Text = string.Format(Resources.TrialExceedsMaxMessage, MaxRetry);
            return false;
        }
    }
}
