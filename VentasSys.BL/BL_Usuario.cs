using VentasSys.DAL;
using VentasSys.EL;

namespace VentasSys.BL
{
    public static class BL_Usuario
    {
        public static Ent_Usuario login(Ent_Usuario ent)
        {
            Ent_Usuario usuario = new Ent_Usuario();
            usuario = DAO_Usuario.login(ent);
            return usuario;
        }
    }
}
