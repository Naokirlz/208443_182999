using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Excepciones
{
    public class ExcepcionFechaIncorrecta : Exception
    {
        public ExcepcionFechaIncorrecta() : base() { }

        public ExcepcionFechaIncorrecta(string message) : base(message) { }

        public ExcepcionFechaIncorrecta(string message, Exception innerException) : base(message, innerException) { }
    }
}
