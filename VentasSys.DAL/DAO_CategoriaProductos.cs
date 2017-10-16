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

        public static List<Ent_CategoriaProductos> getCategorias(string nombre, string activo)
        {
            List<Ent_CategoriaProductos> lstCategorias = new List<Ent_CategoriaProductos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CATEGORIAS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_CATEGORIA", nombre);
            cmd.Parameters["@PSTR_CATEGORIA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ACTIVO", (activo == String.Empty) ? null : activo);
            cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_CategoriaProductos categoria = new Ent_CategoriaProductos();
                categoria.id = Convert.ToString(dr["ID"]);
                categoria.codigo = Convert.ToString(dr["CODIGO"]);
                categoria.nombre = Convert.ToString(dr["NOMBRE"]);
                categoria.fecha = Convert.ToString(dr["FECHA_REGISTRO"]);
                categoria.activo = Convert.ToString(dr["ACTIVO"]);

                lstCategorias.Add(categoria);
            }

            con.Close();

            return lstCategorias;
        }
    }
}
