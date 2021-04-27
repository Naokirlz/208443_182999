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
    public partial class GestionCategorias : UserControl
    {
        //public GestorCategorias GestorCategorias;
        public Sistema sis = Sistema.Singleton;

        public GestionCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl agregarCategoria = new AgregarCategoria();
            pnlGestor.Controls.Add(agregarCategoria);
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl modificarCategoria = new ModificarCategoria();
            pnlGestor.Controls.Add(modificarCategoria);
        }

        private void btnEliminarCategorias_Click(object sender, EventArgs e)
        {
            pnlGestor.Controls.Clear();
            UserControl eliminarCategoria = new EliminarCategorias();
            pnlGestor.Controls.Add(eliminarCategoria);
        }
    }
}
