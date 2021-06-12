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
            
            Sesion.Fuente = new FuenteLocal();
            FuenteLocal = Sesion.Fuente;
            string[] fuentes = this.txtEntradaFuenteLocal.Text.Split('\n');
            
            foreach(string fila in fuentes)
            {
                string texto = fila.TrimEnd('\r');
                
                string sinEspacios = texto.Replace(" ", "");
                bool soloNum = true;
                foreach (char digito in sinEspacios)
                {
                    if (!Validaciones.EsNumero(digito)) soloNum = false;
                }
                if (soloNum) texto = sinEspacios;

                FuenteLocal.AgregarPasswordOContraseniaVulnerable(texto);
            }
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
