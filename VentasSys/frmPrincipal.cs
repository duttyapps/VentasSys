using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;
using VentasSys.Utils;

namespace VentasSys
{
    public partial class frmPrincipal : Form
    {
        private Log log = new Log();
        private Ent_Usuario ent_usuario;
        private Ent_Configuracion ent_configuracion;
        private string tipo_venta { get; set; }
        private string correlativo { get; set; }
        public double total;

        public frmPrincipal(Ent_Usuario ent_us)
        {
            try
            {
                InitializeComponent();
                ent_usuario = ent_us;
                tipo_venta = "BO";
                InicializarSistema();
                log.Info("Tipo de Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
                log.Info("Serie N°: " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            } catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                log.Error(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void InicializarSistema()
        {
            fillMenuTipoVenta();
            ent_configuracion = new Ent_Configuracion();
            ent_configuracion = BL_Configuracion.getConfiguracion();
            lblRUC.Text = "R.U.C. " + ent_configuracion.RUC;
            lblRazonSocial.Text = ent_configuracion.RAZON_SOCIAL;
            Image logo = Image.FromFile("logo.png");
            pbLogo.Image = logo;
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblBienvenido.Text = "Bienvenid@ " + ent_usuario.nombres;
            lblSerie.Text = "N° 001-" + correlativo;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void fillMenuTipoVenta()
        {
            List<Ent_TipoVentas> lstTipoVentas = BL_Ventas.getTipoVenta(String.Empty);

            ToolStripMenuItem[] items = new ToolStripMenuItem[lstTipoVentas.Count];
            int i = 0;
            lstTipoVentas.ForEach(delegate(Ent_TipoVentas tipo_venta)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = tipo_venta.id;
                items[i].Tag = tipo_venta.codigo;
                items[i].Text = tipo_venta.descripcion;
                items[i].Click += new EventHandler(MenuVentasTipoItemClickHandler);
                i++;
            });

            menuTipoVenta.DropDownItems.AddRange(items);

        }

        private void MenuVentasTipoItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            tipo_venta = clickedItem.Tag.ToString();
            correlativo = BL_Ventas.getCorrelativo(tipo_venta);
            lblTipoVenta.Text = clickedItem.Text.ToString().ToUpper();
            lblSerie.Text = "N° 001-" + correlativo;

            log.Info("Cambio Tipo Venta: " + tipo_venta, System.Reflection.MethodBase.GetCurrentMethod().Name);
            log.Info("Serie N°: " + lblSerie.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sistema.Base_de_Datos.frmConfiguracion frm = new Sistema.Base_de_Datos.frmConfiguracion();
            frm.ShowDialog();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtCliente.Text);
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frm = new frmBuscarCliente(txtCliente.Text, "dni");
            frm.ShowDialog();

            if (frm.ent_cliente != null)
            {
                txtCliente.Text = (frm.ent_cliente.nombres == null) ? "" : frm.ent_cliente.nombres;
                txtDireccion.Text = (frm.ent_cliente.direccion == null) ? "" : frm.ent_cliente.direccion;
                txtDNI.Text = (frm.ent_cliente.dni == null) ? "" : frm.ent_cliente.dni;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            frm.ShowDialog();

            if(frm.ent_producto != null)
            {
                dgvProductos.Rows.Add("1", frm.ent_producto.nombre, frm.ent_producto.precio, frm.ent_producto.precio);
            }

            total = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[3].Value));

            txtTotal.Text = total.ToString("#0.00");
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
