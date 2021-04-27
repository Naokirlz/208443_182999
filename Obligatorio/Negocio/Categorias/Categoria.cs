using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Excepciones;

namespace Negocio.Categorias
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        private static int Cantidad = 1;
        
        


        public Categoria(string unNombre)
        {
            ValidarCategoria(unNombre);
            this.Nombre = unNombre;
            this.Id = Cantidad;
            Cantidad++;
        }

        public Categoria(string unNombre, int unId) :this(unNombre)
        {
            this.Id = unId;
        }



        private static void ValidarCategoria(string unNombre)
        {
            if (unNombre.Length < 3 || unNombre.Length > 15)
            {
                throw new ExcepcionLargoTexto();
            }
            
        }

        public void ModificarCategoria(string nuevoNombre)
        {
            ValidarCategoria(nuevoNombre);
            this.Nombre = nuevoNombre;
        }


        public override string ToString()
        {
            return this.Nombre;
        }


    }
}
