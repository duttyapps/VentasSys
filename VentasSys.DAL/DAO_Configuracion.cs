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
    public static class DAO_Configuracion
    {
        private static MySqlConnection con;

        public static Ent_Configuracion getConfiguracion()
        {
            Ent_Configuracion ent_configuracion = new Ent_Configuracion();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SEGT_GET_CONFIGURACION";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ent_configuracion.RUC = Convert.ToString(dr["RUC"]);
                ent_configuracion.RAZON_SOCIAL = Convert.ToString(dr["RAZON_SOCIAL"]);
                ent_configuracion.DIRECCION = Convert.ToString(dr["DIRECCION"]);
                ent_configuracion.TELEFONO = Convert.ToString(dr["TELEFONO"]);
                ent_configuracion.IGV = Convert.ToDouble(dr["IGV"]);
                ent_configuracion.TIPO_CAMBIO = Convert.ToDouble(dr["TIPO_CAMBIO"]);
                ent_configuracion.TIENDA = Convert.ToString(dr["TIENDA"]);
            }

            con.Close();

            return ent_configuracion;
        }
    }
}
