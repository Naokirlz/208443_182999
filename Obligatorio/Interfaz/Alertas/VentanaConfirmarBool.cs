using System;
using System.Windows.Forms;

namespace Interfaz.Alertas
{
    public partial class VentanaConfirmarBool : Form
    {
        public bool Respuesta;
        public VentanaConfirmarBool(string pregunta)
        {
            InitializeComponent();
            Respuesta = false;
            this.lblPregunta.Text = pregunta;
            this.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            Respuesta = true;
            this.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
