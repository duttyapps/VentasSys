using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Clientes
    {
        public static List<Ent_Clientes> getClientesxNombre(string nombre)
        {
            return DAO_Clientes.getClientesxNombre(nombre);
        }
    }
}
