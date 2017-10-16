using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmAgregarProducto : Form
    {
        private string cod_tienda { get; set; }
        private string usuario { get; set; }

        public frmAgregarProducto(string _cod_tienda, string _usuario)
        {
            cod_tienda = _cod_tienda;
            usuario = _usuario;
            InitializeComponent();
            fillCategorias();
        }

        public void fillCategorias()
        {
            List<Ent_CategoriaProductos> items = new List<Ent_CategoriaProductos>();

            var categorias = BL_CategoriaProductos.getCategorias(null, "1");

            items.AddRange(categorias);

            cboCategoria.DataSource = items;
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCosto.Text == String.Empty)
            {
                txtCosto.Text = "0";
            }
            else if (txtPrecio.Text == String.Empty)
            {
                txtPrecio.Text = "0";
            }
            else if (txtStock.Text == String.Empty)
            {
                txtStock.Text = "0";
            }

            Ent_Productos producto = new Ent_Productos();
            producto.nombre = txtNombre.Text;
            producto.id_cat = int.Parse(cboCategoria.SelectedValue.ToString());
            producto.costo = double.Parse(txtCosto.Text);
            producto.precio = double.Parse(txtPrecio.Text);
            producto.stock = int.Parse(txtStock.Text);
            producto.usuario = usuario;
            producto.activo = chkActivo.Checked ? "1" : "0";

            if (producto.nombre == String.Empty)
            {
                MessageBox.Show("El nombre no puede estar vacío", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            else if (producto.costo == 0)
            {
                MessageBox.Show("El costo no puede ser menor o igual a 0.00", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCosto.Focus();
                return;
            }
            else if (producto.precio == 0)
            {
                MessageBox.Show("El precio no puede ser menor o igual a 0.00", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }

            guardarProducto(producto);
        }

        public void guardarProducto(Ent_Productos producto)
        {
            try
            {
                string result = BL_Productos.insertarProducto(producto, cod_tienda);

                if (result == "1")
                {
                    MessageBox.Show("¡Producto guardado exitosamente!", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("¡Ocurrió un error al guardar el producto!", "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void limpiarFormulario()
        {
            txtNombre.Text = String.Empty;
            txtCosto.Text = "0.00";
            txtPrecio.Text = "0.00";
            txtStock.Text = "0";
        }
    }
}
