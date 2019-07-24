using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_MediosContacto
    {
        public string id { get; set; }
        public string descripcion { get; set; }

        public Ent_MediosContacto()
        {
            this.id = String.Empty;
            this.descripcion = String.Empty;
        }
    }
}
