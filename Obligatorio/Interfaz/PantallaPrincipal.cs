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
        public PantallaPrincipal()
        {
            InitializeComponent();
            this.GestorCategorias = new GestorCategorias();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl agregarCategoria = new AgregarCategoria(GestorCategorias);
            pnlPanelPrincipal.Controls.Add(agregarCategoria);
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl modificarCategoria = new ModificarCategoria(GestorCategorias);
            pnlPanelPrincipal.Controls.Add(modificarCategoria);
        }

        private void btnEliminarCategorias_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl eliminarCategoria = new EliminarCategorias(GestorCategorias);
            pnlPanelPrincipal.Controls.Add(eliminarCategoria);
        }
    }
}
