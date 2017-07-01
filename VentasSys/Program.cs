using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.Utils;

namespace VentasSys
{
    static class Program
    {
        private static Log log = new Log();

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log.Info("--- Aplicación Iniciada ---", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            new frmLogin().Show();
            Application.Run();
        }
    }
}
