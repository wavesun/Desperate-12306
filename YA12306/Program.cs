using System;
using System.Windows.Forms;
using WebBrowserControlDialogs;

namespace YA12306
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
