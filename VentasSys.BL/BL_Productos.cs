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

        public static int getStockProducto(int id_prod)
        {
            return DAO_Productos.getStockProducto(id_prod);
        }

        public static string insertarProducto(Ent_Productos producto)
        {
            return DAO_Productos.insertarProducto(producto);
        }
    }
}
