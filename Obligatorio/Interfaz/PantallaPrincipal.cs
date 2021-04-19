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

namespace Interfaz
{
    public partial class PantallaPrincipal : Form
    {
        public GestorCategorias GestorCategorias;
        public PantallaPrincipal(GestorCategorias gestorCategorias)
        {
            this.GestorCategorias = gestorCategorias;
            InitializeComponent();
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnGestionCategoria_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorCategorias = new GestionCategorias(GestorCategorias);
            pnlPanelPrincipal.Controls.Add(gestorCategorias);
        }
    }
}
