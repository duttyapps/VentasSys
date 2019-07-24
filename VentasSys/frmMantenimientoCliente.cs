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
    public partial class frmMantenimientoCliente : Form
    {
        public frmMantenimientoCliente()
        {
            InitializeComponent();
            fillComboTipo();
            fillClientes();
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

        private void fillClientes()
        {
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;

            dgvClientes.AutoGenerateColumns = false;

            if (dgvClientes.Rows.Count > 0)
            {
                dgvClientes.Rows.Clear();
            }

            List<Ent_Clientes> lstClientes = BL_Clientes.getClientesRegistrados(dni, nombre);

            var bindingList = new BindingList<Ent_Clientes>(lstClientes);
            var source = new BindingSource(bindingList, null);

            dgvClientes.DataSource = source;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;

                txtFecha.Enabled = false;
                txtDNIDet.Enabled = false;
                txtNombreDet.Enabled = false;
                txtApellidos.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                txtEmail.Enabled = false;

                fillDetallesClientes(e);
            }
        }

        private void fillDetallesClientes(DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvClientes.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtFecha.Text = dgvClientes.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
            cboTipo.SelectedValue = dgvClientes.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();
            txtDNIDet.Text = dgvClientes.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            txtNombreDet.Text = dgvClientes.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            txtApellidos.Text = dgvClientes.Rows[e.RowIndex].Cells["APELLIDOS"].Value.ToString();
            txtDireccion.Text = dgvClientes.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
            txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["TELEFONO"].Value.ToString();
            txtEmail.Text = dgvClientes.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            cboTipo.Enabled = true;
            txtNombreDet.Enabled = true;
            txtApellidos.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            fillClientes();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            fillClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar el cliente: " + txtDNIDet.Text + " - " + txtNombreDet.Text + " " + txtApellidos.Text + "?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string id = txtID.Text;
                try
                {
                    string result = BL_Clientes.eliminarCliente(id);

                    if (result == "1")
                    {
                        MessageBox.Show("¡Cliente eliminado exitosamente!", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillClientes();
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un error al eliminar el cliente!", "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreDet.Text.Equals(String.Empty))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreDet.Focus();
                return;
            }

            if (txtApellidos.Text.Equals(String.Empty))
            {
                MessageBox.Show("El apellido no puede estar vacío.", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus();
                return;
            }

            if (txtDireccion.Text.Equals(String.Empty))
            {
                MessageBox.Show("La dirección no puede estar vacía.", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return;
            }

            if (txtTelefono.Text.Equals(String.Empty))
            {
                MessageBox.Show("El teléfono no puede estar vacío.", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus();
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea modificar el cliente?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Ent_Clientes cliente = new Ent_Clientes();
                cliente.id = txtID.Text;
                cliente.nombres = txtNombreDet.Text;
                cliente.apellidos = txtApellidos.Text;
                cliente.direccion = txtDireccion.Text;
                cliente.telefono = txtTelefono.Text;
                cliente.email = txtEmail.Text;
                cliente.tipo = cboTipo.SelectedValue.ToString();

                try
                {
                    string result = BL_Clientes.editarCliente(cliente);

                    if (result == "1")
                    {
                        MessageBox.Show("¡Cliente modificado exitosamente!", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillClientes();
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un error al modificar el cliente!", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
