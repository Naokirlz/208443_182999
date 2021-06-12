using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class CargarFuenteVulnerabilidades : UserControl
    {
        Sesion Sesion = Sesion.ObtenerInstancia();
        public CargarFuenteVulnerabilidades()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (txtRutaArchivo.Text != "")
            {
                //Sesion.CargarArchivo(String ruta);
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
