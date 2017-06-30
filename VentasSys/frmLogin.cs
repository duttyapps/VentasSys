using System;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmLogin : Form
    {
        private Log log = new Log();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Ent_Usuario ent_usuario = new Ent_Usuario();

            ent_usuario.username = txtUser.Text;
            ent_usuario.password = txtPass.Text;

            ent_usuario = BL_Usuario.login(ent_usuario);

            if(ent_usuario.nombres != String.Empty)
            {
                log.Info("Login usuario " + ent_usuario.username + " correcto.", System.Reflection.MethodBase.GetCurrentMethod().Name);
            } else
            {
                log.Error("Login usuario " + ent_usuario.username + " incorrecto.", System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Contraseña o usuaro incorrecto.");
                txtUser.Focus();
            }
        }
    }
}
