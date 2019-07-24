using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasSys.EL;
using VentasSys.BL;

namespace VentasSys
{
    public partial class frmAlmacenProd : Form
    {
        public frmAlmacenProd()
        {
            InitializeComponent();
        }

        private void txtCodigoS_TextChanged(object sender, EventArgs e)
        {
            dgvProducto.Rows.Clear();
            List<Ent_AlmacenProd> prod = BL_Almacen.getProducto_Almacen(txtCodigoS.Text, txtProducto.Text);
            foreach(Ent_AlmacenProd p in prod){
                dgvProducto.Rows.Add(p.id, p.codigo, p.producto, p.fecha_registro, p.tienda, p.fecha_salida, p.cantidad, p.tipo);
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            dgvProducto.Rows.Clear();
            List<Ent_AlmacenProd> prod = BL_Almacen.getProducto_Almacen(txtCodigoS.Text, txtProducto.Text);
            foreach (Ent_AlmacenProd p in prod)
            {
                dgvProducto.Rows.Add(p.id, p.codigo, p.producto, p.fecha_registro, p.tienda, p.fecha_salida, p.cantidad, p.tipo);
            }
        }
    }
}
