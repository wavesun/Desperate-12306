using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class CaptchaPictureBox : UserControl
    {
        private readonly Client _client;

        public CaptchaPictureBox(Client client)
        {
            _client = client;

            InitializeComponent();
        }

        public string Url { get; set; }

        public new void Update()
        {
            pictureBox.Image = _client.FetchCaptcha();
            base.Update();
        }
    }
}
