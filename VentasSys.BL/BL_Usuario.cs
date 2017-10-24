using System.Collections.Generic;
using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Usuario
    {
        public static Ent_Usuario login(Ent_Usuario ent)
        {
            return DAO_Usuario.login(ent);
        }

        public static List<Ent_Usuario> getUsuarios(Ent_Usuario ent)
        {
            return DAO_Usuario.getUsuarios(ent);
        }

        public static Ent_Usuario getUsuario(string id)
        {
            return DAO_Usuario.getUsuario(id);
        }

        public static string insertarUsuario(Ent_Usuario usuario)
        {
            return DAO_Usuario.insertarUsuario(usuario);
        }

        public static string editarUsuario(Ent_Usuario usuario)
        {
            return DAO_Usuario.editarUsuario(usuario);
        }

        public static string eliminarUsuario(string id)
        {
            return DAO_Usuario.eliminarUsuario(id);
        }

        public static string restablecerContraseña(string id, string pass)
        {
            return DAO_Usuario.restablecerContraseña(id, pass);
        }
    }
}
