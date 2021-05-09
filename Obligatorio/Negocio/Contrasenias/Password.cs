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
            "!@$?_-"                        // ESPECIALES
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
            bool mayusculas = false;
            bool minusculas = false;
            bool numeros = false;
            bool especiales = false;
            string password = this.Clave;
            int largo = password.Length;

            foreach (char caracter in password)
            {
                if (caracter >= 65 && caracter <= 90) mayusculas = true;
                else if (caracter >= 97 && caracter <= 122) minusculas = true;
                else if (caracter >= 48 && caracter <= 57) numeros = true;
                else if (caracter >= 32 && caracter <= 47) especiales = true;
                else if (caracter >= 58 && caracter <= 64) especiales = true;
                else if (caracter >= 91 && caracter <= 96) especiales = true;
                else if (caracter >= 123 && caracter <= 126) especiales = true;
            }
            if (largo > 14)
            {

                if (mayusculas && minusculas && numeros && especiales) return EnumColor.VERDE_OSCURO;
                else if (mayusculas && minusculas) return EnumColor.VERDE_CLARO;
                else if (mayusculas && especiales && numeros) return EnumColor.VERDE_CLARO;
                else if (minusculas && especiales && numeros) return EnumColor.VERDE_CLARO;
                else return EnumColor.AMARILLO;

            }
            else if (largo >= 8) return EnumColor.NARANJA;
            return EnumColor.ROJO;
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
