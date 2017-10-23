using System;

namespace VentasSys.EL
{
    public class Ent_Usuario
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string rango { get; set; }
        public string rango_des { get; set; }
        public string nombres { get; set; }
        public string dni { get; set; }
        public string fecha_reg { get; set; }
        public string fecha_nac { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

        public Ent_Usuario()
        {
            this.id = String.Empty;
            this.codigo = String.Empty;
            this.username = String.Empty;
            this.password = String.Empty;
            this.rango = String.Empty;
            this.rango_des = String.Empty;
            this.nombres = String.Empty;
            this.dni = String.Empty;
            this.fecha_reg = String.Empty;
            this.fecha_nac = String.Empty;
            this.sexo = String.Empty;
            this.email = String.Empty;
            this.telefono = String.Empty;
        }
    }
}
