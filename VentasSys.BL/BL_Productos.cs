using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Productos
    {
        public static List<Ent_Productos> getProductos(string nombre, string cat)
        {
            return DAO_Productos.getProductos(nombre, cat);
        }
    }
}
