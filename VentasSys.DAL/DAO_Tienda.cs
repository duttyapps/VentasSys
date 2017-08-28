using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Tienda
    {
        private static MySqlConnection con;

        public static List<Ent_Tienda> getTiendas()
        {
            List<Ent_Tienda> lstTiendas = new List<Ent_Tienda>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_COMPLEJOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_COD_TIENDA", String.Empty);
            cmd.Parameters["@PSTR_COD_TIENDA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Tienda tienda = new Ent_Tienda();
                tienda.cod_tienda = Convert.ToString(dr["COD_TIENDA"]);
                tienda.des_tienda = Convert.ToString(dr["NOMBRE_TIENDA"]);

                lstTiendas.Add(tienda);
            }

            con.Close();

            return lstTiendas;
        }

        public static Ent_Tienda getTienda(string cod_tienda)
        {
            List<Ent_Tienda> lstTiendas = new List<Ent_Tienda>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_COMPLEJOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_COD_TIENDA", cod_tienda);
            cmd.Parameters["@PSTR_COD_TIENDA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            Ent_Tienda tienda = new Ent_Tienda();

            while (dr.Read())
            {
                tienda.cod_tienda = Convert.ToString(dr["COD_TIENDA"]);
                tienda.des_tienda = Convert.ToString(dr["NOMBRE_TIENDA"]);
            }

            con.Close();

            return tienda;
        }
    }
}
