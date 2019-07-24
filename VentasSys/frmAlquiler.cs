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
    public partial class frmAlquiler : Form
    {
        public frmAlquiler()
        {
            InitializeComponent();
        }

        private void btnAlquilar_Click(object sender, EventArgs e)
        {
            setAlquiler();
        }

        private void setAlquiler()
        {
            Ent_Alquiler ent = new Ent_Alquiler();
            ent.fecha_ent = dtFechaEnt.Value.ToString();
            ent.hora_ent = dtHoraEnt.Value.ToString();
            ent.fecha_dev = dtFechaDev.Value.ToString();
            ent.hora_dev = dtHoraDev.Value.ToString();
            ent.cliente = txtCliente.Text;
            ent.detalle = txtDetalle.Text;

            string result = BL_Programacion.setAlquiler(ent);
            if (result == "1")
            {
                MessageBox.Show("¡Alquiler programado exitosamente!", "Programar Alquiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Ocurrió un error al programar el alquiler!\n" + result, "Programar Alquiler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
