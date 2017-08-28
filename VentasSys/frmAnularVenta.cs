using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasSys
{
    public partial class frmAnularVenta : Form
    {
        private string cod_tienda { get; set; }

        public frmAnularVenta(string _cod_tienda)
        {
            cod_tienda = _cod_tienda;
            InitializeComponent();
        }
    }
}
