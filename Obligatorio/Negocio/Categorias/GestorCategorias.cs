using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ValidarCategoria(nombre);

            if (ExisteNombreCategoria(nombre)) 
            { 
                throw new ExcepcionElementoYaExiste(); 
            }
            return Repositorio.Alta(nombre);
        }

        public void Baja(int id)
        {
            BuscarCategoriaPorId(id);
            Repositorio.Baja(id);
        }

        public void Modificacion(int id, string nombreNuevo)
        {
            ValidarCategoria(nombreNuevo);

            if (ExisteNombreCategoria(nombreNuevo)) 
            {
                throw new ExcepcionElementoYaExiste();
            } 
            Repositorio.Modificacion(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return Repositorio.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            return Repositorio.ObtenerTodasLasCategorias();
        }

        private bool ExisteNombreCategoria(string nombre)
        {
           return Repositorio.ExisteCategoria(nombre);
        }
         
        private void ValidarCategoria(string unNombre)
        {
            if (unNombre.Length < 3 || unNombre.Length > 15)
            {
                throw new ExcepcionLargoTexto();
            }

        }

    }
}
