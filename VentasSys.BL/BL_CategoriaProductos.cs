using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_CategoriaProductos
    {
        public static List<Ent_CategoriaProductos> getCategorias(string categoria = null, string activo = null)
        {
            return DAO_CategoriaProductos.getCategorias(categoria, activo);
        }

        public static string insertarCategoria(Ent_CategoriaProductos categoria)
        {
            return DAO_CategoriaProductos.insertarCategoria(categoria);
        }

        public static string editarCategoria(Ent_CategoriaProductos categoria)
        {
            return DAO_CategoriaProductos.editarCategoria(categoria);
        }

        public static string eliminarCategoria(string id)
        {
            return DAO_CategoriaProductos.eliminarCategoria(id);
        }
    }
}
