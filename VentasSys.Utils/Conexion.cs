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
    }
}
