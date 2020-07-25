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
    public partial class frmListarProductos : Form
    {
        public frmListarProductos()
        {
            InitializeComponent();
            fillProductos();
        }

        private void fillProductos()
        {
            dgvProductos.AutoGenerateColumns = false;

            List<Ent_Productos> lstProductos = BL_Productos.getProductos("", "", "", "", "1", "0");

            var bindingList = new BindingList<Ent_Productos>(lstProductos);
            var source = new BindingSource(bindingList, null);

            dgvProductos.DataSource = source;

            //formating...
            dgvProductos.Columns["precio"].DefaultCellStyle.Format = "f";
        }
    }
}
