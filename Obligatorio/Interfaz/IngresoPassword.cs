using Negocio;
using Negocio.Contrasenias;
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
    public partial class IngresoPassword : Form
    {
        private Contrasenia Contrasenia;
        private Sesion Sesion;
        public IngresoPassword(Contrasenia contrasenia)
        {
            InitializeComponent();
            Sesion = Sesion.Singleton;
            this.Contrasenia = contrasenia;
            this.txtPassword.Text = Sesion.MostrarPassword(Contrasenia);

            this.ShowDialog(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Password nuevoPass = new Password(this.txtPassword.Text);
                Contrasenia aModificar = new Contrasenia()
                {
                    Categoria = Contrasenia.Categoria,
                    Sitio = Contrasenia.Sitio,
                    Usuario = Contrasenia.Usuario,
                    Notas = Contrasenia.Notas,
                    Password = nuevoPass,
                    Id = Contrasenia.Id
                };

                this.Sesion.ModificarContrasenia(aModificar);
                Alerta("Contraseña modificada con éxito!!", AlertaToast.enmTipo.Exito);
                this.Close();
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
            catch (ExcepcionElementoNoExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
