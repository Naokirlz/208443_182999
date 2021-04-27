using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
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
            Categoria nueva = Repositorio.Alta(nombre);
            return nueva;
        }


             

        public void Baja(int id)
        {
            BuscarCategoria(id);
            Repositorio.Baja(id);
        }


        public  void ModificarCategoria(int id, string nuevoNombre)
        {
            Repositorio.ModificarCategoria(id, nuevoNombre);
            //Categoria Modificar = BuscarCategoria(id);
            //if (ExisteCategoria(nuevoNombre)) throw new ExcepcionElementoYaExiste();
            //Modificar.ModificarCategoria(nuevoNombre);
            //Modificar.Nombre = nuevoNombre;
        }



        //private bool ExisteCategoria(string unNombre)
        //{
        //    foreach (var categoria in this.Categorias)
        //    {
        //        if (categoria.Nombre.Equals(unNombre)) return true;
        //    }
        //    return false;
        //}

        public Categoria BuscarCategoria(int id)
        {
            return Repositorio.BuscarCategoria(id);
        }

        public List<Categoria> ListarCategorias()
        {
            return Repositorio.ListarCategorias();
        }

       
    }
}
