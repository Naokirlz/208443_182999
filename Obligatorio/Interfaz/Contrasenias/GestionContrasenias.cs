using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class GestionContrasenias : UserControl
    {
        private IconButton BotonSeleccionado;
        public GestionContrasenias()
        {
            InitializeComponent();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(249, 118, 176));
            pnlGestor.Controls.Clear();
            UserControl resumenContrasenia = new ResumenContrasenias();
            pnlGestor.Controls.Add(resumenContrasenia);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(249, 118, 176));
            pnlGestor.Controls.Clear();
            UserControl agregarContrasenia = new AgregarContrasenias();
            pnlGestor.Controls.Add(agregarContrasenia);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(249, 118, 176));
            pnlGestor.Controls.Clear();
            UserControl modificarContrasenia = new ModificarContrasenias();
            pnlGestor.Controls.Add(modificarContrasenia);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(249, 118, 176));
            pnlGestor.Controls.Clear();
            UserControl eliminarContrasenia = new EliminarContrasenias();
            pnlGestor.Controls.Add(eliminarContrasenia);
        }

        private void btnFortaleza_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(249, 118, 176));
            pnlGestor.Controls.Clear();
            UserControl reporteFortalezaContrasenia = new ReporteFortalezaContrasenias();
            pnlGestor.Controls.Add(reporteFortalezaContrasenia);
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
