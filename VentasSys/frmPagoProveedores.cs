using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasSys.BL;
using VentasSys.EL;

namespace VentasSys
{
    public partial class frmPagoProveedores : Form
    {
        private DateTime _dateNow;
        public frmPagoProveedores()
        {
            InitializeComponent();
            _dateNow = DateTime.Now;
            txtFecha.Value = _dateNow;
            fillProveedores();
        }

        public void fillProveedores()
        {
            List<Ent_Proveedores> items = new List<Ent_Proveedores>();

            var formapago = BL_Proveedores.getProveedores();

            items.AddRange(formapago);

            cboProveedores.DataSource = items;
            cboProveedores.ValueMember = "id";
            cboProveedores.DisplayMember = "nombre";
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {
            if (txtFecha.Value != _dateNow)
            {
                btnRegistrarPago.Enabled = false;
            } else
            {
                btnRegistrarPago.Enabled = true;
            }
        }
    }
}
