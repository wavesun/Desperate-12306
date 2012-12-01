using System.Windows.Forms;
using YA12306.Model;

namespace YA12306.View
{
    public partial class CaptchaPictureBox : UserControl
    {
        public CaptchaPictureBox()
        {
            InitializeComponent();
        }

        public Client Client { get; set; }

        public string Url { get; set; }

        public new void Update()
        {
            pictureBox.Image = Client.Captcha;
            base.Update();
        }
    }
}
