using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fakturace_2009
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationContext ac;
            try
            {
                ac = new Fakturace_2009.ProgramInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Application.Run(ac);
        }
    }
}
