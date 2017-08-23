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
    public static class DAO_Productos
    {
        private static MySqlConnection con;

        public static List<Ent_Productos> getProductos(string nombre, string cat)
        {
            List<Ent_Productos> lstProductos = new List<Ent_Productos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_CATEGORIA", (cat == String.Empty) ? null : cat);
            cmd.Parameters["@PSTR_CATEGORIA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Productos producto = new Ent_Productos();
                producto.id = Convert.ToInt32(dr["ID"]);
                producto.id_cat = Convert.ToInt32(dr["ID_CAT"]);
                producto.nombre = Convert.ToString(dr["NOMBRE"]);
                producto.precio = Math.Round(Convert.ToDouble(dr["PRECIO"]), 2);

                lstProductos.Add(producto);
            }

            con.Close();

            return lstProductos;
        }

        public static int getStockProducto(int id_prod)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_STOCK_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_PRODUCTO_ID", id_prod);
            cmd.Parameters["@PSTR_PRODUCTO_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.Int32);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int retval = int.Parse(cmd.Parameters["@RETVAL"].Value.ToString());

            con.Close();

            return retval;
        }

        public static string insertarProducto(Ent_Productos producto)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PSTR_CAT_ID", producto.id_cat);
            cmd.Parameters["@PSTR_CAT_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", producto.nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_COSTO", producto.costo);
            cmd.Parameters["@PSTR_COSTO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_PRECIO", producto.precio);
            cmd.Parameters["@PSTR_PRECIO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_STOCK", producto.stock);
            cmd.Parameters["@PSTR_STOCK"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ACTIVO", producto.activo);
            cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }
    }
}
