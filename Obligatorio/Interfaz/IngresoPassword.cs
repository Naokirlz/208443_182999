using Negocio;
using Negocio.Contrasenias;
using Negocio.Utilidades;
using System;
using System.Runtime.InteropServices;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
