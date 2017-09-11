using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Clientes
    {
        public static List<Ent_Clientes> getClientesxNombre(string nombre, string tipo)
        {
            return DAO_Clientes.getClientesxNombre(nombre, tipo);
        }

        public static List<Ent_Clientes> getClientesxDNI(string dni, string tipo)
        {
            return DAO_Clientes.getClientesxDNI(dni, tipo);
        }

        public static bool existeCliente(string dni)
        {
            return DAO_Clientes.existeCliente(dni);
        }
    }
}
