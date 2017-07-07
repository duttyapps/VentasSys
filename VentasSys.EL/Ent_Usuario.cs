using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Usuario
    {
        public String username { get; set; }
        public String password { get; set; }
        public String rango { get; set; }
        public String nombres { get; set; }

        public Ent_Usuario()
        {
            this.username = String.Empty;
            this.password = String.Empty;
            this.rango = "0";
            this.nombres = String.Empty;
        }
    }
}
