using System.Collections.Generic;

namespace Negocio.Utilidades
{
    public class FuenteLocal : IFuente
    {
        public List<string> ContraseniasYTarjetasVulnerables { get; set; }
        public FuenteLocal()
        {
            ContraseniasYTarjetasVulnerables = new List<string>();
        }

        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            int cantidadAparaceEnFuente = 0;
            foreach (var item in ContraseniasYTarjetasVulnerables)
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
            ContraseniasYTarjetasVulnerables.Add(passwordOContraseniaVulnerable);
        }


    }
}
