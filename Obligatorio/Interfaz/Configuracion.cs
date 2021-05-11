using Negocio;
using Negocio.Utilidades;
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
    public partial class Configuracion : UserControl
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string passwordInicial = this.txtPassword.Text;
            string passwordRepetido = this.txtRepetirPassword.Text;
            try
            {
                if (passwordInicial != passwordRepetido)
                {
                    Alerta("Los passwords deben coincidir.", AlertaToast.enmTipo.Error);
                    return;
                }
                Sesion sesion = Sesion.Singleton;
                sesion.CambiarPassword(passwordRepetido);
                this.txtPassword.Text = "";
                this.txtRepetirPassword.Text = "";
                Alerta("Los cambios fueron configurados con éxito", AlertaToast.enmTipo.Exito);
            }
            catch (ExcepcionLargoTexto errorLargoTexto)
            {
                Alerta(errorLargoTexto.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
