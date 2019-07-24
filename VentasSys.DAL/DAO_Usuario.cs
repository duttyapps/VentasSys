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

        public static string insertarUsuario(Ent_Usuario usuario)
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

                cmd.CommandText = "SP_SYS_SET_USUARIO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", usuario.dni);
                cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_PASSWORD", usuario.password);
                cmd.Parameters["@PSTR_PASSWORD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_NOMBRES", usuario.nombres);
                cmd.Parameters["@PSTR_NOMBRES"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_SEXO", usuario.sexo);
                cmd.Parameters["@PSTR_SEXO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_FECHA_NAC", usuario.fecha_nac);
                cmd.Parameters["@PSTR_FECHA_NAC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_EMAIL", usuario.email);
                cmd.Parameters["@PSTR_EMAIL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TELEFONO", usuario.telefono);
                cmd.Parameters["@PSTR_TELEFONO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_RANGO", usuario.rango);
                cmd.Parameters["@PSTR_RANGO"].Direction = ParameterDirection.Input;

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

        public static string editarUsuario(Ent_Usuario usuario)
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

                cmd.CommandText = "SP_SYS_UPD_USUARIO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", usuario.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_EMAIL", usuario.email);
                cmd.Parameters["@PSTR_EMAIL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TELEFONO", usuario.telefono);
                cmd.Parameters["@PSTR_TELEFONO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_RANGO", usuario.rango);
                cmd.Parameters["@PSTR_RANGO"].Direction = ParameterDirection.Input;

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

        public static string eliminarUsuario(string id)
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

                cmd.CommandText = "SP_SYS_DEL_USUARIO";
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

        public static string restablecerContraseña(string id, string pass)
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

                cmd.CommandText = "SP_SYS_UPD_USUARIO_PWD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_PASSWORD", pass);
                cmd.Parameters["@PSTR_PASSWORD"].Direction = ParameterDirection.Input;

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