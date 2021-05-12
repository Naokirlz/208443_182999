using System;

namespace Negocio.Utilidades { 
    public class Validaciones
    {
        public static void ValidarLargoTexto(string texto, int largoMax, int largoMin, string campo)
        {
            texto = texto.Trim();
            if (texto.Length > largoMax || texto.Length < largoMin)
                throw new ExcepcionLargoTexto("El largo del campo " + campo + " debe ser de entre " + 
                                              largoMin.ToString() + " y " + largoMax.ToString() + " caracteres.");
        }
        public static void ValidarSoloNumeros(string texto, string campo)
        {
            foreach (char digito in texto)
            {
                if (!EsNumero(digito)) throw new ExcepcionNumeroNoValido("Debe introducir sólo números en el campo " + campo);
            }
       }

        public static bool EsNumero(char digito)
        {
            int convertido = Convert.ToInt32(digito);

            if(convertido > 57) return false;
            else if(convertido < 48) return false;
            return true;          

        }

        public static void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta("La fecha de modificación no puede ser futura.");
        }

        public static void ValidarPassword(string clave, int maximo, int minimo)
        {
            if (clave.Length > maximo || clave.Length < minimo)
                throw new ExcepcionLargoTexto("El largo de contraseña debe ser de entre " +
                                              minimo.ToString() + " y " + maximo.ToString() + " caracteres.");
        }
    }
}
