using System.Collections.Generic;
using System.Windows.Forms;
using VentasSys.EL;
using VentasSys.BL;

namespace VentasSys
{
    public partial class frmAlmacenProd : Form
    {
        private string totalProds;

        public frmAlmacenProd()
        {
            InitializeComponent();
            fillProducts();
        }

        private void fillProducts()
        {
            List<Ent_AlmacenProd> prod = BL_Almacen.getProducto_Almacen(null, null);
            txtTotal.Text = prod.Count.ToString();
            foreach (Ent_AlmacenProd p in prod)
            {
                dgvProducto.Rows.Add(p.id, p.codigo, p.producto, p.fecha_registro, p.tienda, p.fecha_salida, p.cantidad, p.tipo);
            }
        }
    }
}
