using Interfaz.Alertas;
using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ModificarPasswordVentana : Form
    {
        private Contrasenia Contrasenia;
        private IContrasenia Sesion;
        public ModificarPasswordVentana(Contrasenia contrasenia)
        {
            InitializeComponent();
            lblContrasenaInsegura.Visible = false;
            lblContrasenaFiltrada.Visible = false;
            lblContrasenaRepetida.Visible = false;

            Sesion = new ContraseniaGUI();
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            this.lblContrasenaFiltrada.Text = "";
            this.lblContrasenaInsegura.Text = "";
            this.lblContrasenaRepetida.Text = "";

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
                    ContraseniaId = Contrasenia.ContraseniaId
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            VerificarFortalezaPassword();
            VerificarPasswordsRepetidos();
            VerificarPasswordsFiltrados();
        }
        private void VerificarPasswordsFiltrados()
        {
            string password = this.txtPassword.Text;
            int vecesFiltrado = Sesion.VerificarPasswordFiltrado(password);
            this.lblContrasenaFiltrada.Visible = true;
            if (vecesFiltrado == 0)
            {
                lblContrasenaFiltrada.Text = "La Contraseña no ha sido filtrada.";
                lblContrasenaFiltrada.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblContrasenaFiltrada.Text = "La Contraseña se ha filtrado " + vecesFiltrado.ToString() + " veces.";
                lblContrasenaFiltrada.ForeColor = Color.Red;
            }
        }
        private void VerificarPasswordsRepetidos()
        {
            string password = this.txtPassword.Text;
            int vecesRepetido = Sesion.VerificarCatidadVecesPasswordRepetido(password);
            if (vecesRepetido == 0)
            {
                this.lblContrasenaRepetida.Visible = true;
                lblContrasenaRepetida.Text = "La Contraseña no es repetida.";
                lblContrasenaRepetida.ForeColor = Color.DarkGreen;
            }
            else
            {
                this.lblContrasenaRepetida.Visible = true;
                lblContrasenaRepetida.Text = "La Contraseña se repite " + vecesRepetido.ToString() + " veces.";
                lblContrasenaRepetida.ForeColor = Color.Red;
            }
        }
        private void VerificarFortalezaPassword()
        {
            string password = this.txtPassword.Text;
            lblContrasenaInsegura.Visible = true;
            string fortaleza = Sesion.VerificarFortalezaPassword(password).ToString();
            if (fortaleza.Equals("VERDE_OSCURO"))
            {
                lblContrasenaInsegura.Text = "La Contraseña es segura.";
                lblContrasenaInsegura.ForeColor = Color.DarkGreen;
            }
            else if (fortaleza.Equals("VERDE_CLARO"))
            {
                lblContrasenaInsegura.Text = "La Contraseña podría ser más segura.";
                lblContrasenaInsegura.ForeColor = Color.Green;
            }
            else if (fortaleza.Equals("AMARILLO"))
            {
                lblContrasenaInsegura.Text = "La Contraseña tiene cierta seguridad.";
                lblContrasenaInsegura.ForeColor = Color.Yellow;
            }
            else if (fortaleza.Equals("NARANJA"))
            {
                lblContrasenaInsegura.Text = "La Contraseña no es segura.";
                lblContrasenaInsegura.ForeColor = Color.Orange;
            }
            else
            {
                lblContrasenaInsegura.Text = "La Contraseña es muy insegura.";
                lblContrasenaInsegura.ForeColor = Color.Red;
            }
        }
    }
}
