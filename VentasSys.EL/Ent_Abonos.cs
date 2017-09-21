using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Abonos
    {
        public int id { get; set; }
        public int id_cab { get; set; }
        public int nro_doc { get; set; }
        public string codigo { get; set; }
        public string cod_tienda { get; set; }
        public string fecha_reg { get; set; }
        public string usuario { get; set; }
        public double monto { get; set; }

        public Ent_Abonos()
        {
            this.id = 0;
            this.id_cab = 0;
            this.nro_doc = 0;
            this.codigo = String.Empty;
            this.cod_tienda = String.Empty;
            this.fecha_reg = String.Empty;
            this.usuario = String.Empty;
            this.monto = 0D;
        }
    }
}
