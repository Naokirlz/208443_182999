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
    public partial class RegistroPassword : Form
    {
        public RegistroPassword()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            NavegarALogin();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtRepetirPassword.Focus();
            }
        }

        private void NavegarALogin()
        {
            if (txtRepetirPassword.PasswordChar == "•".ToCharArray()[0]) {
                string passwordInicial = this.txtPassword.Text;
                string passwordRepetido = this.txtRepetirPassword.Text;
                try
                {
                    if (passwordInicial != passwordRepetido)
                    {
                        MessageBox.Show("Los passwords deben coincidir.");
                        return;
                    }
                    Sesion sesion = Sesion.Singleton;
                    sesion.GuardarPrimerPassword(passwordRepetido);
                    InicioSesion inicioSesion = new InicioSesion();
                    this.Hide();
                    inicioSesion.Show();
                }
                catch (ExcepcionLargoTexto errorLargoTexto)
                {
                    MessageBox.Show(errorLargoTexto.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar los campos primero.");
            }
        }

        private void txtRepetirPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrar.Focus();
            }else if (e.KeyCode == Keys.Tab)
            {
                NavegarALogin();
            }
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            ResaltarColorPassword();
        }

        private void txtRepetirPassword_MouseHover(object sender, EventArgs e)
        {
            ResaltarColorRepetir();
        }



        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            VolverColorPassword();
        }

        

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            VolverColorPassword();
        }

        private void txtRepetirPassword_Leave(object sender, EventArgs e)
        {
            VolverColorRepetir();
        }

        private void txtRepetirPassword_MouseLeave(object sender, EventArgs e)
        {
            VolverColorRepetir();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ResaltarColorPassword();
        }

        private void txtRepetirPassword_TextChanged(object sender, EventArgs e)
        {
            ResaltarColorRepetir();
        }

        private void ResaltarColorPassword()
        {
            VolverColorRepetir();
            txtPassword.ForeColor = Color.WhiteSmoke;
            icoPassword.IconColor = Color.WhiteSmoke;
            pnlLinea.BackColor = Color.WhiteSmoke;
        }

        private void ResaltarColorRepetir()
        {
            VolverColorPassword();
            txtRepetirPassword.ForeColor = Color.WhiteSmoke;
            icoRepetirPassword.IconColor = Color.WhiteSmoke;
            pnlRepetirPassword.BackColor = Color.WhiteSmoke;
        }

        private void VolverColorPassword()
        {
            if (txtPassword.Text == "" && !txtPassword.Focused)
            {
                txtPassword.ForeColor = Color.DarkGray;
                icoPassword.IconColor = Color.DarkGray;
                pnlLinea.BackColor = Color.DarkGray;
                txtPassword.PasswordChar = default;
                txtPassword.Text = "Contraseña";
            }
            else if (!txtPassword.Focused)
            {
                txtPassword.ForeColor = Color.DarkGray;
                icoPassword.IconColor = Color.DarkGray;
                pnlLinea.BackColor = Color.DarkGray;
            }
        }

        private void VolverColorRepetir()
        {
            if (txtRepetirPassword.Text == "" && !txtRepetirPassword.Focused)
            {
                txtRepetirPassword.ForeColor = Color.DarkGray;
                icoRepetirPassword.IconColor = Color.DarkGray;
                pnlRepetirPassword.BackColor = Color.DarkGray;
                txtRepetirPassword.PasswordChar = default;
                txtRepetirPassword.Text = "Repetir Contraseña";
            }
            else if (!txtPassword.Focused)
            {
                txtRepetirPassword.ForeColor = Color.DarkGray;
                icoRepetirPassword.IconColor = Color.DarkGray;
                pnlRepetirPassword.BackColor = Color.DarkGray;
            }
        }

        private void icoPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void icoRepetirPassword_Click(object sender, EventArgs e)
        {
            txtRepetirPassword.Focus();
        }

        private void icoPassword_MouseHover(object sender, EventArgs e)
        {
            ResaltarColorPassword();
        }

        private void icoPassword_MouseLeave(object sender, EventArgs e)
        {
            VolverColorPassword();
        }

        private void icoRepetirPassword_MouseHover(object sender, EventArgs e)
        {
            ResaltarColorRepetir();
        }

        private void icoRepetirPassword_MouseLeave(object sender, EventArgs e)
        {
            VolverColorRepetir();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != "•".ToCharArray()[0])
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = "•".ToCharArray()[0];
            }
        }

        private void txtRepetirPassword_Click(object sender, EventArgs e)
        {
            if (txtRepetirPassword.PasswordChar != "•".ToCharArray()[0])
            {
                txtRepetirPassword.Text = "";
                txtRepetirPassword.PasswordChar = "•".ToCharArray()[0];
            }
        }

        private void txtRepetirPassword_Enter(object sender, EventArgs e)
        {
            VolverColorPassword();
            if (txtRepetirPassword.PasswordChar != "•".ToCharArray()[0])
            {
                txtRepetirPassword.Text = "";
                txtRepetirPassword.PasswordChar = "•".ToCharArray()[0];
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            VolverColorRepetir();
            if (txtPassword.PasswordChar != "•".ToCharArray()[0])
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = "•".ToCharArray()[0];
            }
        }
    }
}
