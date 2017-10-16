using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Depositos
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public int id_banco { get; set; }
        public string banco { get; set; }
        public string fecha_emision { get; set; }
        public string usuario { get; set; }
        public double monto { get; set; }
        public string fecha_hora { get; set; }

        public Ent_Depositos()
        {
            this.id = 0;
            this.codigo = String.Empty;
            this.id_banco = 0;
            this.banco = String.Empty;
            this.fecha_emision = String.Empty;
            this.usuario = String.Empty;
            this.monto = 0D;
            this.fecha_hora = String.Empty;
        }
    }
}
