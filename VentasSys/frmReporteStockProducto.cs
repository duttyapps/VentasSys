using Microsoft.Reporting.WinForms;
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
    public partial class frmReporteStockProducto : Form
    {
        public frmReporteStockProducto()
        {
            InitializeComponent();
            fillCategorias();
            fillComboEstados();
            fillTiendas();
        }

        private void frmReporteStockProducto_Load(object sender, EventArgs e)
        {
            fillReporte();
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

        private void fillComboEstados()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = String.Empty, desc = "Todos" });
            items.Add(new { id = "1", desc = "Activo" });
            items.Add(new { id = "0", desc = "Inactivo" });

            cboEstado.DataSource = items;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "desc";
        }

        private void fillTiendas()
        {
            List<Ent_Tienda> items = new List<Ent_Tienda>();

            items.Add(new Ent_Tienda { cod_tienda = "", des_tienda = "Todos" });

            var tiendas = BL_Tienda.getTiendas();

            items.AddRange(tiendas);

            cboTienda.DataSource = items;
            cboTienda.ValueMember = "cod_tienda";
            cboTienda.DisplayMember = "des_tienda";
        }

        private void fillReporte()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            BL_Productos.getReporteStockProductos(cboCategoria.SelectedValue.ToString(), cboEstado.SelectedValue.ToString(), cboTienda.SelectedValue.ToString(), ref ds, ref dt);

            rpvStockProductos.ProcessingMode = ProcessingMode.Local;
            rpvStockProductos.LocalReport.ReportPath = "Reportes/StockProductos.rdlc";

            rpvStockProductos.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("dsStockProductos", dt);
            source.Value = ds.Tables[0];

            rpvStockProductos.LocalReport.DataSources.Add(source);

            rpvStockProductos.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillReporte();
        }
    }
}
