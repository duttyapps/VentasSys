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

namespace VentasSys
{
    public partial class frmReporteClientes : Form
    {
        public frmReporteClientes()
        {
            InitializeComponent();
            fillComboTipo();
            fillReporte();
        }

        private void frmReporteClientes_Load(object sender, EventArgs e)
        {

            this.rpvClientes.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillReporte();
        }

        private void fillReporte()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            BL_Clientes.getReporteClientes(txtDNI.Text, txtNombres.Text, cboTipo.SelectedValue.ToString(), ref ds, ref dt);

            rpvClientes.ProcessingMode = ProcessingMode.Local;
            rpvClientes.LocalReport.ReportPath = "Reportes/Clientes.rdlc";

            rpvClientes.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("ClientesDS", dt);
            source.Value = ds.Tables[0];

            rpvClientes.LocalReport.DataSources.Add(source);

            rpvClientes.RefreshReport();
        }

        private void fillComboTipo()
        {
            List<Object> items = new List<Object>();
            items.Add(new { id = "", desc = "Todos" });
            items.Add(new { id = "N", desc = "Persona" });
            items.Add(new { id = "E", desc = "Empresa" });

            cboTipo.DataSource = items;
            cboTipo.ValueMember = "id";
            cboTipo.DisplayMember = "desc";
        }
    }
}
