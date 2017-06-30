using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.Utils
{
    public static class Conexion
    {
        private static Log log = new Log();
        private static String myConnectionString = "server=127.0.0.1;uid=root;pwd=carlitos;database=ventassys;";

        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(myConnectionString);
            }
            catch (MySqlException ex)
            {
                log.Error(ex.Message.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return conn;
        }
    }
}
