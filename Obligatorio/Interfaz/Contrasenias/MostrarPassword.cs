using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.InterfacesGUI;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Interfaz.Contrasenias
{
    public partial class MostrarPassword : Form
    {
        private Contrasenia Contrasenia;
        private IContrasenia Sesion;
        private MostrarPassword.enmAccion Accion;
        public MostrarPassword(Contrasenia contrasenia)
        {
            InitializeComponent();
            Sesion = new ContraseniaGUI();
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
        //Codigo utilizado para mover el formulario.
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
