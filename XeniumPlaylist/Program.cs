using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace XeniumPlaylist
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string cultureInfoName = (args.Length > 1 ? args[0] : null);
            try
            {
                if (cultureInfoName != null)
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfoName);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error (check command line)", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Application.Run(new frmPlaylist());
        }
    }
}
