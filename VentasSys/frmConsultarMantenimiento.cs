using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmConsultarMantenimiento : Form
    {
        private String nro_doc;
        private Ent_Prog_Mantenimiento prog;
        private Ent_Configuracion ent_configuracion;

        public frmConsultarMantenimiento()
        {
            InitializeComponent();
            fillDocumento();

            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            prog = new Ent_Prog_Mantenimiento();

            Dictionary<string, string> lista_tipo = new Dictionary<string, string>();
            lista_tipo.Add("RE", "REALIZADO");
            lista_tipo.Add("NR", "NO REALIZADO");
            lista_tipo.Add("RP", "EN REPARACIÓN");
            cboEstado.DataSource = new BindingSource(lista_tipo, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
        }

        private void fillDocumento() {
            dgvDocumentos.Rows.Clear();
            List<Ent_Mantenimiento> lista = BL_Programacion.getMantenimiento(txtNombre.Text, txtDNI.Text);

            foreach (Ent_Mantenimiento mant in lista)
            {
                dgvDocumentos.Rows.Add(mant.num_doc, mant.id, mant.tienda, mant.fecha_registro, mant.estado, mant.cliente_doc, mant.cliente, mant.fecha_salida, mant.direccion);
            }

        }

        private void fillDetalle(int id) {
            dgvDetalle.Rows.Clear();
            List<Ent_Tipo_Mantenimiento> lista = BL_Programacion.getConsultaMantenimientoDetalle(id);

            prog.mantenimiento = lista;
            foreach (Ent_Tipo_Mantenimiento mant in lista)
            {
                dgvDetalle.Rows.Add(mant.descripcion);
            }

        }

        private void showDetallesDoc(DataGridViewCellEventArgs e)
        {
            nro_doc = dgvDocumentos.Rows[e.RowIndex].Cells["ID_CAB"].Value.ToString();
            fillDetalle(Int32.Parse(dgvDocumentos.Rows[e.RowIndex].Cells["ID_CAB"].Value.ToString()));
            string tipo = dgvDocumentos.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            cboEstado.SelectedValue = tipo;

            lblFechaSalida.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA_SALIDA"].Value.ToString();

            lblFechaEmision.Text = dgvDocumentos.Rows[e.RowIndex].Cells["FECHA_REGISTRO"].Value.ToString();
            lblDNI.Text = dgvDocumentos.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
            lblNombre.Text = dgvDocumentos.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();

            prog.documento_des = dgvDocumentos.Rows[e.RowIndex].Cells["NUMERO_DOC"].Value.ToString();
            prog.cliente_des = lblNombre.Text;
            prog.cliente.direccion = dgvDocumentos.Rows[e.RowIndex].Cells["DIRECCION"].Value.ToString();
            prog.cliente.dni = lblDNI.Text;
            prog.documento = Convert.ToInt32(nro_doc);

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

            lblFechaSalida.Text = "-";

            lblFechaEmision.Text = "-";
            lblDNI.Text = "-";
            lblNombre.Text = "-";
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            InvoicePDF invoicePDF = new InvoicePDF();
            invoicePDF.createServicioTecnico(ent_configuracion, prog);
            /*String filename = "invoices\\serviciotecnico_" + nro_doc + ".pdf";
            if (File.Exists(filename))
            {
                Process.Start(filename);
            }
            else
            {
                MessageBox.Show("Documento no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ent_Prog_Mantenimiento mant = new Ent_Prog_Mantenimiento();
            mant.documento = Convert.ToInt32(nro_doc);
            mant.estado = cboEstado.SelectedValue.ToString();
            String result = BL_Mantenimiento.updMantenimiento(mant);

            if(result.Equals("1"))
            {
                fillDocumento();
                MessageBox.Show("¡Mantenimiento modificado!.", "Consulta Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar el mantenimiento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                String result = BL_Mantenimiento.delMantenimiento(nro_doc);
                if (result.Equals("1"))
                {
                    MessageBox.Show("¡Mantenimiento eliminado!.", "Consulta Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar_Click(new object(), new EventArgs());
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
