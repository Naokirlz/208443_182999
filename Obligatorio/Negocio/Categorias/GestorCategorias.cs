using System.Collections.Generic;

namespace Negocio.Categorias
{
    public class GestorCategorias
    {
        public RepositorioCategorias Repositorio;

        public GestorCategorias()
        {
            this.Repositorio = new RepositorioCategorias();
        }

        public int Alta(string nombre)
        {
            Validaciones.ValidarLargoTexto(nombre, 15, 3, "nombre");
            return Repositorio.Alta(nombre);
        }

        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            Validaciones.ValidarLargoTexto(nombreNuevo, 15, 3 , "nombre");
            Repositorio.ModificarCategoria(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return Repositorio.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodas()
        {
            return Repositorio.ObtenerTodasLasCategorias();
        }

    }
}
