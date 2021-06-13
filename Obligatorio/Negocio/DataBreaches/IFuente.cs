namespace Negocio.DataBreaches
{
    public interface IFuente
    {
        int BuscarPasswordOContraseniaEnFuente(string buscado);
        void CrearDataBreach(string dataBreach);

    }
}
