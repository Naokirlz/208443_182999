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
        private static int Autonumerado = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
                
        public Categoria(string unNombre)
        {
            this.Nombre = unNombre;
            this.Id = Autonumerado;
            Autonumerado++;
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
