using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
            fillComboTipo();
            fillMediosContacto();
        }

        private void fillComboTipo()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "N", desc = "Persona" });
            items.Add(new { id = "E", desc = "Empresa" });

            cboTipo.DataSource = items;
            cboTipo.ValueMember = "id";
            cboTipo.DisplayMember = "desc";
        }

        private void fillMediosContacto()
        {
            List<Ent_MediosContacto> items = new List<Ent_MediosContacto>();

            var medios = BL_Clientes.getMediosContacto();

            items.AddRange(medios);

            cboMedio.DataSource = items;
            cboMedio.ValueMember = "id";
            cboMedio.DisplayMember = "descripcion";
        }

        private void txtDNI_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombreDet.Text.Equals(String.Empty))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreDet.Focus();
                return;
            }

            if (txtApellidos.Text.Equals(String.Empty))
            {
                MessageBox.Show("El apellido no puede estar vacío.", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus();
                return;
            }

            if (txtDireccion.Text.Equals(String.Empty))
            {
                MessageBox.Show("La dirección no puede estar vacía.", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return;
            }

            if (txtTelefono.Text.Equals(String.Empty))
            {
                MessageBox.Show("El teléfono no puede estar vacío.", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus();
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea agregar al cliente?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.nombres = txtNombreDet.Text;
                cliente.apellidos = txtApellidos.Text;
                cliente.direccion = txtDireccion.Text;
                cliente.telefono = txtTelefono.Text;
                cliente.email = txtEmail.Text;
                cliente.tipo = cboTipo.SelectedValue.ToString();

                try
                {
                    string result = BL_Clientes.insertarCliente(cliente);

                    if (result == "1")
                    {
                        MessageBox.Show("¡Cliente agregado exitosamente!", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un error al agregar el cliente!", "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Agregar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTipo.SelectedValue.ToString().Equals("N"))
            {
                txtApellidos.ReadOnly = false;
            }
            else
            {
                txtApellidos.Text = String.Empty;
                txtApellidos.ReadOnly = true;
            }
        }

        private void cboMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMedio.SelectedValue.ToString().Equals("5"))
            {
                txtRecomendado.Visible = true;
                txtRecomendado.Text = String.Empty;
                txtRecomendado.Enabled = true;
            } else
            {
                txtRecomendado.Visible = false;
                txtRecomendado.Text = String.Empty;
                txtRecomendado.Enabled = false;
            }
        }
    }
}
