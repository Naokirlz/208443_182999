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
        private GestorCategorias GestorCategorias;
        public Login()
        {
            this.GestorCategorias = new GestorCategorias("secreto");
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.GestorCategorias.Login(this.txtIngresar.Text))
            {
                PantallaPrincipal nuevaPantalla = new PantallaPrincipal(this.GestorCategorias);
                nuevaPantalla.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta");
            }
        }
    }
}
