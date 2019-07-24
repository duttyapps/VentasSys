using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Alquiler
    {
        private static MySqlConnection con;

        public static string setAlquiler(Ent_Alquiler alquiler)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_ALQUILER";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@FECHA_ENT", alquiler.fecha_ent);
            cmd.Parameters["@FECHA_ENT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@HORA_ENT", alquiler.hora_ent);
            cmd.Parameters["@HORA_ENT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@FECHA_DEV", alquiler.fecha_dev);
            cmd.Parameters["@FECHA_DEV"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@HORA_DEV", alquiler.hora_dev);
            cmd.Parameters["@HORA_DEV"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@CLIENTE", alquiler.cliente);
            cmd.Parameters["@CLIENTE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@DETALLE", alquiler.detalle);
            cmd.Parameters["@DETALLE"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }
    }
}
