using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz.Alertas
{
    public partial class AlertaToast : Form
    {
        private AlertaToast.enmAccion Accion;
        private int PoscionX, PosicionY;
        public AlertaToast()
        {
            InitializeComponent();
        }
        public void MostrarAlerta(string mensaje, enmTipo tipo)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fnombre;

            for(int form = 0; form<10; form++)
            {
                fnombre = "alerta" + form.ToString();
                AlertaToast alerta = (AlertaToast)Application.OpenForms[fnombre];

                if (alerta == null)
                {
                    this.Name = fnombre;
                    this.PoscionX = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.PosicionY = Screen.PrimaryScreen.WorkingArea.Height - 100 - this.Height * form - 5*form;
                    this.Location = new Point(this.PoscionX, this.PosicionY);
                    break;
                }
            }

            this.PoscionX = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (tipo)
            {
                case enmTipo.Exito:
                    this.icoIcono.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    this.icoIcono.IconColor = Color.DarkGreen;
                    this.BackColor = Color.LightGreen;
                    this.lblMensaje.ForeColor = Color.DarkGreen;
                    this.btnCerrar.IconColor = Color.DarkGreen;
                    break;
                case enmTipo.Error:
                    this.icoIcono.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    this.icoIcono.IconColor = Color.White;
                    this.BackColor = Color.Red;
                    this.lblMensaje.ForeColor = Color.White;
                    this.btnCerrar.IconColor = Color.White;
                    break;
                case enmTipo.Advertencia:
                    this.icoIcono.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    this.icoIcono.IconColor = Color.White;
                    this.BackColor = Color.Orange;
                    this.lblMensaje.ForeColor = Color.White;
                    this.btnCerrar.IconColor = Color.White;
                    break;
            }

            this.lblMensaje.Text = mensaje;

            this.Show();
            this.Accion = enmAccion.iniciar;
            timTransicion.Interval = 1;
            timTransicion.Start();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            timTransicion.Interval = 1;
            Accion = enmAccion.cerrar;
        }
        private void timTransicion_Tick(object sender, EventArgs e)
        {
            switch (this.Accion)
            {
                case enmAccion.esperar:
                    timTransicion.Interval = 5000;
                    Accion = enmAccion.cerrar;
                    break;
                case enmAccion.iniciar:
                    timTransicion.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.PoscionX < this.Location.X)
                    {
                        this.Left --;
                    }
                    else
                    {
                        if (this.Opacity == 1)
                        {
                            Accion = enmAccion.esperar;
                        }
                    }
                    break;
                case enmAccion.cerrar:
                    timTransicion.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        public enum enmAccion
        {
            esperar,
            iniciar,
            cerrar
        }
        public enum enmTipo
        {
            Exito,
            Error,
            Advertencia
        }
    }
}
