using System;

namespace Negocio.Utilidades
{
    public class ExcepcionFaltaAtributo : Exception
    {
        public ExcepcionFaltaAtributo() : base() { }

        public ExcepcionFaltaAtributo(string message) : base(message) { }

        public ExcepcionFaltaAtributo(string message, Exception innerException) : base(message, innerException) { }
    }
}
