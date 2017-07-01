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
    public static class DAO_Ventas
    {
        private static MySqlConnection con;

        public static List<Ent_TipoVentas> getTipoVenta(String codigo)
        {
            List<Ent_TipoVentas> lstTipoVenta = new List<Ent_TipoVentas>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_TIPOS_VENTAS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_CODIGO", (codigo == String.Empty) ? null : codigo);
            cmd.Parameters["@PSTR_CODIGO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_TipoVentas tipoVenta = new Ent_TipoVentas();
                tipoVenta.id = Convert.ToString(dr["ID"]);
                tipoVenta.codigo = Convert.ToString(dr["CODIGO"]);
                tipoVenta.descripcion = Convert.ToString(dr["DESCRIPCION"]);

                lstTipoVenta.Add(tipoVenta);
            }

            con.Close();

            return lstTipoVenta;
        }

        public static string getCorrelativo(string tipo_venta)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CORRELATIVO_VENTA";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", tipo_venta);
            cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString().PadLeft(6, '0');

            con.Close();

            return retval;
        }
    }
}
