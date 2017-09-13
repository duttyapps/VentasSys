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

        public static List<Ent_Productos> getProductos(string nombre, string cat, string tienda)
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

            cmd.Parameters.AddWithValue("@PSTR_TIENDA", tienda);
            cmd.Parameters["@PSTR_TIENDA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Productos producto = new Ent_Productos();
                producto.id = Convert.ToInt32(dr["ID"]);
                producto.id_cat = Convert.ToInt32(dr["ID_CAT"]);
                producto.nombre = Convert.ToString(dr["NOMBRE"]);
                producto.precio = Convert.ToDouble(dr["PRECIO"]);
                producto.stock = Convert.ToInt32(dr["STOCK"]);
                producto.cod_tienda = Convert.ToString(dr["TIENDA_COD"]);
                producto.des_tienda = Convert.ToString(dr["TIENDA_DES"]);

                lstProductos.Add(producto);
            }

            con.Close();

            return lstProductos;
        }

        public static Ent_Productos getProducto(string id, string tienda)
        {
            Ent_Productos producto = new Ent_Productos();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID", id);
            cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", tienda);
            cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                producto.id = Convert.ToInt32(dr["ID"]);
                producto.id_cat = Convert.ToInt32(dr["ID_CAT"]);
                producto.nombre = Convert.ToString(dr["NOMBRE"]);
                producto.precio = Convert.ToDouble(dr["PRECIO"]);
                producto.costo = Convert.ToDouble(dr["COSTO"]);
                producto.stock = Convert.ToInt32(dr["STOCK"]);
                producto.cod_tienda = Convert.ToString(dr["TIENDA_COD"]);
                producto.fecha_registro = Convert.ToString(dr["FECHA_REG"]);
                producto.activo = Convert.ToString(dr["ACTIVO"]);
            }

            con.Close();

            return producto;
        }

        public static int getStockProducto(int id_prod, string tienda)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_STOCK_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.Int32);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PSTR_PRODUCTO_ID", id_prod);
            cmd.Parameters["@PSTR_PRODUCTO_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", tienda);
            cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            int retval = int.Parse(cmd.Parameters["@RETVAL"].Value.ToString());

            con.Close();

            return retval;
        }

        public static string insertarProducto(Ent_Productos producto, string tienda)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", tienda);
            cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

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

            cmd.Parameters.AddWithValue("@PSTR_USUARIO", producto.usuario);
            cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ACTIVO", producto.activo);
            cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }

        public static float getPrecioProducto(int id)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PRODUCTO_PRECIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.Float);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PSTR_PROD_ID", id);
            cmd.Parameters["@PSTR_PROD_ID"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            float retval = float.Parse(cmd.Parameters["@RETVAL"].Value.ToString());

            con.Close();

            return retval;
        }

        public static string eliminarProducto(string id)
        {
            MySqlTransaction tr = null;
            con = Conexion.getConnection();

            string retval = "1";

            try
            {
                con.Open();

                tr = con.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = con;
                cmd.Transaction = tr;

                cmd.CommandText = "SP_SYS_UPD_ELIMINAR_PRODUCTO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_PRODUCTO_ID", id);
                cmd.Parameters["@PSTR_PRODUCTO_ID"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval == "1")
                {
                    tr.Commit();
                }
                else
                {
                    tr.Rollback();
                    return retval;
                }

            }
            catch (MySqlException ex)
            {
                try
                {
                    tr.Rollback();
                }
                catch (MySqlException ex1)
                {
                    return ex1.ToString();
                }

                return ex.ToString();
            }
            finally
            {
                con.Close();
            }

            return retval;
        }
    }
}
