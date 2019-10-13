using System;
using System.Windows.Forms;

namespace Atlacomm.Archiver
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainWindow mainWindow = new MainWindow();

            Application.EnableVisualStyles();
            Application.Run(mainWindow);
        }
    }
}
