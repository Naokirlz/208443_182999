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
            bSource.DataSource = this.Sesion.GestorCategoria.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bool mayusculas = this.chkMayusculas.Checked;
            bool minusculas = this.chkMinusculas.Checked;
            bool digitos = this.chkDigitos.Checked;
            bool especiales = this.chkEspeciales.Checked;
            int largo = (int)this.numLargo.Value;
            if(!mayusculas && !minusculas && !digitos && !especiales)
            {
                MessageBox.Show("Seleccione al menos una tipo de Caracter");
                return;
            }
            string password = Sesion.GestorContrasenia.GenerarPassword(largo, mayusculas, minusculas, digitos, especiales);
            this.txtPassword.Text = password;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = (Categoria)this.cmbCategoria.SelectedItem;
                if (categoria == null)
                {
                    MessageBox.Show("Seleccione al menos una categoría");
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
                    Password = password,
                };

                this.Sesion.GestorContrasenia.Alta(nuevaContrasenia);
                MessageBox.Show("Contraseña " + nuevaContrasenia + " fue guardada con éxito!!");
                LimpiarCampos();
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
    }
}
