using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class FuenteArchivo : IFuente
    {
        private List<string> contraseniasYTarjetasVulnerables;

        public void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable)
        {
            throw new NotImplementedException();
        }

        public int BuscarPasswordOContraseniaEnFuente(string buscado)
        {
            throw new NotImplementedException();
        }
    }
}
