using Negocio;
using Negocio.Excepciones;
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
    public partial class Login : Form
    {
        public Sesion sis = Sesion.Singleton;
        public Login()
        {
            InitializeComponent();
            this.txtIngresar.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }

        private void RealizarLogin()
        {
            try
            {
                this.sis.Login(this.txtIngresar.Text);
                MenuPrincipal nuevaPantalla = new MenuPrincipal();
                //PantallaPrincipal nuevaPantalla = new PantallaPrincipal();
                this.Hide();
                nuevaPantalla.Show();
            }
            catch(ExcepcionAccesoDenegado denegado)
            {
                MessageBox.Show(denegado.Message);
            }
        }

        private void txtIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizarLogin();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
