using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.TarjetaCredito
{
    public partial class GestionTarjetas : UserControl
    {
        public GestorCategorias GestorCategorias;
        public GestionTarjetas()
        {
            InitializeComponent();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            //UserControl agregarCategoria = new AgregarTarjeta(GestorCategorias);
            //pnlGestor.Controls.Add(agregarCategoria);
        }
    }
}
