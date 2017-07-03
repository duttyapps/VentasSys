using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Configuracion
    {
        public static Ent_Configuracion getConfiguracion()
        {
            return DAO_Configuracion.getConfiguracion();
        }
    }
}
