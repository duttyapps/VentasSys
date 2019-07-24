using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public class BL_Almacen
    {

        public static List<Ent_AlmacenProd> getProducto_Almacen(string codigo, string nombre)
        {
            return DAO_Almacen.getProducto_Almacen(codigo, nombre);
        }
    }
}
