using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Usuario
    {
        private static MySqlConnection con;

        public static Ent_Usuario login(Ent_Usuario ent)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SEGT_LOGIN_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USER", ent.username);
            cmd.Parameters["@USER"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PASS", ent.password);
            cmd.Parameters["@PASS"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ent.nombres = Convert.ToString(dr["NOMBRES"]);
            }

            con.Close();

            return ent;
        }
    }
}