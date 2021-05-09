using FontAwesome.Sharp;
using Interfaz.CategoriasForm;
using Negocio;
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
        private IconButton BotonSeleccionado;
        //public GestorCategorias GestorCategorias;
        public Sesion sis = Sesion.Singleton;

        public GestionCategorias()
        {
            InitializeComponent();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, RGBColores.Color1);
            pnlGestor.Controls.Clear();
            UserControl resumenCategoria = new ResumenCategorias();
            pnlGestor.Controls.Add(resumenCategoria);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, RGBColores.Color2);
            pnlGestor.Controls.Clear();
            UserControl agregarCategoria = new AgregarCategoria();
            pnlGestor.Controls.Add(agregarCategoria);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, RGBColores.Color3);
            pnlGestor.Controls.Clear();
            UserControl modificarCategoria = new ModificarCategoria();
            pnlGestor.Controls.Add(modificarCategoria);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, RGBColores.Color4);
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

        private struct RGBColores
        {
            public static Color Color1 = Color.FromArgb(172, 126, 241);
            public static Color Color2 = Color.FromArgb(249, 118, 176);
            public static Color Color3 = Color.FromArgb(253, 138, 114);
            public static Color Color4 = Color.FromArgb(95, 77, 221);
        }
    }
}
