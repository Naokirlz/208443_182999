using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Excepciones;

namespace Negocio
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public int Id { get; }
        private static int Cantidad = 1;
        private static List<Categoria> Categorias = new List<Categoria>();


        public Categoria(string unNombre)
        {
            ValidarCategoria(unNombre);
            this.Nombre = unNombre;
            this.Id = Cantidad;
            Categorias.Add(this);
            Cantidad++;
        }

        private static bool ExisteCategoria(string unNombre)
        {
            foreach (var categoria in Categoria.Categorias)
            {
                if (categoria.Nombre.Equals(unNombre)) return true;
            }
            return false;
        }

        private void ValidarCategoria(string unNombre)
        {
            if (unNombre.Length < 3 || unNombre.Length > 15)
            {
                throw new ExcepcionLargoTexto();
            }
            if (ExisteCategoria(unNombre)) throw new ExcepcionElementoYaExiste();
        }
    }
}
