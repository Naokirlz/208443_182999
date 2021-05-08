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
    public partial class RegistrarPassword : Form
    {
        public RegistrarPassword()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string passwordInicial = this.txtPassword.Text;
            string passwordRepetido = this.txtRepetirPassword.Text;
            try
            {
                if(passwordInicial != passwordRepetido)
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
            catch(ExcepcionLargoTexto errorLargoTexto)
            {
                MessageBox.Show(errorLargoTexto.Message);
            }
        }
    }
}
