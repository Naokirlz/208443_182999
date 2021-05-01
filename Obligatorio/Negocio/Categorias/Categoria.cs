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
        
        public int Id { get; set; }
        public string Nombre { get; set; }
                
        public Categoria(string unNombre)
        {
            this.Nombre = unNombre;
            
        }

        public Categoria(string unNombre, int unId) :this(unNombre)
        {
            this.Id = unId;
        }


        public override string ToString()
        {
            return this.Nombre;
        }


    }
}
