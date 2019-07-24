using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Distribucion
    {
        private static MySqlConnection con;

        public static string setDistribucion(Ent_Distribucion distribucion)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_DISTRIBUCION";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@FECHA", distribucion.fecha);
            cmd.Parameters["@FECHA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@HORA", distribucion.hora);
            cmd.Parameters["@HORA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@DESTINO", distribucion.destino);
            cmd.Parameters["@DESTINO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ENCARGADO", distribucion.encargado);
            cmd.Parameters["@ENCARGADO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@DETALLE", distribucion.detalle);
            cmd.Parameters["@DETALLE"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }
    }
}
