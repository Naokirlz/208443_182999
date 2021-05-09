using System;
using System.Collections.Generic;

namespace Negocio.Contrasenias
{
    public class Password
    {
        public string Clave { get; set; }
        public bool Mayuscula { get; set; }
        public bool Minuscula { get; set; }
        public bool Numero { get; set; }
        public bool Especial { get; set; }
        public int Largo { get; set; }

        public EnumColor ColorPassword { get { return CalcularFortaleza(); } }

        public Password(string clave)
        {
            this.Clave = clave;
        }

        string[] caracteresRandom = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // MAYUSCULAS 
            "abcdefghijkmnopqrstuvwxyz",    // MINUSCULAS
            "0123456789",                   // NUMEROS
            "!#$%&'()*+,-./: ;<=>?@[]^_`{|}~"  // ESPECIALES
        };

        public void GenerarPassword()
        {
            Random Rand = new Random(Environment.TickCount);
            List<char> palabras = new List<char>();
            
            for (int i = palabras.Count; i < Largo; i++)
            {
            if (Mayuscula)
                palabras.Insert(Rand.Next(0, palabras.Count),
                    caracteresRandom[0][Rand.Next(0, caracteresRandom[0].Length)]);
            if (Minuscula)
                palabras.Insert(Rand.Next(0, palabras.Count),
                    caracteresRandom[1][Rand.Next(0, caracteresRandom[1].Length)]);
            if (Numero)
                palabras.Insert(Rand.Next(0, palabras.Count),
                    caracteresRandom[2][Rand.Next(0, caracteresRandom[2].Length)]);
            if (Especial)
                palabras.Insert(Rand.Next(0, palabras.Count),
                    caracteresRandom[3][Rand.Next(0, caracteresRandom[3].Length)]);
            }

            string resultado = new string(palabras.ToArray());
            this.Clave = resultado;
        }

        public EnumColor CalcularFortaleza()
        {
            this.Largo = Clave.Length;
            SeteoPassword();
           
            if (this.Largo > 14)
            {

                if (this.Mayuscula && this.Minuscula && this.Numero && this.Especial) return EnumColor.VERDE_OSCURO;
                else if (this.Mayuscula && this.Minuscula) return EnumColor.VERDE_CLARO;
                else if (this.Mayuscula && this.Especial && this.Numero) return EnumColor.VERDE_CLARO;
                else if (this.Minuscula && this.Especial && this.Numero) return EnumColor.VERDE_CLARO;
                else return EnumColor.AMARILLO;

            }
            else if (this.Largo >= 8) return EnumColor.NARANJA;
            return EnumColor.ROJO;
        }

        private void SeteoPassword()
        {
            foreach (char caracter in this.Clave)
            {
                if (caracteresRandom[0].IndexOf(caracter) > -1) this.Mayuscula = true;
                if (caracteresRandom[1].IndexOf(caracter) > -1) this.Minuscula = true;
                if (caracteresRandom[2].IndexOf(caracter) > -1) this.Numero = true;
                if (caracteresRandom[3].IndexOf(caracter) > -1) this.Especial = true;
            }

        }
    }
    public enum EnumColor
    {
        ROJO,
        NARANJA,
        AMARILLO,
        VERDE_CLARO,
        VERDE_OSCURO
    }
}
