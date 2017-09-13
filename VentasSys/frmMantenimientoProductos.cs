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
    public partial class frmMantenimientoProductos : Form
    {
        private string cod_tienda { get; set; }
        public frmMantenimientoProductos(string _cod_tienda)
        {
            cod_tienda = _cod_tienda;
            InitializeComponent();
            fillCategorias();
            fillTiendas();
            fillProductos();
            fillComboEstados();
        }

        private void fillTiendas()
        {
            List<Ent_Tienda> items = new List<Ent_Tienda>();

            items.Add(new Ent_Tienda { cod_tienda = "", des_tienda = "Todas las Tiendas" });

            var tiendas = BL_Tienda.getTiendas();

            items.AddRange(tiendas);

            cboTienda.DataSource = items;
            cboTienda.ValueMember = "cod_tienda";
            cboTienda.DisplayMember = "des_tienda";

            List<Ent_Tienda> items_det = items.ToList();
            items_det.RemoveAt(0);
            cboTiendaDet.DataSource = items_det;
            cboTiendaDet.ValueMember = "cod_tienda";
            cboTiendaDet.DisplayMember = "des_tienda";
        }

        private void fillCategorias()
        {
            List<Ent_CategoriaProductos> items = new List<Ent_CategoriaProductos>();

            items.Add(new Ent_CategoriaProductos { id = "", nombre = "Todos los Productos" });

            var categorias = BL_CategoriaProductos.getCategorias();

            items.AddRange(categorias);

            cboCategoria.DataSource = items;
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "nombre";

            List<Ent_CategoriaProductos> det_items = items.ToList();
            det_items.RemoveAt(0);
            cboCategoriaDet.DataSource = det_items;
            cboCategoriaDet.ValueMember = "id";
            cboCategoriaDet.DisplayMember = "nombre";
        }

        private void fillProductos()
        {
            reiniciarValores();

            string nombre = txtProducto.Text;
            string cat = cboCategoria.SelectedValue.ToString();
            string tienda = cboTienda.SelectedValue.ToString();

            dgvProductos.AutoGenerateColumns = false;

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows.Clear();
            }

            List<Ent_Productos> lstProductos = BL_Productos.getProductos(nombre, cat, tienda);

            var bindingList = new BindingList<Ent_Productos>(lstProductos);
            var source = new BindingSource(bindingList, null);

            dgvProductos.DataSource = source;

            //formating...
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "f";
        }

        private void fillComboEstados()
        {
            List<Object> items = new List<Object>();
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

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.Items.Count > 0 && cboTienda.Items.Count > 0)
            {
                fillProductos();
            }
        }

        private void cboTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.Items.Count > 0 && cboTienda.Items.Count > 0)
            {
                fillProductos();
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            fillProductos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarDetalles(Ent_Productos producto)
        {
            txtCodigo.Text = BL_Productos.generarCodigoProducto(producto.cod_tienda, producto.id, producto.id_cat);
            txtFecha.Text = producto.fecha_registro.Split(' ')[0];
            txtProductoDet.Text = producto.nombre;
            txtCantidad.Text = producto.stock.ToString();
            cboCategoriaDet.SelectedValue = producto.id_cat.ToString();
            cboProveedor.SelectedValue = producto.proveedor;
            cboTiendaDet.SelectedValue = producto.cod_tienda;
            cboEstadoDet.SelectedValue = producto.activo;
            txtCosto.Text = producto.costo.ToString("#0.00");
            txtPrecio.Text = producto.precio.ToString("#0.00");
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = dgvProductos.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string tienda = dgvProductos.Rows[e.RowIndex].Cells["COD_TIENDA"].Value.ToString();
                Ent_Productos prod = BL_Productos.getProducto(id, tienda);

                cargarDetalles(prod);

                habilitarBotones();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar el producto? Ya no se visualizará en futuras ventas.", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int id = int.Parse(txtCodigo.Text.Substring(4, txtCodigo.Text.Length - 4));
                string result = BL_Productos.eliminarProducto(id.ToString());

                if(result == "1")
                {
                    MessageBox.Show("¡Producto eliminado con éxito!.", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reiniciarValores();
                } else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reiniciarValores()
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;

            txtCodigo.Text = String.Empty;
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtProductoDet.Text = String.Empty;
            txtCantidad.Text = "0";
            txtCosto.Text = "0.00";
            txtPrecio.Text = "0.00";
        }

        private void habilitarBotones()
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
