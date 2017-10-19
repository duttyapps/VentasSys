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

        public static string insertarCategoria(Ent_CategoriaProductos categoria)
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

                cmd.CommandText = "SP_SYS_SET_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_NOMBRE", categoria.nombre);
                cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ACTIVO", categoria.activo);
                cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

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

        public static string editarCategoria(Ent_CategoriaProductos categoria)
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

                cmd.CommandText = "SP_SYS_UPD_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", categoria.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_NOMBRE", categoria.nombre);
                cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ACTIVO", categoria.activo);
                cmd.Parameters["@PSTR_ACTIVO"].Direction = ParameterDirection.Input;

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

        public static string eliminarCategoria(string id)
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

                cmd.CommandText = "SP_SYS_UPD_ELIMINAR_CATEGORIA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

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
