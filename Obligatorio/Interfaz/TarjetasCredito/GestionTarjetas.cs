using FontAwesome.Sharp;
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
        private IconButton BotonSeleccionado;
        public GestionTarjetas()
        {
            InitializeComponent();
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(253, 138, 114));
            pnlGestor.Controls.Clear();
            UserControl agregarTarjeta = new AgregarTarjetas();
            pnlGestor.Controls.Add(agregarTarjeta);
        }

        private void btnModificarTarjeta_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(253, 138, 114));
            pnlGestor.Controls.Clear();
            UserControl modificarTarjeta = new ModificarTarjetas();
            pnlGestor.Controls.Add(modificarTarjeta);
        }

        private void btnEliminarTarjetas_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(253, 138, 114));
            pnlGestor.Controls.Clear();
            UserControl eliminarTarjeta = new EliminarTarjetas();
            pnlGestor.Controls.Add(eliminarTarjeta);
        }

        private void btnResumenTarjeta_Click(object sender, EventArgs e)
        {
            BotonActivo(sender, Color.FromArgb(253, 138, 114));
            pnlGestor.Controls.Clear();
            UserControl resumenTarjeta = new ResumenTarjetas();
            pnlGestor.Controls.Add(resumenTarjeta);
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
