using Negocio;
using Negocio.Categorias;
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

namespace Interfaz.Contrasenias
{
    public partial class ModificarPasswordVentana : Form
    {
        private Contrasenia Contrasenia;
        private Sesion Sesion;
        public ModificarPasswordVentana(Contrasenia contrasenia)
        {
            InitializeComponent();

            Sesion = Sesion.Singleton;
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
    }
}
