using System;

namespace Negocio.Utilidades
{
    public class ExcepcionFechaIncorrecta : Exception
    {
        public ExcepcionFechaIncorrecta() : base() { }

        public ExcepcionFechaIncorrecta(string message) : base(message) { }

        public ExcepcionFechaIncorrecta(string message, Exception innerException) : base(message, innerException) { }
    }
}
