using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Mantenimiento
    {
        private static MySqlConnection con;
/*
        public static string setMantenimiento(Ent_Mantenimiento mantenimiento)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_SET_MANTENIMIENTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.Parameters.AddWithValue("@FECHA", mantenimiento.fecha);
            cmd.Parameters["@FECHA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@TIEMPO", mantenimiento.tiempo);
            cmd.Parameters["@TIEMPO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@CLIENTE", mantenimiento.cliente);
            cmd.Parameters["@CLIENTE"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@ENCARGADO", mantenimiento.encargado);
            cmd.Parameters["@ENCARGADO"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@DETALLE", mantenimiento.detalle);
            cmd.Parameters["@DETALLE"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }
        */
        public static List<Ent_Tipo_Mantenimiento> getTipoMantenimiento(String showAll)
        {
            List<Ent_Tipo_Mantenimiento> lista = new List<Ent_Tipo_Mantenimiento>();
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_TIPO_MANTENIMIENTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_SHOW_ALL", showAll);
            cmd.Parameters["@PSTR_SHOW_ALL"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Tipo_Mantenimiento tipo = new Ent_Tipo_Mantenimiento();
                tipo.id = int.Parse(Convert.ToString(dr["ID"]));
                tipo.descripcion = Convert.ToString(dr["DESCRIPCION"]);
                tipo.estado = Convert.ToString(dr["ESTADO"]) == "1" ? "Activo" : "Inactivo";

                lista.Add(tipo);                
            }
            con.Close();

            return lista;
        }

        public static string getCorrelativo()
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CORRELATIVO_MANTENIMIENTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString();

            con.Close();

            return retval;
        }

        public static string setProg_Mantenimiento(Ent_Prog_Mantenimiento cabecera_mant)
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

                cmd.CommandText = "SP_SET_GUARDARPROG_MANTENIMIENTO_CAB";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@RETID", MySqlDbType.VarChar);
                cmd.Parameters["@RETID"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_NUM_DOC", cabecera_mant.documento);
                cmd.Parameters["@PSTR_NUM_DOC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TIENDA", cabecera_mant.tienda);
                cmd.Parameters["@PSTR_TIENDA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TIPO_PERSONA", cabecera_mant.tipo_persona);
                cmd.Parameters["@PSTR_TIPO_PERSONA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CLIENTE", cabecera_mant.numero_documento);
                cmd.Parameters["@PSTR_CLIENTE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", cabecera_mant.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ESTADO", cabecera_mant.estado);
                cmd.Parameters["@PSTR_ESTADO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_FECHA_SALIDA", cabecera_mant.fecha_salida);
                cmd.Parameters["@PSTR_FECHA_SALIDA"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();
                string id_cab = cmd.Parameters["@RETID"].Value.ToString();

                if (retval == "1")
                {
                    string retval_det;

                    cmd.CommandText = "SP_SET_GUARDARPROG_MANTENIMIENTO_DET";
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (Ent_Tipo_Mantenimiento prog in cabecera_mant.mantenimiento)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                        cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@PSTR_NUM_DOC", id_cab);
                        cmd.Parameters["@PSTR_NUM_DOC"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_TIPO_MANTENIMIENTO", prog.id);
                        cmd.Parameters["@PSTR_TIPO_MANTENIMIENTO"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        retval_det = cmd.Parameters["@RETVAL"].Value.ToString();

                        if (retval_det != "1")
                        {
                            tr.Rollback();
                            return retval_det;
                        }
                    }
                }
                else
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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


        public static List<Ent_Mantenimiento> getConsultaMantenimiento(string nombre, string numero_doc)
        {
            List<Ent_Mantenimiento> lista = new List<Ent_Mantenimiento>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_MANTENIMIENTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", (numero_doc == "") ? null : numero_doc);
            cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NOMBRE", (nombre == "") ? null : nombre);
            cmd.Parameters["@PSTR_NOMBRE"].Direction = ParameterDirection.Input;



            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Mantenimiento mant = new Ent_Mantenimiento();
                mant.id = Convert.ToInt32(dr["ID"]);
                mant.num_doc = "N° 001-" + Convert.ToString(dr["ID"]).ToString().PadLeft(6, '0');
                mant.tienda = Convert.ToString(dr["TIENDA"]);
                mant.fecha_registro = Convert.ToString(dr["FECHA_REGISTRO"]);
                mant.cliente_doc = Convert.ToString(dr["CLIENTE"]);
                mant.cliente = Convert.ToString(dr["CLIENTE_DES"]);
                mant.estado = Convert.ToString(dr["ESTADO"]);
                mant.fecha_salida = Convert.ToString(dr["FECHA_SALIDA"]);
                mant.direccion = Convert.ToString(dr["DIRECCION"]);

                lista.Add(mant);
            }

            con.Close();
            return lista;
        }



        public static List<Ent_Tipo_Mantenimiento> getConsultaMantenimientoDetalle(int id)
        {
            List<Ent_Tipo_Mantenimiento> lista = new List<Ent_Tipo_Mantenimiento>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_MANTENIMIENTO_DETALLE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID", id);
            cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Tipo_Mantenimiento mant = new Ent_Tipo_Mantenimiento();
                mant.descripcion = Convert.ToString(dr["DESCRIPCION"]);
                lista.Add(mant);
            }

            con.Close();
            return lista;
        }

        public static List<Ent_Mantenimiento> getAlertaMantenimiento()
        {
            List<Ent_Mantenimiento> lista = new List<Ent_Mantenimiento>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "sp_get_alerta_mantenimiento";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Mantenimiento mant = new Ent_Mantenimiento();
                mant.id = Convert.ToInt32(dr["ID"]);
                mant.cliente = Convert.ToString(dr["CLIENTE"]);
                mant.tienda = Convert.ToString(dr["PRODUCTO"]);
                mant.fecha_salida = Convert.ToString(dr["FECHA_MANT"]);
                lista.Add(mant);
            }

            con.Close();
            return lista;
        }

        public static string updMantenimiento(Ent_Prog_Mantenimiento mant)
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

                cmd.CommandText = "sp_sys_upd_mantenimiento";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", mant.documento);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ESTADO", mant.estado);
                cmd.Parameters["@PSTR_ESTADO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval != "1")
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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

        public static string setTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
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

                cmd.CommandText = "sp_sys_set_tipo_mantenimiento";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_DESCRIPCION", tipo.descripcion);
                cmd.Parameters["@PSTR_DESCRIPCION"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ESTADO", tipo.estado);
                cmd.Parameters["@PSTR_ESTADO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval != "1")
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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

        public static string updTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
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

                cmd.CommandText = "sp_sys_upd_tipo_mantenimiento";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", tipo.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_DESCRIPCION", tipo.descripcion);
                cmd.Parameters["@PSTR_DESCRIPCION"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ESTADO", tipo.estado);
                cmd.Parameters["@PSTR_ESTADO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval != "1")
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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

        public static string delTipoMantenimiento(Ent_Tipo_Mantenimiento tipo)
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

                cmd.CommandText = "sp_sys_del_tipo_mantenimiento";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", tipo.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval != "1")
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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

        public static string delMantenimiento(String id)
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

                cmd.CommandText = "sp_sys_del_mantenimiento";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval != "1")
                {
                    tr.Rollback();
                    return retval;
                }

                tr.Commit();
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
