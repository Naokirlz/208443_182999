using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class GestionContrasenias : UserControl
    {
        public GestionContrasenias()
        {
            InitializeComponent();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl agregarContrasenia = new AgregarContrasenias();
            pnlGestor.Controls.Add(agregarContrasenia);
        }

        private void btnModificarContrasenias_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl modificarContrasenia = new ModificarContrasenias();
            pnlGestor.Controls.Add(modificarContrasenia);
        }
    }
}
