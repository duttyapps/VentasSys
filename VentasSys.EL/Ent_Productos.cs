using System;

namespace VentasSys.EL
{
    public class Ent_Productos
    {
        public int id { get; set; }
        public int id_cat { get; set; }
        public string nombre { get; set; }
        public double costo { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public int stock { get; set; }
        public string cod_tienda { get; set; }
        public string des_tienda { get; set; }
        public string activo { get; set; }

        public Ent_Productos()
        {
            this.id = 0;
            this.id_cat = 0;
            this.nombre = String.Empty;
            this.costo = 0D;
            this.precio = 0D;
            this.cantidad = 1;
            this.stock = 1;
            this.des_tienda = String.Empty;
            this.activo = "1";
        }
    }
}
