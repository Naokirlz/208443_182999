using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Excepciones
{
    public class ExcepcionFaltaAtributo : Exception
    {
        public ExcepcionFaltaAtributo() : base() { }

        public ExcepcionFaltaAtributo(string message) : base(message) { }

        public ExcepcionFaltaAtributo(string message, Exception innerException) : base(message, innerException) { }
    }
}
