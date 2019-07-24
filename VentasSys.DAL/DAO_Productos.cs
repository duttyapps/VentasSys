using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Productos
    {
        private static MySqlConnection con;

        public static List<Ent_Productos> getProductos(string nombre, string codigo, string cat, string tienda, string estado, string alquiler)
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

            cmd.Parameters.AddWithValue("@PSTR_CODIGO", codigo);
            cmd.Parameters["@PSTR_CODIGO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIENDA", tienda);
            cmd.Parameters["@PSTR_TIENDA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ESTADO", estado);
            cmd.Parameters["@PSTR_ESTADO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ALQUILER", alquiler);
            cmd.Parameters["@PSTR_ALQUILER"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Productos producto = new Ent_Productos();
                producto.id = Convert.ToInt32(dr["ID"]);
                producto.cod_producto = Convert.ToString(dr["CODIGO"]);
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
                producto.cod_producto = Convert.ToString(dr["CODIGO"]);
                producto.id_cat = Convert.ToInt32(dr["ID_CAT"]);
                producto.nombre = Convert.ToString(dr["NOMBRE"]);
                producto.precio = Convert.ToDouble(dr["PRECIO"]);
                producto.costo = Convert.ToDouble(dr["COSTO"]);
                producto.stock = Convert.ToInt32(dr["STOCK"]);
                producto.cod_tienda = Convert.ToString(dr["TIENDA_COD"]);
                producto.fecha_registro = Convert.ToString(dr["FECHA_REG"]);
                producto.proveedor = Convert.ToString(dr["PROVEEDOR"]);
                producto.activo = Convert.ToString(dr["ACTIVO"]);
                producto.alquiler = Convert.ToString(dr["ALQUILER"]);
                producto.monto_alquiler = Convert.ToDouble(dr["MONTO_ALQUILER"]);
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

            cmd.Parameters.AddWithValue("@PSTR_PROVEEDOR", producto.proveedor);
            cmd.Parameters["@PSTR_PROVEEDOR"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_CAT_ID", producto.id_cat);
            cmd.Parameters["@PSTR_CAT_ID"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", producto.nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_USUARIO", producto.usuario);
            cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_COSTO", producto.costo);
            cmd.Parameters["@PSTR_COSTO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_PRECIO", producto.precio);
            cmd.Parameters["@PSTR_PRECIO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_STOCK", producto.stock);
            cmd.Parameters["@PSTR_STOCK"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_MEDIDA", producto.medida);
            cmd.Parameters["@PSTR_MEDIDA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_PESO", producto.peso);
            cmd.Parameters["@PSTR_PESO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ACTIVO", producto.activo);
            cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ALQUILER", producto.alquiler);
            cmd.Parameters["@PSTR_ALQUILER"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_PRECIO_ALQUILER", producto.monto_alquiler);
            cmd.Parameters["@PSTR_PRECIO_ALQUILER"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_CODIGO", producto.cod_producto);
            cmd.Parameters["@PSTR_CODIGO"].Direction = ParameterDirection.Input;

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

        public static string editarProducto(Ent_Productos producto)
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

                cmd.CommandText = "SP_SYS_UPD_PRODUCTO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", producto.cod_tienda);
                cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ID", producto.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

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

                cmd.Parameters.AddWithValue("@PSTR_PROV_ID", producto.proveedor);
                cmd.Parameters["@PSTR_PROV_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MEDIDA", producto.medida);
                cmd.Parameters["@PSTR_MEDIDA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_PESO", producto.peso);
                cmd.Parameters["@PSTR_PESO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ACTIVO", producto.activo);
                cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ALQUILER", producto.alquiler);
                cmd.Parameters["@PSTR_ALQUILER"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_PRECIO_ALQUILER", producto.monto_alquiler);
                cmd.Parameters["@PSTR_PRECIO_ALQUILER"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CODIGO", producto.cod_producto);
                cmd.Parameters["@PSTR_CODIGO"].Direction = ParameterDirection.Input; 

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

        public static List<Ent_Proveedores> getProveedores()
        {
            List<Ent_Proveedores> lstProveedores = new List<Ent_Proveedores>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PROVEEDORES";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_PROVEEDOR", "");
            cmd.Parameters["@PSTR_PROVEEDOR"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Proveedores proveedores = new Ent_Proveedores();
                proveedores.id = Convert.ToString(dr["ID"]);
                proveedores.nombre = Convert.ToString(dr["NOMBRE"]);
                proveedores.direccion = Convert.ToString(dr["DIRECCION"]);
                proveedores.telefono = Convert.ToString(dr["TELEFONO"]);

                lstProveedores.Add(proveedores);
            }

            con.Close();

            return lstProveedores;
        }

        public static void getReporteStockProductos(string cat, string estado, string tienda, ref DataSet ds, ref DataTable dt)
        {
            List<Ent_Productos> lstProductos = new List<Ent_Productos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_REPORTE_STOCK_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID_CAT", (cat == String.Empty) ? null : cat);
            cmd.Parameters["@PSTR_ID_CAT"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ACTIVO", (estado == String.Empty) ? null : estado);
            cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_ID_TIENDA", (tienda == String.Empty) ? null : tienda);
            cmd.Parameters["@PSTR_ID_TIENDA"].Direction = ParameterDirection.Input;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);
            da.Fill(dt);

            con.Close();
        }

        public static List<Ent_Productos> get_ProductoAlerta()
        {
            List<Ent_Productos> lista = new List<Ent_Productos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "sp_get_producto_Alerta";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Productos producto = new Ent_Productos();
                producto.id = Convert.ToInt32(dr["ID"]);
                producto.nombre = Convert.ToString(dr["NOMBRE"]);
                producto.precio = Convert.ToDouble(dr["PRECIO"]);
                producto.costo = Convert.ToDouble(dr["COSTO"]);
                producto.stock = Convert.ToInt32(dr["cantidad"]);
                lista.Add(producto);
            }

            con.Close();

            return lista;
        }
    }
}
