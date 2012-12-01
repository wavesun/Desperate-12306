using System;
using System.Windows.Forms;
using YA12306.View;
using YA12306.View.WebBrowserControlDialogs;

namespace YA12306.Model
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WindowsInterop.Hook();

            Application.Run(new MainFrame());

            WindowsInterop.Unhook();
        }
    }
}
