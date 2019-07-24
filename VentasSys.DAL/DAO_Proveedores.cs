using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public class DAO_Proveedores
    {
        private static MySqlConnection con;

        public static List<Ent_Proveedores> getProveedores(Ent_Proveedores entity)
        {
            List<Ent_Proveedores> lstProveedores = new List<Ent_Proveedores>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PROVEEDORES";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_PROVEEDOR", entity.nombre);
            cmd.Parameters["@PSTR_PROVEEDOR"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Proveedores proveedor = new Ent_Proveedores();
                proveedor.id = Convert.ToString(dr["ID"]);
                proveedor.nombre = Convert.ToString(dr["NOMBRE"]);
                proveedor.direccion = Convert.ToString(dr["DIRECCION"]);
                proveedor.telefono = Convert.ToString(dr["TELEFONO"]);
                proveedor.activo = Convert.ToString(dr["ACTIVO"]);

                lstProveedores.Add(proveedor);
            }

            con.Close();

            return lstProveedores;
        }

        public static List<Ent_PagosProveedores> getPagos(string fecha)
        {
            List<Ent_PagosProveedores> lstProveedores = new List<Ent_PagosProveedores>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_PAGO_PROVEEDOR";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_FECHA", fecha);
            cmd.Parameters["@PSTR_FECHA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_PagosProveedores proveedor = new Ent_PagosProveedores();

                proveedor.codigo = Convert.ToString(dr["CODIGO"]);
                proveedor.fecha_emision = Convert.ToString(dr["FECHA_EMISION"]);
                proveedor.proveedor = Convert.ToString(dr["PROVEEDOR"]);
                proveedor.usuario = Convert.ToString(dr["USUARIO"]);
                proveedor.monto = Convert.ToDouble(dr["MONTO"]);

                lstProveedores.Add(proveedor);
            }

            con.Close();

            return lstProveedores;
        }

        public static string registrarPago(Ent_PagosProveedores ent)
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

                cmd.CommandText = "SP_SYS_SET_PAGO_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID_PROVEEDOR", ent.id_proveedor);
                cmd.Parameters["@PSTR_ID_PROVEEDOR"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_NRO_FACTURA", ent.nro_factura);
                cmd.Parameters["@PSTR_NRO_FACTURA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", ent.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO", ent.monto);
                cmd.Parameters["@PSTR_MONTO"].Direction = ParameterDirection.Input;
                
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

        public static string setProveedores (Ent_Proveedores ent)
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

                cmd.CommandText = "SP_SYS_SET_PROVEEDORES";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_PROVEEDOR", ent.nombre);
                cmd.Parameters["@PSTR_PROVEEDOR"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_DIRECCION", ent.direccion);
                cmd.Parameters["@PSTR_DIRECCION"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TELEFONO", ent.telefono);
                cmd.Parameters["@PSTR_TELEFONO"].Direction = ParameterDirection.Input;

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

        public static string uptProveedores(Ent_Proveedores ent)
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

                cmd.CommandText = "SP_SYS_UPD_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", ent.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_PROVEEDOR", ent.nombre);
                cmd.Parameters["@PSTR_PROVEEDOR"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_DIRECCION", ent.direccion);
                cmd.Parameters["@PSTR_DIRECCION"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TELEFONO", ent.telefono);
                cmd.Parameters["@PSTR_TELEFONO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ACTIVO", ent.activo);
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

        public static string delProveedores(Ent_Proveedores ent)
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

                cmd.CommandText = "SP_SYS_DEL_PROVEEDOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", ent.id);
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
