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

        public static List<Ent_PagosProveedores> getPagos(string fecha)
        {
            return DAO_Proveedores.getPagos(fecha);
        }

        public static string registrarPago(Ent_PagosProveedores ent)
        {
            return DAO_Proveedores.registrarPago(ent);
        }
    }
}
