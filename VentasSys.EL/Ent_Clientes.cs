using System;

namespace VentasSys.EL
{
    public class Ent_Clientes
    {
        public string id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string apellidos_nombres { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string fecha_reg { get; set; }
        public string tipo { get; set; }
        public string posible { get; set; }
        public string recomendado { get; set; }

        public Ent_Clientes()
        {
            this.id = String.Empty;
            this.nombres = String.Empty;
            this.apellidos = String.Empty;
            this.apellidos_nombres = String.Empty;
            this.dni = String.Empty;
            this.direccion = String.Empty;
            this.telefono = String.Empty;
            this.email = String.Empty;
            this.fecha_reg = String.Empty;
            this.tipo = String.Empty;
            this.posible = String.Empty;
            this.recomendado = String.Empty;
        }
    }
}
