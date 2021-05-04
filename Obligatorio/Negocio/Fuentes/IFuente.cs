using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface IFuente
    {
        int Id { get; set; }

        int BuscarPasswordOContraseniaEnFuente(string buscado);
        void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable);

    }
}
