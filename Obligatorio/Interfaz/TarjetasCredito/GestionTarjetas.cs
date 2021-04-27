using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.TarjetasCredito
{
    public partial class GestionTarjetas : UserControl
    {
        public GestionTarjetas()
        {
            InitializeComponent();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl agregarTarjeta = new AgregarTarjetas();
            pnlGestor.Controls.Add(agregarTarjeta);
        }
    }
}
