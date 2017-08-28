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
        }

        public void fillTiendas()
        {
            List<Ent_Tienda> items = new List<Ent_Tienda>();

            items.Add(new Ent_Tienda { cod_tienda = "", des_tienda = "Todas las Tiendas" });

            var tiendas = BL_Tienda.getTiendas();

            items.AddRange(tiendas);

            cboTienda.DataSource = items;
            cboTienda.ValueMember = "cod_tienda";
            cboTienda.DisplayMember = "des_tienda";
        }

        public void fillCategorias()
        {
            List<Ent_CategoriaProductos> items = new List<Ent_CategoriaProductos>();

            items.Add(new Ent_CategoriaProductos { id = "", nombre = "Todos los Productos" });

            var categorias = BL_CategoriaProductos.getCategorias();

            items.AddRange(categorias);

            cboCategoria.DataSource = items;
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "nombre";
        }

        public void fillProductos()
        {
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
    }
}
