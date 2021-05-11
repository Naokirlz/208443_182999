using System;

namespace Negocio.Utilidades
{
    public class ExcepcionAccesoDenegado : Exception
    {
        public ExcepcionAccesoDenegado() : base() { }

        public ExcepcionAccesoDenegado(string message) : base(message) { }

        public ExcepcionAccesoDenegado(string message, Exception innerException) : base(message, innerException) { }
    }
}
