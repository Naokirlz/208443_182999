using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Interfaz.Categorias;
using Interfaz.Contrasenias;
using Interfaz.TarjetasCredito;
using Interfaz.Vulnerabilidades;
using Negocio;

namespace Interfaz
{
    public partial class MenuPrincipal : Form
    {
        private Sesion Sesion = Sesion.ObtenerInstancia();

        private IconButton BotonSeleccionado;
        private Panel BordeIzquierdoDelBoton;

        public MenuPrincipal()
        {
            InitializeComponent();
            BordeIzquierdoDelBoton = new Panel();
            BordeIzquierdoDelBoton.Size = new Size(7, 60);
            pnlMenuLateral.Controls.Add(BordeIzquierdoDelBoton);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            imgIconoCentral.Visible = false;
            BotonActivo(sender, RGBColores.Color1);
            lblTitulo.Text = "Categorías";
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorCategorias = new GestionCategorias();
            pnlPanelPrincipal.Controls.Add(gestorCategorias);
        }

        private void btnTarjetaCredito_Click(object sender, EventArgs e)
        {
            imgIconoCentral.Visible = false;
            BotonActivo(sender, RGBColores.Color3);
            lblTitulo.Text = "Tarjetas de Crédito";
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorTarjetas = new GestionTarjetas();
            pnlPanelPrincipal.Controls.Add(gestorTarjetas);
        }

        private void btnVulnerabiliadades_Click(object sender, EventArgs e)
        {
            imgIconoCentral.Visible = false;
            BotonActivo(sender, RGBColores.Color4);
            lblTitulo.Text = "Vulnerabilidades";
            pnlPanelPrincipal.Controls.Clear();
            UserControl gestorVulnerabilidades = new GestionVulnerabilidades();
            pnlPanelPrincipal.Controls.Add(gestorVulnerabilidades);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            imgIconoCentral.Visible = false;
            BotonActivo(sender, RGBColores.Color5);
            lblTitulo.Text = "Configuración";
            pnlPanelPrincipal.Controls.Clear();
            UserControl configuracion = new Configuracion();
            pnlPanelPrincipal.Controls.Add(configuracion);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            VentanaConfirmarBool confirmacion = new VentanaConfirmarBool("Realmente desea salir?");
            confirmacion.Show();
            bool respuesta = confirmacion.Respuesta;
            confirmacion.Close();
            if (respuesta)
            {
                BotonActivo(sender, RGBColores.Color6);
                Sesion.LogOut();
                InicioSesion pantallaLogin = new InicioSesion();
                this.Hide();
                pantallaLogin.Show();
            }
        }
        private void btnEscritorio_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }
        private void Reiniciar()
        {
            pnlPanelPrincipal.Controls.Clear();
            BotonInactivo();
            BordeIzquierdoDelBoton.Visible = false;
            icoFormulariuoActivo.IconChar = IconChar.Home;
            icoFormulariuoActivo.IconColor = Color.MediumPurple;
            lblTitulo.Text = "Inicio";
            imgIconoCentral.BringToFront();
            imgIconoCentral.Visible = true;
        }
        private void btnContrasenias_Click(object sender, EventArgs e)
        {
            imgIconoCentral.Visible = false;
            BotonActivo(sender, RGBColores.Color2);
            lblTitulo.Text = "Contraseñas";
            pnlPanelPrincipal.Controls.Clear();
            UserControl contrasenias = new GestionContrasenias();
            pnlPanelPrincipal.Controls.Add(contrasenias);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void BotonActivo(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                BotonInactivo();
                BotonSeleccionado = (IconButton)senderBtn;
                BotonSeleccionado.BackColor = Color.FromArgb(37, 36, 81);
                BotonSeleccionado.ForeColor = color;
                BotonSeleccionado.TextAlign = ContentAlignment.MiddleCenter;
                BotonSeleccionado.IconColor = color;
                BotonSeleccionado.TextImageRelation = TextImageRelation.TextBeforeImage;
                BotonSeleccionado.ImageAlign = ContentAlignment.MiddleRight;

                BordeIzquierdoDelBoton.BackColor = color;
                BordeIzquierdoDelBoton.Location = new Point(0, BotonSeleccionado.Location.Y);
                BordeIzquierdoDelBoton.Visible = true;
                BordeIzquierdoDelBoton.BringToFront();

                icoFormulariuoActivo.IconChar = BotonSeleccionado.IconChar;
                icoFormulariuoActivo.IconColor = color;
                lblTitulo.Text = BotonSeleccionado.Text;
            }
        }
        private void BotonInactivo()
        {
            if (BotonSeleccionado != null)
            {
                BotonSeleccionado.BackColor = Color.FromArgb(31, 30, 68);
                BotonSeleccionado.ForeColor = Color.Gainsboro;
                BotonSeleccionado.TextAlign = ContentAlignment.MiddleLeft;
                BotonSeleccionado.IconColor = Color.Gainsboro;
                BotonSeleccionado.TextImageRelation = TextImageRelation.ImageBeforeText;
                BotonSeleccionado.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private struct RGBColores
        {
            public static Color Color1 = Color.FromArgb(172, 126, 241);
            public static Color Color2 = Color.FromArgb(249, 118, 176);
            public static Color Color3 = Color.FromArgb(253, 138, 114);
            public static Color Color4 = Color.FromArgb(95, 77, 221);
            public static Color Color5 = Color.FromArgb(249, 88, 155);
            public static Color Color6 = Color.FromArgb(24, 161, 251);
        }
        //Para mover el formulario por el evento del mouse.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
