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
    public partial class Login : Form
    {
        public Sistema sis = Sistema.Singleton;
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.sis.Login(this.txtIngresar.Text))
            {
                PantallaPrincipal nuevaPantalla = new PantallaPrincipal();
                this.Hide();
                nuevaPantalla.Show();
                
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta");
            }
        }
    }
}
