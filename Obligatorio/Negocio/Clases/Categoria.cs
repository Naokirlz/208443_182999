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
        
        


        public Categoria(string unNombre)
        {
            ValidarCategoria(unNombre);
            this.Nombre = unNombre;
            this.Id = Cantidad;
            Cantidad++;
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
