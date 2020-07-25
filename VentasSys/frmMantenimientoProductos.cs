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
        private string usuario { get; set; }
        private int id_prod_selec { get; set; }
        private string fecha_actual = DateTime.Now.ToString("dd/MM/yyyy");

        public frmMantenimientoProductos(string _cod_tienda, string _usuario)
        {
            cod_tienda = _cod_tienda;
            usuario = _usuario;
            InitializeComponent();
            fillCategorias();
            fillTiendas();
            fillComboEstados();
            fillProveedores();
            fillProductos();
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

            items_det[0] = new Ent_Tienda { cod_tienda = "", des_tienda = "Seleccione" };

            cboTiendaDet.DataSource = items_det;
            cboTiendaDet.ValueMember = "cod_tienda";
            cboTiendaDet.DisplayMember = "des_tienda";
        }

        private void fillCategorias()
        {
            List<Ent_CategoriaProductos> items = new List<Ent_CategoriaProductos>();

            items.Add(new Ent_CategoriaProductos { id = "", nombre = "Todos los Productos" });

            var categorias = BL_CategoriaProductos.getCategorias(String.Empty, "1");

            items.AddRange(categorias);

            cboCategoria.DataSource = items;
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "nombre";

            List<Ent_CategoriaProductos> det_items = items.ToList();
            det_items[0] = new Ent_CategoriaProductos { id = "", nombre = "Seleccione" };

            cboCategoriaDet.DataSource = det_items;
            cboCategoriaDet.ValueMember = "id";
            cboCategoriaDet.DisplayMember = "nombre";
        }

        private void fillProductos()
        {
            reiniciarValores();

            string nombre = txtProducto.Text;
            string codigo = txtCodigoS.Text;
            string cat = cboCategoria.SelectedValue.ToString();
            string tienda = cboTienda.SelectedValue.ToString();
            string estado = (cboEstado.SelectedValue == null) ? "1" : cboEstado.SelectedValue.ToString();

            dgvProductos.AutoGenerateColumns = false;
            
            if (tienda == "VentasSys.EL.Ent_Tienda" || cat == "VentasSys.EL.Ent_CategoriaProductos" || estado == "{ id = 1, desc = Activo }")
            {
                return;
            }

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows.Clear();
            }

            List<Ent_Productos> lstProductos = BL_Productos.getProductos(nombre, codigo, cat, tienda, estado, "0");

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

        private void fillProveedores()
        {
            List<Ent_Proveedores> items = new List<Ent_Proveedores>();

            items.Add(new Ent_Proveedores { id = "", nombre = "Seleccione" });

            var proveedores = BL_Productos.getProveedores();

            items.AddRange(proveedores);

            cboProveedor.DataSource = items;
            cboProveedor.ValueMember = "id";
            cboProveedor.DisplayMember = "nombre";
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
            id_prod_selec = producto.id;
            txtCodigo.Text = producto.cod_producto;
            txtFecha.Text = producto.fecha_registro.Split(' ')[0];
            txtProductoDet.Text = producto.nombre;
            txtCantidad.Text = producto.stock.ToString();
            cboCategoriaDet.SelectedValue = producto.id_cat.ToString();
            cboProveedor.SelectedValue = producto.proveedor;
            cboTiendaDet.SelectedValue = producto.cod_tienda;
            cboEstadoDet.SelectedValue = producto.activo;
            txtCosto.Text = producto.costo.ToString("#0.00");
            txtPrecio.Text = producto.precio.ToString("#0.00");
            chkAlquiler.Checked = producto.alquiler == "1" ? true : false;
            txtMonto_Alquiler.Text = producto.monto_alquiler.ToString("#0.00");
            txtPeso.Text = producto.peso.ToString("#0.00");
            txtMedida.Text = producto.medida.ToString("#0.00");
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
                int id = id_prod_selec;
                string result = BL_Productos.eliminarProducto(id.ToString());

                if (result == "1")
                {
                    MessageBox.Show("¡Producto eliminado con éxito!.", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reiniciarValores();
                    fillProductos();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reiniciarValores()
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            txtCodigo.Text = String.Empty;
            txtFecha.Text = fecha_actual;
            txtProductoDet.Text = String.Empty;
            txtCantidad.Text = "0";
            txtCosto.Text = "0.00";
            txtPrecio.Text = "0.00";
            txtMedida.Text = "0.00";
            txtPeso.Text = "0.00";
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtProductoDet.Text.Trim() == String.Empty)
            {
                MessageBox.Show("El nombre del producto no puede estar vacío", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtCantidad.Text.Trim() == String.Empty || int.Parse(txtCantidad.Text) < 0)
            {
                txtCantidad.Text = "0";
            }

            if(cboCategoriaDet.SelectedValue.ToString() == String.Empty)
            {
                MessageBox.Show("Debe seleccionar una categoría para el producto.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProveedor.SelectedValue.ToString() == String.Empty)
            {
                MessageBox.Show("Debe seleccionar un proveedor para el producto.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboTiendaDet.SelectedValue.ToString() == String.Empty)
            {
                MessageBox.Show("Debe seleccionar una tienda para el producto.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCosto.Text.Trim() == String.Empty || int.Parse(txtCantidad.Text) < 0)
            {
                txtCosto.Text = "0.00";
            }

            if (txtPrecio.Text.Trim() == String.Empty || int.Parse(txtCantidad.Text) < 0)
            {
                txtPrecio.Text = "0.00";
            }

            var confirm = MessageBox.Show("¿Está seguro que desea modificar el producto?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Ent_Productos prod = new Ent_Productos();

                //int id = int.Parse(txtCodigo.Text.Substring(4, txtCodigo.Text.Length - 4));
                prod.id = id_prod_selec;
                prod.cod_producto = txtCodigo.Text;
                prod.id_cat = int.Parse(cboCategoriaDet.SelectedValue.ToString());
                prod.cod_tienda = cboTiendaDet.SelectedValue.ToString();
                prod.nombre = txtProductoDet.Text;
                prod.stock = int.Parse(txtCantidad.Text);
                prod.proveedor = cboProveedor.SelectedValue.ToString();
                prod.activo = cboEstadoDet.SelectedValue.ToString();
                prod.costo = double.Parse(txtCosto.Text);
                prod.precio = double.Parse(txtPrecio.Text);
                prod.usuario = usuario;
                prod.medida = double.Parse(txtMedida.Text);
                prod.peso = double.Parse(txtPeso.Text);
                prod.alquiler = chkAlquiler.Checked ? "1" : "0";
                prod.monto_alquiler = double.Parse(txtMonto_Alquiler.Text);

                string result = BL_Productos.editarProducto(prod);

                if (result == "1")
                {
                    MessageBox.Show("¡Producto modificado con éxito!.", "Mantenimiento de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reiniciarValores();
                    fillProductos();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAgregarProducto frm = new frmAgregarProducto(cod_tienda, usuario);
            frm.ShowDialog();
            fillProductos();

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillProductos();
        }

        private void chkAlquiler_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlquiler.Checked)
            {
                chkAlquiler.Text = "Si";
                txtMonto_Alquiler.Enabled = true;
                txtMonto_Alquiler.Text = "0.00";
            }
            else
            {
                chkAlquiler.Text = "No";
                txtMonto_Alquiler.Enabled = false;
                txtMonto_Alquiler.Text = "0.00";
            }
        }

        private void txtCodigoS_TextChanged(object sender, EventArgs e)
        {
            fillProductos();
        }
    }
}
