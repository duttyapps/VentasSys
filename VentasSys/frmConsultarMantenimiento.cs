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
    public partial class frmConsultarMantenimiento : Form
    {
        public frmConsultarMantenimiento()
        {
            InitializeComponent();
            fillDocumento();
        }

        private void fillDocumento() {
            dgvDocumentos.Rows.Clear();
            List<Ent_Mantenimiento> lista = BL_Programacion.getMantenimiento(txtNombre.Text, txtDNI.Text);

            foreach (Ent_Mantenimiento mant in lista)
            {
                dgvDocumentos.Rows.Add(mant.num_doc, mant.id, mant.tienda, mant.fecha_registro, mant.estado, mant.cliente_doc, mant.cliente, mant.fecha_salida);
            }

        }

        private void fillDetalle(int id) {
            dgvDetalle.Rows.Clear();
            List<Ent_Tipo_Mantenimiento> lista = BL_Programacion.getConsultaMantenimientoDetalle(id);

            foreach (Ent_Tipo_Mantenimiento mant in lista)
            {
                dgvDetalle.Rows.Add(mant.descripcion);
            }

        }

        private void showDetallesDoc(DataGridViewCellEventArgs e)
        {
            fillDetalle(Int32.Parse(dgvDocumentos.Rows[e.RowIndex].Cells["ID_CAB"].Value.ToString()));
            string tipo = dgvDocumentos.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            if (tipo == "RE") { lblTipo.Text = "REALIZADO"; } else if (tipo == "NR") { lblTipo.Text = "NO REAIZADO"; } else { lblTipo.Text = "REPARACION"; }

            lblFechaSalida.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA_SALIDA"].Value.ToString();

            lblFechaEmision.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA_REGISTRO"].Value.ToString();
            lblDNI.Text = dgvDocumentos.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            lblNombre.Text = dgvDocumentos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fillDocumento();
            Limpiar();
        }

        private void dgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                showDetallesDoc(e);
            }
        }
        private void Limpiar()
        {
            dgvDetalle.Rows.Clear();
            lblTipo.Text = "-";

            lblFechaSalida.Text = "-";

            lblFechaEmision.Text = "-";
            lblDNI.Text = "-";
            lblNombre.Text = "-";
        }

    }
}
