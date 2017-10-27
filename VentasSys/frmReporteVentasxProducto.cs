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
    public partial class frmReporteVentasxProducto : Form
    {
        public frmReporteVentasxProducto()
        {
            InitializeComponent();
            customPickers();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtMes.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtYear.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fillTiendas();
            fillCategorias();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            txtFecha.Enabled = true;
            txtMes.Enabled = false;
            txtYear.Enabled = false;
        }

        private void rbMesYear_CheckedChanged(object sender, EventArgs e)
        {
            txtFecha.Enabled = false;
            txtMes.Enabled = true;
            txtYear.Enabled = true;
        }

        private void customPickers()
        {
            txtMes.Format = DateTimePickerFormat.Custom;
            txtMes.CustomFormat = "MMMM";
            txtMes.ShowUpDown = true;
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
        }

        private void fillTiendas()
        {
            List<Ent_Tienda> items = new List<Ent_Tienda>();

            items.Add(new Ent_Tienda { cod_tienda = "", des_tienda = "Todos" });

            var tiendas = BL_Tienda.getTiendas();

            items.AddRange(tiendas);

            cboTiendas.DataSource = items;
            cboTiendas.ValueMember = "cod_tienda";
            cboTiendas.DisplayMember = "des_tienda";
        }

        private void fillCategorias()
        {
            List<Ent_CategoriaProductos> items = new List<Ent_CategoriaProductos>();

            items.Add(new Ent_CategoriaProductos { id = "", nombre = "Todos" });

            var categorias = BL_CategoriaProductos.getCategorias(String.Empty, "1");

            items.AddRange(categorias);

            cboCategoria.DataSource = items;
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "nombre";
        }

        private void frmReporteVentasxProducto_Load(object sender, EventArgs e)
        {

            this.rvVentasProductos.RefreshReport();
        }
    }
}
