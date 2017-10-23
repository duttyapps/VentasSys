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
    public partial class frmDetalleVenta : Form
    {
        private string id_venta { get; set; }
        public frmDetalleVenta(string _id_venta)
        {
            id_venta = _id_venta;
            InitializeComponent();
            fillDatosVenta();
        }

        private void fillDetalles()
        {
            dgvDetalles.AutoGenerateColumns = false;

            if (dgvDetalles.Rows.Count > 0)
            {
                dgvDetalles.Rows.Clear();
            }

            List<Ent_Productos> lstDetalles = BL_Ventas.getDetalleVenta(id_venta);

            var bindingList = new BindingList<Ent_Productos>(lstDetalles);
            var source = new BindingSource(bindingList, null);

            dgvDetalles.DataSource = source;

        }

        private void fillDatosVenta()
        {
            Ent_Venta entity = BL_Ventas.getCabeceraVenta(id_venta);

            if (entity.tipo_venta == "FA")
            {
                lblDNI.Text = "RUC";
                lblNombres.Text = "Razón Social";
            }
            else
            {
                lblDNI.Text = "DNI";
                lblNombres.Text = "Nombres";
            }

            txtTipoVenta.Text = entity.tipo_venta_des;
            txtNroDoc.Text = entity.nro_doc_str;            
            txtDNI.Text = entity.cliente_doc;
            txtNombres.Text = entity.cliente;
            txtDireccion.Text = entity.direccion;
            txtFecha.Text = entity.emision;
            txtFormaPago.Text = entity.forma_pago_des;
            txtTelefono.Text = entity.telefono;
            txtUsuario.Text = entity.usuario;
            txtAnulado.Text = (entity.anulado == "1") ? "SI" : "NO";

            txtMotivo.Text = entity.motivo_anul;
            txtFechaAnul.Text = entity.fecha_anul;
            txtusuarioAnul.Text = entity.usuario_anul;

            lblTotal.Text = entity.monto_total.ToString("#0.00");

            Ent_Configuracion ent_configuracion = BL_Configuracion.getConfiguracion();

            txtSubTotal.Text = (Convert.ToDouble(lblTotal.Text) / Convert.ToDouble(ent_configuracion.IGV + 1)).ToString("#0.00");
            txtIGV.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtSubTotal.Text)).ToString("#0.00");

            txtRecibido.Text = entity.monto_recibido.ToString("#0.00");
            txtVuelto.Text = entity.monto_vuelto.ToString("#0.00");

            fillDetalles();
        }
    }
}
