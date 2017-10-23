using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Usuario
    {
        private static MySqlConnection con;

        public static Ent_Usuario login(Ent_Usuario ent)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SEGT_LOGIN_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@USER", ent.username);
            cmd.Parameters["@USER"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PASS", ent.password);
            cmd.Parameters["@PASS"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ent.nombres = Convert.ToString(dr["NOMBRES"]);
                ent.rango = Convert.ToString(dr["RANGO"]);
            }

            con.Close();

            return ent;
        }

        public static List<Ent_Usuario> getUsuarios(Ent_Usuario ent)
        {
            List<Ent_Usuario> lstUsuarios = new List<Ent_Usuario>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_USUARIOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", (ent.dni == String.Empty) ? null : ent.dni);
            cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_RANGO", (ent.rango == String.Empty) ? null : ent.rango);
            cmd.Parameters["@PSTR_RANGO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Usuario usuario = new Ent_Usuario();
                usuario.id = Convert.ToString(dr["ID"]);
                usuario.codigo = Convert.ToString(dr["CODIGO"]);
                usuario.nombres = Convert.ToString(dr["NOMBRES"]);
                usuario.rango = Convert.ToString(dr["RANGO"]);
                usuario.rango_des = Convert.ToString(dr["RANGO_DES"]);
                usuario.dni = Convert.ToString(dr["NRO_DOC"]);
                usuario.fecha_reg = Convert.ToString(dr["FECHA_REG"]);
                usuario.fecha_nac = Convert.ToString(dr["FECHA_NAC"]);
                usuario.sexo = Convert.ToString(dr["SEXO"]);
                usuario.email = Convert.ToString(dr["EMAIL"]);
                usuario.telefono = Convert.ToString(dr["TELEFONO"]);

                lstUsuarios.Add(usuario);
            }

            con.Close();

            return lstUsuarios;
        }

        public static Ent_Usuario getUsuario(string id)
        {
            Ent_Usuario usuario = new Ent_Usuario();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID", id);
            cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usuario.id = Convert.ToString(dr["ID"]);
                usuario.codigo = Convert.ToString(dr["CODIGO"]);
                usuario.nombres = Convert.ToString(dr["NOMBRES"]);
                usuario.rango = Convert.ToString(dr["RANGO"]);
                usuario.rango_des = Convert.ToString(dr["RANGO_DES"]);
                usuario.dni = Convert.ToString(dr["NRO_DOC"]);
                usuario.fecha_reg = Convert.ToString(dr["FECHA_REG"]);
                usuario.fecha_nac = Convert.ToString(dr["FECHA_NAC"]);
                usuario.sexo = Convert.ToString(dr["SEXO"]);
                usuario.email = Convert.ToString(dr["EMAIL"]);
                usuario.telefono = Convert.ToString(dr["TELEFONO"]);
            }

            con.Close();

            return usuario;
        }
    }
}