using Negocio;
using Negocio.Utilidades;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class VentanaConfirmar : Form
    {
        private Sesion Sesion = Sesion.Singleton;
        private int Id;
        public string MsgConfirmación { get; set; }
        public string MsgPregunta { get; set; }

        private Action<int> Accion;
        public VentanaConfirmar(int id, Action<int> accion)
        {
            InitializeComponent();
            this.Id = id;
            this.Accion = accion;
        }
        public void CargarFormulario()
        {
            if (MsgPregunta != null)
            {
                lblPregunta.Text = MsgPregunta;
            }
            else
            {
                lblPregunta.Text = "Realmente desea realizar esta acción??";
            }
            this.ShowDialog();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            try
            {
                Accion(Id);
                if (MsgConfirmación != null)
                {
                    Alerta(MsgConfirmación, AlertaToast.enmTipo.Exito);
                }
                else
                {
                    Alerta("El elemnto fue borrado con éxito!!", AlertaToast.enmTipo.Exito);
                }
                this.Close();
            }
            catch(ExcepcionElementoNoExiste excepcion)
            {
                Alerta(excepcion.Message, AlertaToast.enmTipo.Error);
            }
        }
        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
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
    }
}
