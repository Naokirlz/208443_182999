using System.Collections.Generic;
using Negocio.Categorias;

namespace Negocio.TarjetaCreditos
{
    public class GestorTarjetaCredito 
    {
        public RepositorioTarjetaCredito Repositorio;
      
        public GestorTarjetaCredito()
        {
            this.Repositorio = new RepositorioTarjetaCredito();
        }

        public int Alta(TarjetaCredito unaTarjeta)
        {
            ValidarCampos(unaTarjeta);
            return Repositorio.Alta(unaTarjeta);
        }

        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            ValidarCampos(modificada);
            Repositorio.ModificarTarjeta(modificada);
        }

        public TarjetaCredito Buscar(int id)
        {
            return Repositorio.BuscarPorId(id);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            return Repositorio.ObtenerTodas();
        }

        private void ValidarCampos(TarjetaCredito tarjeta)
        {
            CategoriaExiste(tarjeta.Categoria);
            Validaciones.ValidarLargoTexto(tarjeta.Nombre, 25, 3, "nombre");
            Validaciones.ValidarLargoTexto(tarjeta.Tipo, 25, 3, "tipo");
            Validaciones.ValidarLargoTexto(tarjeta.Numero, 16, 16, "número");
            Validaciones.ValidarSoloNumeros(tarjeta.Numero);
            Validaciones.ValidarLargoTexto(tarjeta.Codigo, 3, 3, "código");
            Validaciones.ValidarSoloNumeros(tarjeta.Codigo);
            Validaciones.ValidarLargoTexto(tarjeta.Nota,  250,-1, "nota");
         
        }

        private bool CategoriaExiste(Categoria categoria)
        {
            //buscar categoria en lista de categorias existentes
            return true;
        }

   

       
    }
}
