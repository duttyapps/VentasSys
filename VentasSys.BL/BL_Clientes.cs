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

        public static List<Ent_Clientes> getClientesRegistrados(string dni, string nombre)
        {
            return DAO_Clientes.getClientesRegistrados(dni, nombre);
        }

        public static bool existeCliente(string dni)
        {
            return DAO_Clientes.existeCliente(dni);
        }

        public static string insertarCliente(Ent_Clientes cliente)
        {
            return DAO_Clientes.insertarCliente(cliente);
        }

        public static string editarCliente(Ent_Clientes cliente)
        {
            return DAO_Clientes.editarCliente(cliente);
        }

        public static string eliminarCliente(string id)
        {
            return DAO_Clientes.eliminarCliente(id);
        }
    }
}
