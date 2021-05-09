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
    public partial class InicioSesion : Form
    {
        private Sesion Sesion = Sesion.Singleton;
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void txtIngresar_TextChanged(object sender, EventArgs e)
        {
            ResaltarColor();
        }

        private void ResaltarColor()
        {
            txtIngresar.ForeColor = Color.WhiteSmoke;
            icoPassword.IconColor = Color.WhiteSmoke;
            pnlLinea.BackColor = Color.WhiteSmoke;
        }

        private void VolverColor()
        {
            if(txtIngresar.Text == "" && !txtIngresar.Focused)
            {
                txtIngresar.ForeColor = Color.DarkGray;
                icoPassword.IconColor = Color.DarkGray;
                pnlLinea.BackColor = Color.DarkGray;
                txtIngresar.PasswordChar = default;
                txtIngresar.Text = "Contraseña";
            }
            else if(!txtIngresar.Focused){
                txtIngresar.ForeColor = Color.DarkGray;
                icoPassword.IconColor = Color.DarkGray;
                pnlLinea.BackColor = Color.DarkGray;
            }
        }

        private void icoPassword_Click(object sender, EventArgs e)
        {
            txtIngresar.Focus();
        }

        private void icoPassword_MouseHover(object sender, EventArgs e)
        {
            ResaltarColor();
        }

        private void txtIngresar_MouseHover(object sender, EventArgs e)
        {
            ResaltarColor();
        }

        private void txtIngresar_MouseLeave(object sender, EventArgs e)
        {
            VolverColor();
        }

        private void icoPassword_MouseLeave(object sender, EventArgs e)
        {
            VolverColor();
        }

        private void txtIngresar_Click(object sender, EventArgs e)
        {
            if(txtIngresar.PasswordChar != "•".ToCharArray()[0])
            {
                txtIngresar.Text = "";
                txtIngresar.PasswordChar = "•".ToCharArray()[0];
            }
        }

        private void txtIngresar_Leave(object sender, EventArgs e)
        {
            VolverColor();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }

        private void RealizarLogin()
        {
            if (txtIngresar.PasswordChar == "•".ToCharArray()[0])
            {
                try
                {
                    Sesion.Login(this.txtIngresar.Text);
                    MenuPrincipal nuevaPantalla = new MenuPrincipal();
                    this.Hide();
                    nuevaPantalla.Show();
                }
                catch (ExcepcionAccesoDenegado denegado)
                {
                    MessageBox.Show(denegado.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar los campos primero.");
            }
        }

        private void txtIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizarLogin();
            }
        }

        private void txtIngresar_Enter(object sender, EventArgs e)
        {
            if (txtIngresar.PasswordChar != "•".ToCharArray()[0])
            {
                txtIngresar.Text = "";
                txtIngresar.PasswordChar = "•".ToCharArray()[0];
            }
        }
    }
}
