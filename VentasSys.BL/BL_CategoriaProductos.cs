using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_CategoriaProductos
    {
        public static List<Ent_CategoriaProductos> getCategorias()
        {
            return DAO_CategoriaProductos.getCategorias();
        }
    }
}
