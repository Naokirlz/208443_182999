using Interfaz.Alertas;
using Negocio.DataBreaches;
using Negocio.InterfacesGUI;
using System;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class CargarFuenteVulnerabilidades : UserControl
    {
        IVulnerabilidades sesion = new VulnerabilidadesGUI();
        public CargarFuenteVulnerabilidades()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (txtRutaArchivo.Text != "")
            {
                IFuente fuenteArchivo = new FuenteArchivo();
                sesion.CargarDataBreach(fuenteArchivo, txtRutaArchivo.Text);
                Alerta("El archivo ha sido cargado con éxito!", AlertaToast.enmTipo.Exito);
                txtRutaArchivo.Text = "";
            }
            else
            {
                Alerta("Debe seleccionar un archivo!", AlertaToast.enmTipo.Error);
            }
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            if (ofdSeleccionarArchivo.ShowDialog() == DialogResult.OK)
            {
                 txtRutaArchivo.Text = ofdSeleccionarArchivo.FileName;
            }
        }
        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }
    }
}
