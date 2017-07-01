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
            doCancel();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                doLogin();
            else if (e.KeyChar == (char)27)
                doCancel();
        }

        private void doLogin()
        {
            Ent_Usuario ent_usuario = new Ent_Usuario();

            ent_usuario.username = txtUser.Text;
            ent_usuario.password = txtPass.Text;

            if(txtUser.Text == String.Empty)
            {
                txtUser.BackColor = System.Drawing.Color.Yellow;
                txtUser.Focus();
                return;
            }

            if (txtPass.Text == String.Empty)
            {
                txtPass.BackColor = System.Drawing.Color.Yellow;
                txtPass.Focus();
                return;
            }

            ent_usuario = BL_Usuario.login(ent_usuario);

            if (ent_usuario.nombres != String.Empty)
            {
                log.Info("Login usuario " + ent_usuario.username + " correcto.", System.Reflection.MethodBase.GetCurrentMethod().Name);

                frmPrincipal frm = new frmPrincipal(ent_usuario);
                this.Close();
                frm.Show();
            }
            else
            {
                log.Error("Login usuario " + ent_usuario.username + " incorrecto.", System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Contraseña o usuaro incorrecto.");
                txtUser.Focus();
            }
        }

        private void doCancel()
        {
            Application.Exit();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if(txtUser.BackColor == System.Drawing.Color.Yellow)
            {
                txtUser.BackColor = System.Drawing.Color.White;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.BackColor == System.Drawing.Color.Yellow)
            {
                txtPass.BackColor = System.Drawing.Color.White;
            }
        }
    }
}
