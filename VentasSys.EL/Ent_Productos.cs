using System;

namespace VentasSys.EL
{
    public class Ent_Productos
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public int id_cat { get; set; }
        public string categoria_des { get; set; }
        public string nombre { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
        public double monto_total { get; set; }
        public int cantidad { get; set; }
        public int stock { get; set; }
        public string cod_tienda { get; set; }
        public string des_tienda { get; set; }
        public string usuario { get; set; }
        public string fecha_registro { get; set; }
        public string proveedor { get; set; }
        public string activo { get; set; }
        public double medida { get; set; }
        public double peso { get; set; }
        public string cod_producto { get; set; }
        public string alquiler { get; set; }
        public double monto_alquiler { get; set; }

        public Ent_Productos()
        {
            this.id = 0;
            this.codigo = String.Empty;
            this.id_cat = 0;
            this.categoria_des = String.Empty;
            this.nombre = String.Empty;
            this.costo = 0D;
            this.precio = 0D;
            this.monto_total = 0D;
            this.cantidad = 1;
            this.stock = 1;
            this.des_tienda = String.Empty;
            this.usuario = String.Empty;
            this.fecha_registro = String.Empty;
            this.proveedor = String.Empty;
            this.activo = "1";
            this.medida = 0D;
            this.peso = 0D;
            this.cod_producto = String.Empty;
            this.alquiler = "1";
            this.monto_alquiler = 0D;
        }
    }
}
