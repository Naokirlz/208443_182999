using System;

namespace Negocio.Utilidades
{
    public class ExcepcionElementoYaExiste : Exception
    {
        public ExcepcionElementoYaExiste() : base() { }

        public ExcepcionElementoYaExiste(string message) : base(message) { }

        public ExcepcionElementoYaExiste(string message, Exception innerException) : base(message, innerException) { }
    }
}
