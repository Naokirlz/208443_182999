using Negocio;
using Negocio.Utilidades;
using System;
using System.Windows.Forms;

namespace Interfaz.Vulnerabilidades
{
    public partial class FuenteLocalVulnerabilidades : UserControl
    {
        Sesion Sesion = Sesion.Singleton;
        IFuente FuenteLocal;
        public FuenteLocalVulnerabilidades()
        {
            InitializeComponent();
            //acá debería buscar si alguna de las fuentes es la fuente local, y a esa le pongo el contenido
            //esto tiene que ser de sesión
            

            //acá agrego lo de fuente local, que siempre debería aparecer
            //si tengo más fuentes las agrego en la ventana de validación, con la lista de fuentes que tenga

            //esto sacarlo después
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
                    if (!EsNumero(digito)) soloNum = false;
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

        public static bool EsNumero(char digito)
        {
            int convertido = Convert.ToInt32(digito);

            if (convertido > 57) return false;
            else if (convertido < 48) return false;
            return true;

        }
    }
}
