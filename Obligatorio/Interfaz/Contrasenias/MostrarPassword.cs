using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
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
    public partial class MostrarPassword : Form
    {
        private Contrasenia Contrasenia;
        private Sesion Sesion;
        private MostrarPassword.enmAccion Accion;
        public MostrarPassword(Contrasenia contrasenia)
        {
            InitializeComponent();
            Sesion = Sesion.Singleton;
            BindingList<Categoria> bindinglist = new BindingList<Categoria>();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = this.Sesion.ObtenerTodasLasCategorias();
            this.cmbCategoria.DataSource = bSource;

            this.Opacity = 0.0;
            Contrasenia = contrasenia;
            this.cmbCategoria.SelectedItem = Contrasenia.Categoria;
            this.txtSitio.Text = Contrasenia.Sitio;
            this.txtUsuario.Text = Contrasenia.Usuario;
            this.txtNotas.Text = Contrasenia.Notas;
            this.txtPassword.Text = Sesion.MostrarPassword(Contrasenia);

            this.Show();
            this.Accion = enmAccion.iniciar;
            timMuestra.Interval = 1;
            timMuestra.Start();
        }

        public enum enmAccion
        {
            esperar,
            iniciar,
            cerrar
        }

        private void timMuestra_Tick(object sender, EventArgs e)
        {
            switch (this.Accion)
            {
                case enmAccion.esperar:
                    timMuestra.Interval = 30000;
                    Accion = enmAccion.cerrar;
                    break;
                case enmAccion.iniciar:
                    timMuestra.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.Opacity == 1.0)
                    {
                        Accion = enmAccion.esperar;
                    }
                    break;
                case enmAccion.cerrar:
                    timMuestra.Interval = 1;
                    this.Opacity -= 0.1;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            timMuestra.Interval = 1;
            Accion = enmAccion.cerrar;
        }
    }
}
