using Interfaz.Alertas;
using Negocio.DataBreaches;
using Negocio.InterfacesGUI;
using System;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class FuenteLocalVulnerabilidades : UserControl
    {
        private IVulnerabilidades Sesion = new VulnerabilidadesGUI();
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
            IFuente fuenteLocal = new FuenteLocal();
            Sesion.CargarDataBreach(fuenteLocal, this.txtEntradaFuenteLocal.Text);
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
