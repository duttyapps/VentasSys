using System;

namespace VentasSys.EL
{
    public class Ent_PagosProveedores
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public int id_proveedor { get; set; }
        public string proveedor { get; set; }
        public string fecha_emision { get; set; }
        public int nro_factura { get; set; }
        public string usuario { get; set; }
        public double monto { get; set; }
        public string fecha_hora { get; set; }

        public Ent_PagosProveedores()
        {
            this.id = 0;
            this.codigo = String.Empty;
            this.id_proveedor = 0;
            this.proveedor = String.Empty;
            this.fecha_emision = String.Empty;
            this.nro_factura = 0;
            this.usuario = String.Empty;
            this.monto = 0D;
            this.fecha_hora = String.Empty;
        }
    }
}
