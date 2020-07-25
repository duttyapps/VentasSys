using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Venta
    {
        public int id { get; set; }
        public int id_cab { get; set; }
        public int nro_doc { get; set; }
        public string nro_doc_str { get; set; }
        public string cod_tienda { get; set; }
        public string des_tienda { get; set; }
        public string tipo_venta { get; set; }
        public string tipo_venta_des { get; set; }
        public string forma_pago { get; set; }
        public string forma_pago_des { get; set; }
        public string emision { get; set; }
        public int cantidad { get; set; }
        public double monto_subtotal { get; set; }
        public double monto_igv { get; set; }
        public double monto_total { get; set; }
        public double monto_recibido { get; set; }
        public double monto_vuelto { get; set; }
        public double monto_descuento { get; set; }
        public string cliente_doc { get; set; }
        public string cliente { get; set; }
        public string usuario { get; set; }
        public string usuario_tipo { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string estado_credito { get; set; }
        public string anulado { get; set; }
        public string usuario_anul { get; set; }
        public string fecha_anul { get; set; }
        public string motivo_anul { get; set; }
        public string nro_guia { get; set; }
        public string tipo_cotizacion { get; set; }
        public int dias_alquiler { get; set; }
        public string tipo_ingreso_almacen { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_fin { get; set; }
        public string denominacion { get; set; }
        public List<Ent_Productos> lstProductos { get; set; }
        public string observacion { get; set; }
        public string moneda { get; set; }

        public Ent_Venta()
        {
            this.id = 0;
            this.id_cab = 0;
            this.nro_doc = 0;
            this.nro_doc_str = String.Empty;
            this.cod_tienda = String.Empty;
            this.des_tienda = String.Empty;
            this.tipo_venta = String.Empty;
            this.tipo_venta_des = String.Empty;
            this.forma_pago = String.Empty;
            this.forma_pago_des = String.Empty;
            this.emision = String.Empty;
            this.cantidad = 0;
            this.monto_subtotal = 0D;
            this.monto_igv = 0D;
            this.monto_total = 0D;
            this.monto_recibido = 0D;
            this.monto_vuelto = 0D;
            this.monto_descuento = 0D;
            this.cliente_doc = String.Empty;
            this.cliente = String.Empty;
            this.usuario = String.Empty;
            this.usuario_tipo = String.Empty;
            this.email = String.Empty;
            this.telefono = String.Empty;
            this.direccion = String.Empty;
            this.estado_credito = String.Empty;
            this.anulado = String.Empty;
            this.usuario_anul = String.Empty;
            this.fecha_anul = String.Empty;
            this.motivo_anul = String.Empty;
            this.nro_guia = String.Empty;
            this.tipo_cotizacion = String.Empty;
            this.tipo_ingreso_almacen = String.Empty;
            this.fecha_fin = String.Empty;
            this.lstProductos = new List<Ent_Productos>();
            denominacion = string.Empty;
            this.observacion = String.Empty;
            this.moneda = String.Empty;
        }
    }
}
