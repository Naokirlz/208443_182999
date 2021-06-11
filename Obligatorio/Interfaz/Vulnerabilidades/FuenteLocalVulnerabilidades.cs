using Negocio;
using Negocio.Utilidades;
using System;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class FuenteLocalVulnerabilidades : UserControl
    {
        Sesion Sesion = Sesion.ObtenerInstancia();
        IFuente FuenteLocal;
        public FuenteLocalVulnerabilidades()
        {
            InitializeComponent();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.txtEntradaFuenteLocal.Text.Length > 32767)
            {

                Alerta("El texto ha superado el límite de caracteres.", AlertaToast.enmTipo.Error);
            }
            
            Fuente fuente = new FuenteLocal();
            fuente.CrearDatabreach(txtEntradaFuenteLocal.Text);
            
            this.txtEntradaFuenteLocal.Text = "";
            Alerta("La lista ha sido guardada con éxito!", AlertaToast.enmTipo.Exito);
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
