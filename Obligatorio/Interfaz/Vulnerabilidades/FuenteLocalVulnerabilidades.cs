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

            bool encontre = false;
            foreach (IFuente fuente in Sesion.MisFuentes)
            {
                string tipoFuente = fuente.GetType().ToString();
                if (tipoFuente == "Negocio.FuenteLocal")
                {
                    this.FuenteLocal = fuente;
                    encontre = true;
                }
            }

            if (!encontre)
            {
                this.FuenteLocal = new FuenteLocal();
                this.Sesion.MisFuentes.Add(this.FuenteLocal);
            }
            //bool encontre = false;
            //foreach (IFuente fuente in Sesion.MisFuentes)
            //{
            //    string tipoFuente = fuente.GetType().ToString();
            //    if (tipoFuente == "Negocio.FuenteLocal")
            //    {
            //        this.FuenteLocal = fuente;
            //        encontre = true;
            //    }
            //}

            //if (!encontre)
            //{
            //    this.FuenteLocal = new FuenteLocal();
            //    this.Sesion.MisFuentes.Add(this.FuenteLocal);
            //}

            if (!encontre)
            {
                this.FuenteLocal = new FuenteLocal();
                this.Sesion.MisFuentes.Add(this.FuenteLocal);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.txtEntradaFuenteLocal.Text.Length > 32767)
            {
                Alerta("El texto ha superado el límite de caracteres.", AlertaToast.enmTipo.Error);
            }
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
