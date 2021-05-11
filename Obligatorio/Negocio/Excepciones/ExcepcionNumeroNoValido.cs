using System;

namespace Negocio.Excepciones
{
    public class ExcepcionNumeroNoValido : Exception
    {
        public ExcepcionNumeroNoValido() : base() { }

        public ExcepcionNumeroNoValido(string message) : base(message) { }

        public ExcepcionNumeroNoValido(string message, Exception innerException) : base(message, innerException) { }

    }
}
