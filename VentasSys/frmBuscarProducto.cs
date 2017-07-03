﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmBuscarProducto : Form
    {
        public Ent_Productos ent_producto;
        public frmBuscarProducto()
        {
            InitializeComponent();
            fillCategorias();
            buscarProductos();
        }

        public void buscarProductos()
        {
            string nombre = txtProducto.Text;
            string cat = cboCategoria.SelectedValue.ToString();

            dgvProductos.AutoGenerateColumns = false;

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows.Clear();
            }

            List<Ent_Productos> lstProductos = BL_Productos.getProductos(nombre, cat);

            var bindingList = new BindingList<Ent_Productos>(lstProductos);
            var source = new BindingSource(bindingList, null);

            dgvProductos.DataSource = source;
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
                ent_producto.id = dgvProductos.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                ent_producto.id_cat = dgvProductos.Rows[e.RowIndex].Cells["ID_CAT"].Value.ToString();
                ent_producto.nombre = dgvProductos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                ent_producto.precio = double.Parse(dgvProductos.Rows[e.RowIndex].Cells["PRECIO"].Value.ToString());

                this.Close();
            }
        }
    }
}