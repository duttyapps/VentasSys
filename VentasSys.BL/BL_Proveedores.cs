using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public class BL_Proveedores
    {
        public static List<Ent_Proveedores> getProveedores()
        {
            return DAO_Proveedores.getProveedores();
        }
    }
}
