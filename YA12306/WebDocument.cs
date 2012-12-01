using System.Windows.Forms;

namespace YA12306
{
    public abstract class WebDocument
    {
        public abstract bool Loaded { get; }

        public HtmlDocument Document { get; set; }

        protected HtmlWindow GetFrame(string name)
        {
            return Document.Window.Frames[name];
        }
    }
}