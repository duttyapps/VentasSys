using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmPrincipal : Form
    {
        private Ent_Usuario ent_usuario;
        private string tipo_venta { get; set; }
        private string correlativo { get; set; }

        public frmPrincipal(Ent_Usuario ent_us)
        {
            InitializeComponent();
            ent_usuario = ent_us;
            tipo_venta = "BO";
            InicializarSistema();
        }

        private void InicializarSistema()
        {
            fillMenuTipoVenta();
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

            txtCliente.Text = frm.ent_cliente.nombres;
            txtDireccion.Text = frm.ent_cliente.direccion;
            txtDNI.Text = frm.ent_cliente.dni;
        }
    }
}
