using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Venta
    {
        public int nro_doc { get; set; }
        public string tipo_venta { get; set; }
        public string forma_pago { get; set; }
        public string emision { get; set; }
        public int cantidad { get; set; }
        public double monto_total { get; set; }
        public double monto_recibo { get; set; }
        public double monto_vuelto { get; set; }
        public string cliente_doc { get; set; }
        public string usuario { get; set; }
        public List<Ent_Productos> lstProductos { get; set; }

        public Ent_Venta()
        {
            this.nro_doc = 0;
            this.tipo_venta = String.Empty;
            this.forma_pago = String.Empty;
            this.emision = String.Empty;
            this.cantidad = 0;
            this.monto_total = 0D;
            this.monto_recibo = 0D;
            this.monto_vuelto = 0D;
            this.cliente_doc = String.Empty;
            this.usuario = String.Empty;
            this.lstProductos = new List<Ent_Productos>();
        }
    }
}
