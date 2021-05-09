using Negocio.Excepciones;
using System;

namespace Negocio
{
    public class Validaciones
    {
        public static void ValidarLargoTexto(string texto, int largoMax, int largoMin, string campo)
        {
            texto = texto.Trim();
            if (texto.Length > largoMax || texto.Length < largoMin)
                throw new ExcepcionLargoTexto("El largo del campo " + campo + " debe ser de entre " + 
                                              largoMin.ToString() + " y " + largoMax.ToString() + " caracteres.");
        }
        public static void ValidarSoloNumeros(string texto)
        {
            foreach (char digito in texto)
            {
                if (!EsNumero(digito)) throw new ExcepcionNumeroNoValido();
            }
       }

        public static bool EsNumero(char digito)
        {
            if (Convert.ToInt32(digito) >= 48 && Convert.ToInt32(digito) <= 57)
            {
                return true;
            }
            return false;
        }

        public static void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta("La fecha de modificación no puede ser futura.");
        }

    }
}
