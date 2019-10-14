using System;
using System.Windows.Forms;

namespace Atlacomm.Archiver
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new MainWindow());
        }
    }
}
