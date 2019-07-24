using System;

namespace VentasSys.EL
{
    public class Ent_Motivos
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public Ent_Motivos()
        {
            this.codigo = String.Empty;
            this.descripcion = String.Empty;
        }
    }
}
