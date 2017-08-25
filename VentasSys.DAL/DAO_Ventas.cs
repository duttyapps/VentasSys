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
    public static class DAO_Ventas
    {
        private static MySqlConnection con;

        public static List<Ent_TipoVentas> getTipoVenta(String codigo)
        {
            List<Ent_TipoVentas> lstTipoVenta = new List<Ent_TipoVentas>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_TIPOS_VENTAS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_CODIGO", (codigo == String.Empty) ? null : codigo);
            cmd.Parameters["@PSTR_CODIGO"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_TipoVentas tipoVenta = new Ent_TipoVentas();
                tipoVenta.id = Convert.ToString(dr["ID"]);
                tipoVenta.codigo = Convert.ToString(dr["CODIGO"]);
                tipoVenta.descripcion = Convert.ToString(dr["DESCRIPCION"]);

                lstTipoVenta.Add(tipoVenta);
            }

            con.Close();

            return lstTipoVenta;
        }

        public static string getCorrelativo(string tipo_venta)
        {
            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_CORRELATIVO_VENTA";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", tipo_venta);
            cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
            cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            string retval = cmd.Parameters["@RETVAL"].Value.ToString().PadLeft(6, '0');

            con.Close();

            return retval;
        }

        public static string procesarVenta(Ent_Venta cabecera)
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

                cmd.CommandText = "SP_SET_GUARDARVENTA_CAB";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_NUMERO_DOC", cabecera.nro_doc);
                cmd.Parameters["@PSTR_NUMERO_DOC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", cabecera.tipo_venta);
                cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_FORMA_PAGO", cabecera.forma_pago);
                cmd.Parameters["@PSTR_FORMA_PAGO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CANTIDAD", cabecera.cantidad);
                cmd.Parameters["@PSTR_CANTIDAD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_TOTAL", double.Parse(cabecera.monto_total.ToString("#.##")));
                cmd.Parameters["@PSTR_MONTO_TOTAL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_RECIBIDO", cabecera.monto_recibo);
                cmd.Parameters["@PSTR_MONTO_RECIBIDO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_VUELTO", cabecera.monto_vuelto);
                cmd.Parameters["@PSTR_MONTO_VUELTO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CLIENTE", cabecera.cliente_doc);
                cmd.Parameters["@PSTR_CLIENTE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", cabecera.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();

                if (retval == "1")
                {
                    string retval_det;

                    cmd.CommandText = "SP_SET_GUARDARVENTA_DET";
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (Ent_Productos prd in cabecera.lstProductos)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                        cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@PSTR_NUMBERO_CAB", cabecera.nro_doc);
                        cmd.Parameters["@PSTR_NUMBERO_CAB"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_ID_PRODUCTO", prd.id);
                        cmd.Parameters["@PSTR_ID_PRODUCTO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_DESC_PRODUCTO", prd.nombre);
                        cmd.Parameters["@PSTR_DESC_PRODUCTO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_CANTIDAD", prd.cantidad);
                        cmd.Parameters["@PSTR_CANTIDAD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_PRECIO_UNIT", prd.precio);
                        cmd.Parameters["@PSTR_PRECIO_UNIT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PSTR_MONTO_TOTAL", (prd.precio * prd.cantidad));
                        cmd.Parameters["@PSTR_MONTO_TOTAL"].Direction = ParameterDirection.Input;

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
    }
}
