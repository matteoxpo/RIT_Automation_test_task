using System;
using System.Windows.Forms;

namespace Presentation
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string tmp = @"C:\Users\Сережа\map_markers_bd.mdf";
            string bdConnectionConfiguration =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + tmp + ";Integrated Security=True";
            Application.Run(new MainForm(bdConnectionConfiguration));
        }
    }
}
