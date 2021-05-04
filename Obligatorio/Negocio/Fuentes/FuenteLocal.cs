using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FuenteLocal : IFuente
    {
        public List<string> ContraseniasYTarjetasVulnerables { get; set; }
        public int Id { get; set; }
        public FuenteLocal()
        {
            ContraseniasYTarjetasVulnerables = new List<string>();
        }

        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            int cantidadAparaceEnFuente = 0;

            foreach (var item in ContraseniasYTarjetasVulnerables)
            {
                if (item.Equals(buscado))
                {
                    cantidadAparaceEnFuente++;
                }
            }
            return cantidadAparaceEnFuente;
        }


        public void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable)
        {
            ContraseniasYTarjetasVulnerables.Add(passwordOContraseniaVulnerable);
        }


    }
}
