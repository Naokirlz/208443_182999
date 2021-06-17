using Interfaz.Alertas;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.InterfacesGUI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ModificarContrasenias : UserControl
    {
        private IContrasenia Sesion = new ContraseniaGUI();
        private Contrasenia contraseniaSeleccionada;
        public ModificarContrasenias()
        {
            InitializeComponent();
            lblContrasenaInsegura.Visible = false;
            lblContrasenaFiltrada.Visible = false;
            lblContrasenaRepetida.Visible = false;
            Refrescar();
        }
        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            BindingList<Contrasenia> bindinglist2 = new BindingList<Contrasenia>();
            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = this.Sesion.ObtenerTodasLasContrasenias();
            this.cmbContrasenia.DataSource = bSource2;

            CargarDatosContrasenia();
        }

        private void CargarDatosContrasenia()
        {
            this.contraseniaSeleccionada = (Contrasenia)this.cmbContrasenia.SelectedItem;
            if (contraseniaSeleccionada != null)
            {
                this.cmbCategoria.SelectedItem = contraseniaSeleccionada.Categoria;
                this.txtSitio.Text = contraseniaSeleccionada.Sitio;
                this.txtUsuario.Text = contraseniaSeleccionada.Usuario;
                this.txtNotas.Text = contraseniaSeleccionada.Notas;
                this.txtPassword.Text = Sesion.MostrarPassword(contraseniaSeleccionada);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Contrasenia contraseniaSeleccionada = (Contrasenia)this.cmbContrasenia.SelectedItem;
                if (contraseniaSeleccionada == null)
                {
                    Alerta("Seleccione al menos una contraseña", AlertaToast.enmTipo.Error);
                    return;
                }

                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    Alerta("Seleccione al menos una categoría", AlertaToast.enmTipo.Error);
                    return;
                }
                Password nuevoPass = new Password(this.txtPassword.Text);
                Contrasenia aModificar = new Contrasenia() {
                    Categoria = (Categoria)cmbCategoria.SelectedItem,
                    Sitio = this.txtSitio.Text,
                    Usuario = this.txtUsuario.Text,
                    Notas = this.txtNotas.Text,
                    Password = nuevoPass,
                    ContraseniaId = contraseniaSeleccionada.ContraseniaId
                };

                this.Sesion.ModificarContrasenia(aModificar);
                Alerta("Contraseña " + aModificar + " fue modificada con éxito!!", AlertaToast.enmTipo.Exito);
                LimpiarCampos();
                Refrescar();
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

        private void LimpiarCampos()
        {
            this.txtNotas.Text = "";
            this.txtSitio.Text = "";
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
            this.numLargo.Value = 5;
            this.chkDigitos.Checked = false;
            this.chkMayusculas.Checked = false;
            this.chkMinusculas.Checked = false;
            this.chkEspeciales.Checked = false;
            this.lblContrasenaFiltrada.Text = "";
            this.lblContrasenaInsegura.Text = "";
            this.lblContrasenaRepetida.Text = "";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bool mayusculas = this.chkMayusculas.Checked;
            bool minusculas = this.chkMinusculas.Checked;
            bool digitos = this.chkDigitos.Checked;
            bool especiales = this.chkEspeciales.Checked;
            int largo = (int)this.numLargo.Value;
            if (!mayusculas && !minusculas && !digitos && !especiales)
            {
                Alerta("Seleccione al menos una tipo de Caracter", AlertaToast.enmTipo.Error);
                return;
            }
            
            Password nuevo = new Password("")
            {
                Largo = largo,
                Mayuscula = mayusculas,
                Minuscula = minusculas,
                Numero = digitos,
                Especial = especiales
            };
            
            nuevo.GenerarPassword();
            this.txtPassword.Text = nuevo.Clave;
        }

        private void cmbContrasenia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosContrasenia();
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
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
            if (password.Equals(Sesion.MostrarPassword(contraseniaSeleccionada))){
                vecesRepetido--;
            }
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
