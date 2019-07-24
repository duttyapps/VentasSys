using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmBuscarProducto : Form
    {
        public Ent_Productos ent_producto;
        private string cod_tienda { get; set; }
        private string alquiler { get; set; }
        public frmBuscarProducto(string _cod_tienda,string _alquiler)
        {
            cod_tienda = _cod_tienda;
            alquiler = _alquiler;
            InitializeComponent();
            fillCategorias();
            buscarProductos();
        }

        private void buscarProductos()
        {
            string nombre = txtProducto.Text;
            string cat = cboCategoria.SelectedValue.ToString();
            string codigo = txtCodigo.Text;

            dgvProductos.AutoGenerateColumns = false;
            
            if (cat == "VentasSys.EL.Ent_CategoriaProductos")
            {
                return;
            }
            
            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows.Clear();
            }
            
            List<Ent_Productos> lstProductos = BL_Productos.getProductos(nombre, codigo, cat, cod_tienda, "1", alquiler);

            var bindingList = new BindingList<Ent_Productos>(lstProductos);
            var source = new BindingSource(bindingList, null);

            dgvProductos.DataSource = source;

            //formating...
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "f";
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
        }

        private void txtProducto_TextChanged(object sender, System.EventArgs e)
        {
            buscarProductos();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buscarProductos();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                ent_producto = new Ent_Productos();
                ent_producto.id = int.Parse(dgvProductos.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                ent_producto.cod_producto = dgvProductos.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                ent_producto.id_cat = int.Parse(dgvProductos.Rows[e.RowIndex].Cells["ID_CAT"].Value.ToString());
                ent_producto.nombre = dgvProductos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                ent_producto.precio = float.Parse(dgvProductos.Rows[e.RowIndex].Cells["PRECIO"].Value.ToString());

                this.Close();
            }
        }

        private void cboTienda_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buscarProductos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscarProductos();
        }
    }
}
