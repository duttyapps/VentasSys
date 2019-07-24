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
    public partial class frmReporteVentasxProducto : Form
    {
        public frmReporteVentasxProducto()
        {
            InitializeComponent();
            customPickers();
            fillMeses();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
            txtYear.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fillTiendas();
            fillCategorias();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            txtFecha.Enabled = true;
            cboMes.Enabled = false;
            txtYear.Enabled = false;
        }

        private void rbMesYear_CheckedChanged(object sender, EventArgs e)
        {
            txtFecha.Enabled = false;
            cboMes.Enabled = true;
            txtYear.Enabled = true;
        }

        private void customPickers()
        {
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
        }

        private void fillMeses()
        {
            List<Object> meses = new List<Object>();
            meses.Add(new { mes = "", nombre = "Todos"});
            meses.Add(new { mes = "01", nombre = "Enero" });
            meses.Add(new { mes = "02", nombre = "Febrero" });
            meses.Add(new { mes = "03", nombre = "Marzo" });
            meses.Add(new { mes = "04", nombre = "Abril" });
            meses.Add(new { mes = "05", nombre = "Mayo" });
            meses.Add(new { mes = "06", nombre = "Junio" });
            meses.Add(new { mes = "07", nombre = "Julio" });
            meses.Add(new { mes = "08", nombre = "Agosto" });
            meses.Add(new { mes = "09", nombre = "Septiembre" });
            meses.Add(new { mes = "10", nombre = "Octubre" });
            meses.Add(new { mes = "11", nombre = "Noviembre" });
            meses.Add(new { mes = "12", nombre = "Diciembre" });

            cboMes.DataSource = meses;
            cboMes.ValueMember = "mes";
            cboMes.DisplayMember = "nombre";
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
            fillReporte();
        }

        private void fillReporte()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            string fecha = String.Empty;
            string mes = String.Empty;

            if (rbFecha.Checked)
            {
                fecha = txtFecha.Text;
                mes = String.Empty;
            }
            else
            {
                mes = cboMes.SelectedValue.ToString() + "/" + txtYear.Text;
                fecha = String.Empty;
            }

            string tienda = cboTiendas.SelectedValue.ToString();
            string cat = cboCategoria.SelectedValue.ToString();

            BL_Ventas.getReporteVentasxProductos(fecha, mes, tienda, cat, ref ds, ref dt);

            rpvVentasProductos.ProcessingMode = ProcessingMode.Local;
            rpvVentasProductos.LocalReport.ReportPath = "Reportes/VentasxProductos.rdlc";

            rpvVentasProductos.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("dsReporteVentasxProducto", dt);
            source.Value = ds.Tables[0];

            rpvVentasProductos.LocalReport.DataSources.Add(source);

            rpvVentasProductos.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillReporte();
        }
    }
}
