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
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);
                cliente.email = Convert.ToString(dr["EMAIL"]);
                cliente.telefono = Convert.ToString(dr["TELEFONO"]);

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
    }
}
