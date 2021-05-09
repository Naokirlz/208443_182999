using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
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

namespace Interfaz.Contrasenias
{
    public partial class AgregarContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        public AgregarContrasenias()
        {
            InitializeComponent();
            Refrescar();
        }
        private void Refrescar()
        {
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.GestorCategoria.ObtenerTodas();
            this.cmbCategoria.DataSource = bSource;
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
                string sitio = this.txtSitio.Text;
                string usuario = this.txtUsuario.Text;
                string notas = this.txtNotas.Text;
                string password = this.txtPassword.Text;

                Contrasenia nuevaContrasenia = new Contrasenia()
                {
                    Sitio = sitio,
                    Categoria = categoria,
                    Usuario = usuario,
                    Notas = notas,
                    Password = new Password(password),
                };

                this.Sesion.AltaContrasenia(nuevaContrasenia);
                Alerta("Contraseña guardada con éxito!!", AlertaToast.enmTipo.Exito);
                LimpiarCampos();
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
                MessageBox.Show(unaExcepcion.Message);
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                Alerta(unaExcepcion.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
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
            Password password = new Password("")
            {
                Largo = largo,
                Mayuscula = mayusculas,
                Minuscula = minusculas,
                Numero = digitos,
                Especial = especiales
            };

            password.GenerarPassword();
            this.txtPassword.Text = password.Clave;
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
