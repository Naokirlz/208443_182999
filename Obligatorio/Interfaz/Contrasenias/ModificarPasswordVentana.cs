using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Utilidades;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ModificarPasswordVentana : Form
    {
        private Contrasenia Contrasenia;
        private Sesion Sesion;
        public ModificarPasswordVentana(Contrasenia contrasenia)
        {
            InitializeComponent();

            Sesion = Sesion.ObtenerInstancia();
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            this.Contrasenia = contrasenia;

            this.cmbCategoria.SelectedItem = Contrasenia.Categoria;
            this.txtSitio.Text = Contrasenia.Sitio;
            this.txtUsuario.Text = Contrasenia.Usuario;
            this.txtNotas.Text = Contrasenia.Notas;
            this.txtPassword.Text = Sesion.MostrarPassword(Contrasenia);

            this.ShowDialog();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                    return;
                }
                Password nuevoPass = new Password(this.txtPassword.Text);
                Contrasenia aModificar = new Contrasenia()
                {
                    Categoria = (Categoria)cmbCategoria.SelectedItem,
                    Sitio = this.txtSitio.Text,
                    Usuario = this.txtUsuario.Text,
                    Notas = this.txtNotas.Text,
                    Password = nuevoPass,
                    Id = Contrasenia.Id
                };

                this.Sesion.ModificarContrasenia(aModificar);
                Alerta("Contraseña modificada con éxito!!", AlertaToast.enmTipo.Exito);
                this.Close();
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar.Equals('•'))
            {
                txtPassword.PasswordChar = '\0';
                btnMostrar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }
    }
}
