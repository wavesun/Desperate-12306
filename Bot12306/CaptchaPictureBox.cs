using System.Windows.Forms;
using YA12306;

namespace Bot12306
{
    public partial class CaptchaPictureBox : UserControl
    {
        public CaptchaPictureBox()
        {
            InitializeComponent();
        }

        public string Url { get; set; }

        public new void Update()
        {
            pictureBox.Image = new Client().FetchCaptcha();
            base.Update();
        }
    }
}
