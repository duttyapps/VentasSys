using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys.DAL
{
    public static class DAO_Ventas
    {
        private static MySqlConnection con;

        public static List<Ent_Venta> getVentas(Ent_Venta ent_tienda)
        {
            List<Ent_Venta> lstVenta = new List<Ent_Venta>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_VENTAS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", ent_tienda.cod_tienda);
            cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", (ent_tienda.nro_doc.ToString() == "0") ? null : ent_tienda.nro_doc.ToString());
            cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", ent_tienda.tipo_venta);
            cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Venta venta = new Ent_Venta();
                venta.id_cab = Convert.ToInt32(dr["ID"]);
                venta.nro_doc = Convert.ToInt32(dr["NUMERO_DOC"]);
                venta.nro_doc_str = Convert.ToString(dr["TIPO_VENTA"]) + "-001-" + Convert.ToInt32(dr["NUMERO_DOC"]).ToString().PadLeft(6, '0');
                venta.cod_tienda = Convert.ToString(dr["COD_TIENDA"]);
                venta.des_tienda = Convert.ToString(dr["DES_TIENDA"]);
                venta.tipo_venta = Convert.ToString(dr["TIPO_VENTA"]);
                venta.tipo_venta_des = Convert.ToString(dr["TIPO_VENTA_DES"]);
                venta.forma_pago = Convert.ToString(dr["FORMA_PAGO"]);
                venta.forma_pago_des = Convert.ToString(dr["FORMA_PAGO_DES"]);
                venta.emision = Convert.ToString(dr["FECHA_EMISION"]);
                venta.cantidad = Convert.ToInt32(dr["CANTIDAD"]);
                venta.monto_total = Convert.ToDouble(dr["MONTO_TOTAL"]);
                venta.monto_recibido = Convert.ToDouble(dr["MONTO_RECIBIDO"]);
                venta.monto_vuelto = Convert.ToDouble(dr["MONTO_VUELTO"]);
                venta.cliente_doc = Convert.ToString(dr["CLIENTE_DOC"]);
                venta.cliente = Convert.ToString(dr["CLIENTE_DES"]);
                venta.usuario = Convert.ToString(dr["USUARIO"]);

                lstVenta.Add(venta);
            }

            con.Close();

            return lstVenta;
        }

        public static List<Ent_Productos> getDetalleVenta(string id)
        {
            List<Ent_Productos> lstProducto = new List<Ent_Productos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_DETALLE_VENTA";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID_CAB", id);
            cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Productos producto = new Ent_Productos();
                producto.id = Convert.ToInt32(dr["ID_PRODUCTO"]);
                producto.nombre = Convert.ToString(dr["DESC_PRODUCTO"]);
                producto.cantidad = Convert.ToInt32(dr["CANTIDAD"]);
                producto.precio = Convert.ToDouble(dr["PRECIO_UNIT"]);
                producto.monto_total = Convert.ToDouble(dr["MONTO_TOTAL"]);

                lstProducto.Add(producto);
            }

            con.Close();

            return lstProducto;
        }

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

                cmd.Parameters.AddWithValue("@RETID", MySqlDbType.VarChar);
                cmd.Parameters["@RETID"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_NUMERO_DOC", cabecera.nro_doc);
                cmd.Parameters["@PSTR_NUMERO_DOC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_COD_TIENDA", cabecera.cod_tienda);
                cmd.Parameters["@PSTR_COD_TIENDA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", cabecera.tipo_venta);
                cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_FORMA_PAGO", cabecera.forma_pago);
                cmd.Parameters["@PSTR_FORMA_PAGO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CANTIDAD", cabecera.cantidad);
                cmd.Parameters["@PSTR_CANTIDAD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_TOTAL", double.Parse(cabecera.monto_total.ToString("#.##")));
                cmd.Parameters["@PSTR_MONTO_TOTAL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_RECIBIDO", cabecera.monto_recibido);
                cmd.Parameters["@PSTR_MONTO_RECIBIDO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO_VUELTO", cabecera.monto_vuelto);
                cmd.Parameters["@PSTR_MONTO_VUELTO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_CLIENTE", cabecera.cliente_doc);
                cmd.Parameters["@PSTR_CLIENTE"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", cabecera.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                retval = cmd.Parameters["@RETVAL"].Value.ToString();
                string id_cab = cmd.Parameters["@RETID"].Value.ToString();

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

                        cmd.Parameters.AddWithValue("@PSTR_ID_CAB", id_cab);
                        cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

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

        public static string anularVenta(Ent_Anular anular)
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

                cmd.CommandText = "SP_SYS_ANULAR_VENTA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_TIENDA_COD", anular.tienda_cod);
                cmd.Parameters["@PSTR_TIENDA_COD"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ID_CAB", anular.id_cab);
                cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", anular.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MOTIVO", anular.motivo);
                cmd.Parameters["@PSTR_MOTIVO"].Direction = ParameterDirection.Input;

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

        public static List<Ent_FormaPago> getFormaPago()
        {
            List<Ent_FormaPago> lstFormaPago = new List<Ent_FormaPago>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_FORMA_PAGO";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_FormaPago formapago = new Ent_FormaPago();
                formapago.codigo = Convert.ToString(dr["COD_FORMA_PAGO"]);
                formapago.descripcion = Convert.ToString(dr["DES_FORMA_PAGO"]);

                lstFormaPago.Add(formapago);
            }

            con.Close();

            return lstFormaPago;
        }

        public static List<Ent_TipoMoneda> getTipoMoneda()
        {
            List<Ent_TipoMoneda> lstTipoMoneda = new List<Ent_TipoMoneda>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_GET_TIPO_MONEDA";
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_TipoMoneda tipomoneda = new Ent_TipoMoneda();
                tipomoneda.id = Convert.ToString(dr["ID"]);
                tipomoneda.descripcion = Convert.ToString(dr["DESCRIPCION"]) + " (" + Convert.ToString(dr["SIMBOLO"]) + ")";
                tipomoneda.simbolo = Convert.ToString(dr["SIMBOLO"]);
                tipomoneda.tipo_cambio = Convert.ToDouble(dr["TIPO_CAMBIO"]);

                lstTipoMoneda.Add(tipomoneda);
            }

            con.Close();

            return lstTipoMoneda;
        }

        public static Ent_Venta getVentaCredito(int nro_doc, string cod_tienda, string tipo_venta, string fecha)
        {
            Ent_Venta venta = new Ent_Venta();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_VENTAS_CREDITO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", nro_doc);
            cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_COD_TIENDA", cod_tienda);
            cmd.Parameters["@PSTR_COD_TIENDA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_TIPO_VENTA", tipo_venta);
            cmd.Parameters["@PSTR_TIPO_VENTA"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_FECHA", fecha);
            cmd.Parameters["@PSTR_FECHA"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                venta.id_cab = Convert.ToInt32(dr["ID"]);
                venta.nro_doc = Convert.ToInt32(dr["NUMERO_DOC"]);
                venta.nro_doc_str = "001-" + Convert.ToInt32(dr["NUMERO_DOC"]).ToString().PadLeft(6, '0');
                venta.cod_tienda = Convert.ToString(dr["COD_TIENDA"]);
                venta.des_tienda = Convert.ToString(dr["DES_TIENDA"]);
                venta.tipo_venta = Convert.ToString(dr["TIPO_VENTA"]);
                venta.tipo_venta_des = Convert.ToString(dr["TIPO_VENTA_DES"]);
                venta.forma_pago = Convert.ToString(dr["FORMA_PAGO"]);
                venta.forma_pago_des = Convert.ToString(dr["FORMA_PAGO_DES"]);
                venta.emision = Convert.ToString(dr["FECHA_EMISION"]);
                venta.cantidad = Convert.ToInt32(dr["CANTIDAD"]);
                venta.monto_total = Convert.ToDouble(dr["MONTO_TOTAL"]);
                venta.monto_recibido = Convert.ToDouble(dr["MONTO_RECIBIDO"]);
                venta.monto_vuelto = Convert.ToDouble(dr["MONTO_VUELTO"]);
                venta.cliente_doc = Convert.ToString(dr["CLIENTE_DOC"]);
                venta.cliente = Convert.ToString(dr["CLIENTE_DES"]);
                venta.usuario = Convert.ToString(dr["USUARIO"]);
                venta.email = Convert.ToString(dr["EMAIL"]);
                venta.telefono = Convert.ToString(dr["TELEFONO"]);
                venta.direccion = Convert.ToString(dr["DIRECCION"]);
                venta.estado_credito = Convert.ToString(dr["ESTADO_CREDITO"]);
            }

            con.Close();

            return venta;
        }

        public static List<Ent_Abonos> getAbonos(Ent_Abonos abono)
        {
            List<Ent_Abonos> lstAbonos = new List<Ent_Abonos>();

            con = Conexion.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SP_SYS_GET_ABONOS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PSTR_ID_CAB", abono.id);
            cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

            cmd.Parameters.AddWithValue("@PSTR_NRO_DOC", abono.id_cab);
            cmd.Parameters["@PSTR_NRO_DOC"].Direction = ParameterDirection.Input;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ent_Abonos abonos = new Ent_Abonos();
                abonos.id = Convert.ToInt32(dr["ID"]);
                abonos.id_cab = Convert.ToInt32(dr["ID_CAB"]);
                abonos.nro_doc = Convert.ToInt32(dr["NRO_DOCUMENTO"]);
                abonos.codigo = "AB" + abonos.id.ToString("000000");
                abonos.cod_tienda = Convert.ToString(dr["COD_TIENDA"]);
                abonos.fecha_reg = Convert.ToString(dr["FECHA_REG"]);
                abonos.usuario = Convert.ToString(dr["USUARIO"]);
                abonos.monto = Convert.ToDouble(dr["MONTO"]);

                lstAbonos.Add(abonos);
            }

            con.Close();

            return lstAbonos;
        }

        public static string setAbono(Ent_Abonos entity)
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

                cmd.CommandText = "SP_SYS_SET_ABONO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID", entity.id);
                cmd.Parameters["@PSTR_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_ID_CAB", entity.id_cab);
                cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_COD_TIENDA", entity.cod_tienda);
                cmd.Parameters["@PSTR_COD_TIENDA"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_USUARIO", entity.usuario);
                cmd.Parameters["@PSTR_USUARIO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@PSTR_MONTO", entity.monto.ToString("#.00"));
                cmd.Parameters["@PSTR_MONTO"].Direction = ParameterDirection.Input;

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

        public static string finalizarCredito(int id)
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

                cmd.CommandText = "SP_SYS_FINALIZAR_CREDITO";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RETVAL", MySqlDbType.VarChar);
                cmd.Parameters["@RETVAL"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PSTR_ID_CAB", id);
                cmd.Parameters["@PSTR_ID_CAB"].Direction = ParameterDirection.Input;

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
