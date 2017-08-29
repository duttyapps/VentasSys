using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.DAL
{
    public class Ent_Anular
    {
        public int id_cab { get; set; }
        public string tienda_cod { get; set; }
        public string usuario { get; set; }
        public string motivo { get; set; }

        public Ent_Anular()
        {
            this.id_cab = 0;
            this.tienda_cod = String.Empty;
            this.usuario = String.Empty;
            this.motivo = String.Empty;
        }
    }
}
