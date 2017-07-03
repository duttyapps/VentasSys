using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_CategoriaProductos
    {
        private static MySqlConnection con;

        public static List<Ent_CategoriaProductos> getCategorias()
        {
            List<Ent_CategoriaProductos> lstCategorias = new List<Ent_CategoriaProductos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CATEGORIAS";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_CategoriaProductos categoria = new Ent_CategoriaProductos();
                categoria.id = Convert.ToString(dr["ID"]);
                categoria.nombre = Convert.ToString(dr["NOMBRE"]);

                lstCategorias.Add(categoria);
            }

            con.Close();

            return lstCategorias;
        }
    }
}
