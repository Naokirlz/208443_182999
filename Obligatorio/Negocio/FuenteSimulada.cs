using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FuenteSimulada : IFuente
    {
        public List<string> ContraseniasYTarjetasVulnerables { get; set; }

        public FuenteSimulada()
        {

            ContraseniasYTarjetasVulnerables = new List<string>();

        }


        public bool Buscar(string buscado)
        {
            foreach (var item in ContraseniasYTarjetasVulnerables)
            {
                if (item.Equals(buscado))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
