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
    public partial class ModificarContrasenias : UserControl
    {
        private Sesion Sesion = Sesion.Singleton;
        public ModificarContrasenias()
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

            BindingList<Contrasenia> bindinglist2 = new BindingList<Contrasenia>();
            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = this.Sesion.ObtenerTodasLasCategorias();
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
                    MessageBox.Show("Seleccione al menos una categoría");
                    return;
                }

                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    MessageBox.Show("Seleccione al menos una categoría");
                    return;
                }

                contraseniaSeleccionada.Sitio = this.txtSitio.Text;
                contraseniaSeleccionada.Usuario = this.txtUsuario.Text;
                contraseniaSeleccionada.Notas = this.txtNotas.Text;
                contraseniaSeleccionada.Password.Clave = this.txtPassword.Text;

                this.Sesion.GestorContrasenia.ModificarContrasenia(contraseniaSeleccionada);
                MessageBox.Show("Contraseña " + contraseniaSeleccionada + " fue modificada con éxito!!");
                LimpiarCampos();
                Refrescar();
            }
            catch (ExcepcionElementoYaExiste unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
            }
            catch (ExcepcionLargoTexto unaExcepcion)
            {
                MessageBox.Show(unaExcepcion.Message);
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
                MessageBox.Show("Seleccione al menos una tipo de Caracter");
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
    }
}
