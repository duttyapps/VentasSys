using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasSys.EL
{
    public class Ent_Mantenimiento
    {
        public int id { get; set; }
        public string num_doc { get; set; }
        public string tienda { get; set; }
        public string tipo_persona { get; set; }
        public string cliente_doc { get; set; }
        public string cliente { get; set; }
        public string usuario { get; set; }
        public string fecha_registro { get; set; }
        public string estado { get; set; }
        public string fecha_salida { get; set; }
        public string direccion { get; set; }

        public List<Ent_Tipo_Mantenimiento> lista_tipo { get; set; }


        public Ent_Mantenimiento()
        {
            id = 0;
            num_doc = string.Empty;
            tienda = string.Empty;
            tipo_persona = string.Empty;
            cliente = string.Empty;
            usuario = string.Empty;
            fecha_registro = string.Empty;
            estado = string.Empty;
            fecha_salida = string.Empty;
            direccion = string.Empty;
        }
    }
}
