using FontAwesome.Sharp;
using Negocio;
using Negocio.InterfacesGUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz.Categorias
{
    public partial class GestionCategorias : UserControl
    {
        private IconButton BotonSeleccionado;
        public ICategoria Sesion = new CategoriaGUI();

        public GestionCategorias()
        {
            InitializeComponent();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(172, 126, 241));
            pnlGestor.Controls.Clear();
            UserControl resumenCategoria = new ResumenCategorias();
            pnlGestor.Controls.Add(resumenCategoria);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(172, 126, 241));
            pnlGestor.Controls.Clear();
            UserControl agregarCategoria = new AgregarCategoria();
            pnlGestor.Controls.Add(agregarCategoria);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(172, 126, 241));
            pnlGestor.Controls.Clear();
            UserControl modificarCategoria = new ModificarCategoria();
            pnlGestor.Controls.Add(modificarCategoria);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(172, 126, 241));
            pnlGestor.Controls.Clear();
            UserControl eliminarCategoria = new EliminarCategorias();
            pnlGestor.Controls.Add(eliminarCategoria);
        }

        private void BotonActivo(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                BotonInactivo();
                BotonSeleccionado = (IconButton)senderBtn;
                BotonSeleccionado.BackColor = Color.FromArgb(37, 36, 81);
                BotonSeleccionado.ForeColor = color;
                BotonSeleccionado.IconColor = color;
            }
        }

        private void BotonInactivo()
        {
            if (BotonSeleccionado != null)
            {
                BotonSeleccionado.BackColor = Color.FromArgb(31, 30, 68);
                BotonSeleccionado.ForeColor = Color.Gainsboro;
                BotonSeleccionado.IconColor = Color.Gainsboro;
            }
        }
    }
}
