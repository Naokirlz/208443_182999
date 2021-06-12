using System.Collections.Generic;

namespace Negocio.Utilidades
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

        public void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable)
        {
            if(passwordOContraseniaVulnerable.Length > 50) 
            {
                throw new ExcepcionLargoTexto("El largo de texto debe ser menor a 50 caracteres.");
            }
            contraseniasYTarjetasVulnerables.Add(passwordOContraseniaVulnerable);
        }


    }
}
