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

        public static List<Ent_Clientes> getClientesxNombre(string nombre)
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

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = Convert.ToString(dr["ID"]);
                cliente.nombres = Convert.ToString(dr["NOMBRES"]);
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);

                lstClientes.Add(cliente);
            }

            con.Close();

            return lstClientes;
        }

        public static List<Ent_Clientes> getClientesxDNI(string dni)
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

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = Convert.ToString(dr["ID"]);
                cliente.nombres = Convert.ToString(dr["NOMBRES"]);
                cliente.dni = Convert.ToString(dr["DNI"]);
                cliente.direccion = Convert.ToString(dr["DIRECCION"]);

                lstClientes.Add(cliente);
            }

            con.Close();

            return lstClientes;
        }
    }
}
