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

        public Categoria Alta(string nombre)
        {
            ValidarCategoria(nombre);

            if (ExisteNombreCategoria(nombre)) { 
            
                throw new ExcepcionElementoYaExiste(); 
            
            }
            Categoria nueva = Repositorio.Alta(nombre);
            return nueva;
        }

        public void Baja(int id)
        {
            BuscarCategoriaPorId(id);
            Repositorio.Baja(id);
        }

        public void Modificacion(int id, string nuevoNombre)
        {
            ValidarCategoria(nuevoNombre);
            if (ExisteNombreCategoria(nuevoNombre)) throw new ExcepcionElementoYaExiste();
            Repositorio.Modificacion(id, nuevoNombre);
          
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return Repositorio.BuscarCategoriaPorId(id);
        }

        private bool ExisteNombreCategoria(string unNombre)
        {
           return Repositorio.ExisteCategoria(unNombre);
        }

        public List<Categoria> ListarCategorias()
        {
            return Repositorio.ListarCategorias();
        }

        private static void ValidarCategoria(string unNombre)
        {
            if (unNombre.Length < 3 || unNombre.Length > 15)
            {
                throw new ExcepcionLargoTexto();
            }

        }


    }
}
