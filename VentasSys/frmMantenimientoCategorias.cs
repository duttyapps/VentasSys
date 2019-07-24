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
    public partial class frmMantenimientoCategorias : Form
    {
        public frmMantenimientoCategorias()
        {
            InitializeComponent();
            fillComboEstados();
            fillCategorias();
        }

        private void fillComboEstados()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = String.Empty, desc = "Seleccionar" });
            items.Add(new { id = "1", desc = "Activo" });
            items.Add(new { id = "0", desc = "Inactivo" });

            cboEstado.DataSource = items;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "desc";

            List<Object> items_det = items.ToList();
            cboEstadoDet.DataSource = items_det;
            cboEstadoDet.ValueMember = "id";
            cboEstadoDet.DisplayMember = "desc";
        }

        private void fillCategorias()
        {
            string nombre = txtNombre.Text;
            string estado = (cboEstado.SelectedValue == null) ? null : cboEstado.SelectedValue.ToString();

            dgvCategorias.AutoGenerateColumns = false;

            if (dgvCategorias.Rows.Count > 0)
            {
                dgvCategorias.Rows.Clear();
            }

            List<Ent_CategoriaProductos> lstCategorias = BL_CategoriaProductos.getCategorias(nombre, estado);

            var bindingList = new BindingList<Ent_CategoriaProductos>(lstCategorias);
            var source = new BindingSource(bindingList, null);

            dgvCategorias.DataSource = source;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            fillCategorias();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCategorias();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnNuevo.Enabled = true;
                btnEliminar.Enabled = true;

                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;

                txtCategoriaDet.Enabled = false;
                cboEstadoDet.Enabled = false;

                fillDetallesCategoria(e);
            }
        }

        private void fillDetallesCategoria(DataGridViewCellEventArgs e)
        {
            txtFecha.Text = dgvCategorias.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
            txtCodigo.Text = dgvCategorias.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
            txtCategoriaDet.Text = dgvCategorias.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
            cboEstadoDet.SelectedValue = dgvCategorias.Rows[e.RowIndex].Cells["ACTIVO"].Value;
            txtID.Text = dgvCategorias.Rows[e.RowIndex].Cells["ID"].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarFormulario();
            txtCategoriaDet.Enabled = true;
            cboEstadoDet.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCodigo.Text = "-";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtCategoriaDet.Text;
            string estado = cboEstadoDet.SelectedValue.ToString();

            if (nombre.Equals(String.Empty))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoriaDet.Focus();
                return;
            }

            if (estado.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un estado.", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea registrar la nueva categegoría?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Ent_CategoriaProductos categoria = new Ent_CategoriaProductos();
                categoria.nombre = nombre;
                categoria.activo = estado;
                try
                {
                    string result = BL_CategoriaProductos.insertarCategoria(categoria);

                    if (result == "1")
                    {
                        MessageBox.Show("¡Categoría guardada exitosamente!", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillCategorias();
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un error al guardar la categoría!", "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Agregar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reiniciarFormulario()
        {
            txtCodigo.Text = String.Empty;
            txtFecha.Text = String.Empty;
            txtCategoriaDet.Text = String.Empty;
            cboEstadoDet.SelectedValue = String.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            string id = txtID.Text;

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar la categegoría seleccionada?.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {

                    string result = BL_CategoriaProductos.eliminarCategoria(id);

                    if (result == "1")
                    {
                        MessageBox.Show("¡Categoría eliminada exitosamente!", "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillCategorias();
                        reiniciarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("¡Ocurrió un error al eliminar la categoría!", "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Eliminar categoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reiniciarFormulario();
            txtCategoriaDet.Enabled = false;
            cboEstadoDet.Enabled = false;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
    }
}
