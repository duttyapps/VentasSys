using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Tienda
    {
        public static List<Ent_Tienda> getTiendas()
        {
            return DAO_Tienda.getTiendas();
        }

        public static Ent_Tienda getTienda(string codigo)
        {
            return DAO_Tienda.getTienda(codigo);
        }
    }
}
