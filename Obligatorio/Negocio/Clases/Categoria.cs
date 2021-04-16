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
        

        public Categoria(string nombre)
        {

            if (nombre.Length < 3 || nombre.Length > 15)
            {
                throw new ExcepcionLargoTexto();

            }

            this.Nombre = nombre;

        }
    }
}
