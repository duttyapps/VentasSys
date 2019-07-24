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
    public partial class frmGuiaRemision : Form
    {
        private Ent_Configuracion ent_configuracion;
        private string cod_tienda { get; set; }
        private string correlativo { get; set; }

        public frmGuiaRemision(string _cod_tienda)
        {
            InitializeComponent();
            cod_tienda = _cod_tienda;
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            lblRUC.Text = "R.U.C. " + ent_configuracion.RUC;
            lblRazonSocial.Text = ent_configuracion.RAZON_SOCIAL;
            txtDireccionPartida.Text = ent_configuracion.DIRECCION;
            txtTransRuc.Text = ent_configuracion.RUC;
            txtTransCliente.Text = ent_configuracion.RAZON_SOCIAL;
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;
            txtFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaTraslado.Text = DateTime.Now.ToString("dd/MM/yyyy");
            correlativo = BL_Ventas.getCorrelativo("GR");
            lblNroDoc.Text = "001-" + correlativo;
            fillTipoDocumento();
            fillMotivos();
            fillNroDoc();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "nombre", "FA");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(String.Empty, "dni", "FA");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtDesCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDesRuc.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void fillTipoDocumento()
        {
            List<Ent_TipoVentas> items = new List<Ent_TipoVentas>();

            var tipo_venta = BL_Ventas.getTipoVenta(String.Empty);

            items.AddRange(tipo_venta);

            cboTipoDocumento.DataSource = items;
            cboTipoDocumento.ValueMember = "codigo";
            cboTipoDocumento.DisplayMember = "descripcion";
        }

        private void fillMotivos()
        {
            List < Ent_Motivos> items = new List<Ent_Motivos>();

            var motivos = BL_Ventas.getMotivos();

            items.AddRange(motivos);

            lstMotivos.DataSource = items;
            lstMotivos.ValueMember = "codigo";
            lstMotivos.DisplayMember = "descripcion";
        }

        private void fillNroDoc()
        {
            List<Ent_Venta> items = new List<Ent_Venta>();

            Ent_Venta venta = new Ent_Venta();

            venta.cod_tienda = cod_tienda;
            venta.tipo_venta = (cboTipoDocumento.SelectedValue == null) ? "BO" : cboTipoDocumento.SelectedValue.ToString();

            if (venta.tipo_venta == "VentasSys.EL.Ent_TipoVentas") {
                return;
            }

            var ventas = BL_Ventas.getVentas(venta);

            items.AddRange(ventas);

            cboNroDocumento.DataSource = items;
            cboNroDocumento.ValueMember = "id_cab";
            cboNroDocumento.DisplayMember = "nro_doc_str";
        }

        private void fillDetalles(string id)
        {
            dgvProductos.AutoGenerateColumns = false;

            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Rows.Clear();
            }

            if (id == "VentasSys.EL.Ent_Venta") {
                return;
            }

            List<Ent_Productos> lstDetalles = BL_Ventas.getDetalleVenta(id);

            var bindingList = new BindingList<Ent_Productos>(lstDetalles);
            var source = new BindingSource(bindingList, null);

            dgvProductos.DataSource = source;

        }

        private void lstMotivos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < lstMotivos.Items.Count; ++ix)
                    if (e.Index != ix) lstMotivos.SetItemChecked(ix, false);
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTipoDocumento.Items.Count > 0)
            {
                fillNroDoc();
            }
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Está seguro que desea emitir la guía de remisión?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                if (txtDesCliente.Text.Equals(String.Empty))
                {
                    MessageBox.Show("El nombre de cliente o razón social no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtDesRuc.Text.Equals(String.Empty))
                {
                    MessageBox.Show("El RUC no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtDireccionLlegada.Text.Equals(String.Empty))
                {
                    MessageBox.Show("La dirección de llegada no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string cod_motivo = String.Empty;

                foreach (object itemChecked in lstMotivos.CheckedItems)
                {
                    cod_motivo = ((VentasSys.EL.Ent_Motivos)(itemChecked)).codigo;
                }

                if (cod_motivo.Equals(String.Empty))
                {
                    MessageBox.Show("Debe seleccionar un motivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ent_GuiaRemision entity = new Ent_GuiaRemision();
                entity.nro_guia = BL_Ventas.getCorrelativo("GR");
                entity.cod_tienda = cod_tienda;
                entity.fecha_traslado = txtFechaTraslado.Text;
                entity.cantidad = 1;
                entity.destinatario_ruc = txtDesRuc.Text;
                entity.ref_tipo_doc = cboTipoDocumento.SelectedValue.ToString();
                entity.ref_nro_doc = cboNroDocumento.SelectedValue.ToString();
                entity.motivo = cod_motivo;

                try
                {
                    string _result = BL_Ventas.emitirGuiaRemision(entity);

                    if (_result == "1")
                    {
                        MessageBox.Show("Guía de Remisión Emitida con Éxito!.", "Guía de Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al emitir la guía.\n\n" + _result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al emitir la guía.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboNroDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNroDocumento.Items.Count > 0)
            {
                fillDetalles(cboNroDocumento.SelectedValue.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
