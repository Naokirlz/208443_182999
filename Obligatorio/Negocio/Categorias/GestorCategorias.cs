using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.Categorias
{
    public class GestorCategorias
    {
        private RepositorioCategorias repositorio;

        public GestorCategorias()
        {
            this.repositorio = new RepositorioCategorias();
        }

        public int Alta(string nombre)
        {
            Validaciones.ValidarLargoTexto(nombre, 15, 3, "nombre");
            return repositorio.Alta(nombre);
        }

        public void Baja(int id)
        {
            repositorio.Baja(id);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            Validaciones.ValidarLargoTexto(nombreNuevo, 15, 3 , "nombre");
            repositorio.ModificarCategoria(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return repositorio.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return repositorio.ObtenerTodasLasCategorias();
        }

    }
}
