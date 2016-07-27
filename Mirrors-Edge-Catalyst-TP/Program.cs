using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirrors_Edge_Catalyst_TP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Checks if launched with Administrator
            if (LaunchedAsAdministrator())
            {
                Application.Run(new Form1()); // Starts Menu
            }
            else
            {
                MessageBox.Show("Please run Teleporter as Administrator");
            }
        }

        private static bool LaunchedAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
