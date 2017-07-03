using System;
using System.Windows.Forms;
using VentasSys.Utils;

namespace VentasSys.Sistema.Base_de_Datos
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
            cargarDatosDB();
        }

        private void cargarDatosDB()
        {
            txtIP.Text = IniFile.IniReadValue("DATABASE", "IP");
            txtUser.Text = IniFile.IniReadValue("DATABASE", "USER");
            txtPass.Text = IniFile.IniReadValue("DATABASE", "PASS");
            txtDB.Text = IniFile.IniReadValue("DATABASE", "DB");
        }

        private void guardarDatosDB()
        {
            IniFile.IniWriteValue("DATABASE", "IP", txtIP.Text);
            IniFile.IniWriteValue("DATABASE", "USER", txtUser.Text);
            IniFile.IniWriteValue("DATABASE", "PASS", txtPass.Text);
            IniFile.IniWriteValue("DATABASE", "DB", txtDB.Text);
        }

        private void btnProbar_Click(object sender, System.EventArgs e)
        {
            string test = Conexion.tryConnection(txtIP.Text, txtUser.Text, txtPass.Text, txtDB.Text);

            if(test == "0")
            {
                MessageBox.Show("Conexión realizada con éxito");
            } else
            {
                MessageBox.Show("Ocurrió un error al conectar\n" + test);
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            var confirm = MessageBox.Show("¡Atención!\nPara realizar los cambios se debe reiniciar el programa.\nHaga click en Aceptar para reiniciar, Cancelar para no realizar los cambios.", "Advertencia", MessageBoxButtons.OKCancel);

            if(confirm == DialogResult.OK)
            {
                try
                {
                    guardarDatosDB();
                    Application.Restart();
                    Environment.Exit(0);
                } catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            
        }
    }
}
