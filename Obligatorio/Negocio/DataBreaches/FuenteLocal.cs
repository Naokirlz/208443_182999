
using System.Collections.Generic;

namespace Negocio.DataBreaches
{
    public class FuenteLocal : IFuente
    {
        private List<string> contraseniasYTarjetasVulnerables;

        public FuenteLocal()
        {
            contraseniasYTarjetasVulnerables = new List<string>();
        }

        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            int cantidadAparaceEnFuente = 0;
            foreach (var item in contraseniasYTarjetasVulnerables)
            {
                if (item.Equals(buscado)) cantidadAparaceEnFuente++;
            }
            return cantidadAparaceEnFuente;
        }

        public void CrearDataBreach(string passwordsOContraseniasVulnerables)
        {
            string[] fuentes = passwordsOContraseniasVulnerables.Split('\n');

            foreach (string fila in fuentes)
            {
                string texto = fila.TrimEnd('\r');

                string sinEspacios = texto.Replace(" ", "");
                bool soloNum = true;
                foreach (char digito in sinEspacios)
                {
                    if (!Validaciones.EsNumero(digito)) soloNum = false;
                }
                if (soloNum) texto = sinEspacios;

                this.contraseniasYTarjetasVulnerables.Add(texto);
            }
        }


    }
}
