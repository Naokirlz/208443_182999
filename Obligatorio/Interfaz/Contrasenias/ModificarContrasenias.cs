using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Utilidades;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class ModificarContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.ObtenerInstancia();
        public ModificarContrasenias()
        {
            InitializeComponent();
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
            Contrasenia contraseniaSeleccionada = (Contrasenia)this.cmbContrasenia.SelectedItem;
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
                    Id = contraseniaSeleccionada.Id
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
    }
}
