using System;
using System.Diagnostics;
using System.Windows.Forms;
using Bot12306.Properties;
using YA12306;

namespace Bot12306
{
    public partial class LoginForm : Form
    {
        private const int MaxRetry = 999999;
        private readonly Client _client = new Client();

        public LoginForm()
        {
            InitializeComponent();
            captchaPicture.Client = _client;
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
            if (Login())
                Close();
        }

        private bool Login()
        {
            for (int i = 0; i < MaxRetry; ++i)
            {
                try
                {
                    messageLabel.Text = string.Format(Resources.RetryMessage, i + 1);
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
