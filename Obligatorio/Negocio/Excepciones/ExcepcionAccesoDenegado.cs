using System;

namespace Negocio.Excepciones
{
    public class ExcepcionAccesoDenegado : Exception
    {
        public ExcepcionAccesoDenegado() : base() { }

        public ExcepcionAccesoDenegado(string message) : base(message) { }

        public ExcepcionAccesoDenegado(string message, Exception innerException) : base(message, innerException) { }
    }
}
