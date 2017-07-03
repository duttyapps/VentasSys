using MySql.Data.MySqlClient;
using System;

namespace VentasSys.Utils
{
    public static class Conexion
    {
        private static String IP = IniFile.IniReadValue("DATABASE", "IP");
        private static String USER = IniFile.IniReadValue("DATABASE", "USER");
        private static String PASS = IniFile.IniReadValue("DATABASE", "PASS");
        private static String DB = IniFile.IniReadValue("DATABASE", "DB");
        private static String myConnectionString = "server=" + IP + ";uid=" + USER + ";pwd=" + PASS + ";database=" + DB + ";";

        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            return conn;
        }

        public static string tryConnection(string _IP, string _USER, string _PASS, string _DB)
        {
            MySqlConnection conn = null;
            try
            {
                String _myConnectionString = "server=" + _IP + ";uid=" + _USER + ";pwd=" + _PASS + ";database=" + _DB + ";";
                conn = new MySqlConnection(_myConnectionString);
                conn.Open();
                return "0";
            } catch(MySqlException ex)
            {
                return ex.Message;
            } finally
            {
                conn.Close();
            }
        }
    }
}
