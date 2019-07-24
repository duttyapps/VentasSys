using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public class BL_Proveedores
    {
        public static List<Ent_Proveedores> getProveedores(Ent_Proveedores entity)
        {
            return DAO_Proveedores.getProveedores(entity);
        }

        public static List<Ent_PagosProveedores> getPagos(string fecha)
        {
            return DAO_Proveedores.getPagos(fecha);
        }

        public static string registrarPago(Ent_PagosProveedores ent)
        {
            return DAO_Proveedores.registrarPago(ent);
        }

        public static string setProveedores(Ent_Proveedores ent)
        {
            return DAO_Proveedores.setProveedores(ent);
        }

        public static string uptProveedores(Ent_Proveedores ent)
        {
            return DAO_Proveedores.uptProveedores(ent);
        }

        public static string delProveedores(Ent_Proveedores ent)
        {
            return DAO_Proveedores.delProveedores(ent);
        }
    }
}
