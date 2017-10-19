using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Clientes
    {
        private static MySqlConnection con;

        public static List<Ent_Clientes> getClientesxNombre(string nombre, string tipo)
        {
            List<Ent_Clientes> lstClientes = new List<Ent_Clientes>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CLIENTES_X_NOMBRE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIPO", tipo);
            cmd.Parameters["@PSTR_TIPO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = Convert.ToString(dr["ID"]);
                cliente.nombres = Convert.ToString(dr["NOMBRES"]);
                cliente.apellidos = Convert.ToString(dr["APELLIDOS"]);
                cliente.apellidos_nombres = ((cliente.apellidos != String.Empty) ? cliente.apellidos + ", " : "") + cliente.nombres;
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);
                cliente.email = Convert.ToString(dr["EMAIL"]);
                cliente.telefono = Convert.ToString(dr["TELEFONO"]);

                lstClientes.Add(cliente);
            }

            con.Close();

            return lstClientes;
        }

        public static List<Ent_Clientes> getClientesxDNI(string dni, string tipo)
        {
            List<Ent_Clientes> lstClientes = new List<Ent_Clientes>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CLIENTES_X_DNI";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_DNI", dni);
            cmd.Parameters["@PSTR_DNI"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIPO", tipo);
            cmd.Parameters["@PSTR_TIPO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = Convert.ToString(dr["ID"]);
                cliente.nombres = Convert.ToString(dr["NOMBRES"]);
                cliente.apellidos = Convert.ToString(dr["APELLIDOS"]);
                cliente.apellidos_nombres = ((cliente.apellidos != String.Empty) ? cliente.apellidos + ", " : "") + cliente.nombres;
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);
                cliente.email = Convert.ToString(dr["EMAIL"]);
                cliente.telefono = Convert.ToString(dr["TELEFONO"]);

                lstClientes.Add(cliente);
            }

            con.Close();

            return lstClientes;
        }

        public static List<Ent_Clientes> getClientesRegistrados(string dni, string nombre)
        {
            List<Ent_Clientes> lstClientes = new List<Ent_Clientes>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CLIENTES_REGISTRADOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_DNI", dni);
            cmd.Parameters["@PSTR_DNI"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = Convert.ToString(dr["ID"]);
                cliente.nombres = Convert.ToString(dr["NOMBRES"]);
                cliente.apellidos = Convert.ToString(dr["APELLIDOS"]);
                cliente.apellidos_nombres = ((cliente.apellidos != String.Empty) ? cliente.apellidos + ", " : "") + cliente.nombres;
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);
                cliente.email = Convert.ToString(dr["EMAIL"]);
                cliente.telefono = Convert.ToString(dr["TELEFONO"]);
                cliente.fecha_reg = Convert.ToString(dr["FECHA_REG"]);
                cliente.tipo = Convert.ToString(dr["TIPO"]);

                lstClientes.Add(cliente);
            }

            con.Close();

            return lstClientes;
        }

        public static bool existeCliente(string dni)
        {
            bool result = false;

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_COD_CLIENTE", dni);
            cmd.Parameters["@PSTR_COD_CLIENTE"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                result = true;
            }

            con.Close();
            return result;
        }

        public static string insertarCliente(Ent_Clientes cliente)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@PSTR_DNI", cliente.dni);
            cmd.Parameters["@PSTR_DNI"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRES", cliente.nombres);
            cmd.Parameters["@PSTR_NOMBRES"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_APELLIDOS", (cliente.apellidos == String.Empty) ? null : cliente.apellidos);
            cmd.Parameters["@PSTR_APELLIDOS"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_DIRECCION", cliente.direccion);
            cmd.Parameters["@PSTR_DIRECCION"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TELEFONO", cliente.telefono);
            cmd.Parameters["@PSTR_TELEFONO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_EMAIL", cliente.email);
            cmd.Parameters["@PSTR_EMAIL"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIPO", cliente.tipo);
            cmd.Parameters["@PSTR_TIPO"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }

        public static string editarCliente(Ent_Clientes cliente)
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

                cmd.CommandText = "SP_SYS_UPD_CLIENTE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", cliente.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_NOMBRE", cliente.nombres);
                cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_APELLIDO", cliente.apellidos);
                cmd.Parameters["@PSTR_APELLIDO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_DIRECCION", cliente.direccion);
                cmd.Parameters["@PSTR_DIRECCION"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_EMAIL", cliente.email);
                cmd.Parameters["@PSTR_EMAIL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TELEFONO", cliente.telefono);
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

        public static string eliminarCliente(string id)
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

                cmd.CommandText = "SP_SYS_UPD_ELIMINAR_CLIENTE";
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
