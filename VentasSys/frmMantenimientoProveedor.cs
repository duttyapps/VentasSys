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
    public partial class frmMantenimientoProveedor : Form
    {
        private string accion { get; set; }

        public frmMantenimientoProveedor()
        {
            InitializeComponent();
            fillProveedores();

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            lista_tipo.Add("1", "Activo");
            lista_tipo.Add("0", "Inactivo");
            cboEstado.DataSource = new BindingSource(lista_tipo, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }

        private void fillProveedores() {

            dgvProveedor.AutoGenerateColumns = false;

            if (dgvProveedor.Rows.Count > 0)
            {
                dgvProveedor.Rows.Clear();
            }

            Ent_Proveedores entity = new Ent_Proveedores();
            entity.nombre = txtNombreS.Text;


            List<Ent_Proveedores> lstProveedor = BL_Proveedores.getProveedores(entity);

            var bindingList = new BindingList<Ent_Proveedores>(lstProveedor);
            var source = new BindingSource(bindingList, null);

            dgvProveedor.DataSource = source;
        }
        
        private void limpiarDatos()
        {
            txtCodigo.Text = String.Empty;
            txtCodigo.Enabled = false;
            txtNombre.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            cboEstado.Enabled = true;
            accion = "N";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            cboEstado.Enabled = true;

            accion = "M";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDatos();

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            cboEstado.Enabled = false;
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnCancelar_Click(null, EventArgs.Empty);
                fillDatosProveedor(e);
            }
        }

        private void fillDatosProveedor(DataGridViewCellEventArgs e)
        {
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            cboEstado.Enabled = false;

            txtCodigo.Text = dgvProveedor.Rows[e.RowIndex].Cells["ID"].Value.ToString(); 
            txtCodigo.Enabled = false;
            txtNombre.Text = dgvProveedor.Rows[e.RowIndex].Cells["PROVEEDOR"].Value.ToString();
            txtTelefono.Text = dgvProveedor.Rows[e.RowIndex].Cells["TELEFONO"].Value.ToString();
            txtDireccion.Text = dgvProveedor.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
            cboEstado.SelectedValue = dgvProveedor.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (accion == "N")
            {
                Ent_Proveedores prov = new Ent_Proveedores() { id = txtCodigo.Text, nombre = txtNombre.Text, direccion = txtDireccion.Text, telefono = txtTelefono.Text, activo = cboEstado.SelectedValue.ToString() };

                string set = BL_Proveedores.setProveedores(prov);
                if (set != "1")
                {
                    MessageBox.Show(set);
                }
                else {
                    MessageBox.Show("Se agregó correctamente.");
                }
            }
            else if (accion == "M") {
                Ent_Proveedores prov = new Ent_Proveedores() { id = txtCodigo.Text, nombre = txtNombre.Text, direccion = txtDireccion.Text, telefono = txtTelefono.Text, activo = cboEstado.SelectedValue.ToString() };

                string set = BL_Proveedores.uptProveedores(prov);
                if (set != "1")
                {
                    MessageBox.Show(set);
                }
                else
                {
                    MessageBox.Show("Se actualizó correctamente.");
                }
            }
            fillProveedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Ent_Proveedores prov = new Ent_Proveedores() { id = txtCodigo.Text, nombre = txtNombre.Text, direccion = txtDireccion.Text, telefono = txtTelefono.Text, activo = cboEstado.SelectedValue.ToString() };

            string set = BL_Proveedores.delProveedores(prov);
            if (set != "1")
            {
                MessageBox.Show(set);
            }
            else
            {
                MessageBox.Show("Se eliminó correctamente.");
            }
            fillProveedores();
            limpiarDatos();
        }
    }
}
