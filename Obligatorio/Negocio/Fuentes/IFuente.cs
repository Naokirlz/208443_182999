﻿
namespace Negocio
{
    public interface IFuente
    {
        int BuscarPasswordOContraseniaEnFuente(string buscado);
        void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable);

    }
}
