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
            DialogResult = Login() ? DialogResult.OK : DialogResult.Retry;
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
                    continue;
                }
                catch (Unknown12306ResponceException e)
                {
                    Debug.WriteLine(e.Message);
                    continue;
                }
                catch (InvalidPasswordException)
                {
                    messageLabel.Text = Resources.InvalidPasswordMessage;
                }
                catch (AccountLockedException)
                {
                    messageLabel.Text = Resources.AccountLockedMessage;
                }
                catch (InvalidCaptchaException)
                {
                    messageLabel.Text = Resources.InvalidCaptchaMessage;
                }
                return false;
            }
            messageLabel.Text = string.Format(Resources.TrialExceedsMaxMessage, MaxRetry);
            return false;
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.SelectAll();
            }
        }
    }
}
