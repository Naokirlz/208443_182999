using Interfaz.Contrasenias;
using Interfaz.TarjetasCredito;
using Interfaz.Vulnerabilidades;
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
    public partial class PantallaPrincipal : Form
    {
        private Sesion Sesion = Sesion.Singleton;
        public PantallaPrincipal()
        {
           InitializeComponent();
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnGestionCategoria_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorCategorias = new GestionCategorias();
            pnlPanelPrincipal.Controls.Add(gestorCategorias);
        }

        private void btnGestionContrasenia_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorContrasenias = new GestionContrasenias();
            pnlPanelPrincipal.Controls.Add(gestorContrasenias);
        }

        private void btnGestionTarjetaCredito_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorTarjetas = new GestionTarjetas();
            pnlPanelPrincipal.Controls.Add(gestorTarjetas);
        }

        private void btnVerificarVulnerabilidad_Click(object sender, EventArgs e)
        {
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorVulnerabilidades = new GestionVulnerabilidades();
            pnlPanelPrincipal.Controls.Add(gestorVulnerabilidades);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.LogOut();
            Login pantallaLogin = new Login();
            this.Hide();
            pantallaLogin.Show();
        }
    }
}
