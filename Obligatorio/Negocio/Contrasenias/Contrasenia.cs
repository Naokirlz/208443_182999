using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Categorias;


namespace Negocio.Contrasenias
{
     
    public class Contrasenia: IComparable<Contrasenia>
    {
        public int Id { get; set; }
        public string Sitio { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Notas {get; set; }
        public Categoria Categoria { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int CantidadVecesEncontradaVulnerable { get; set; }

        public EnumColor ColorPassword { get { return CalcularFortaleza(); } }
        
        
        public Contrasenia()
        {
            
        }

        public EnumColor CalcularFortaleza()
        {
            bool mayusculas = false;
            bool minusculas = false;
            bool numeros = false;
            bool especiales = false;
            string password = this.Password;
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
            if (largo > 14) {

                 if( mayusculas && minusculas && numeros && especiales) return EnumColor.VERDE_OSCURO;
                 else if (mayusculas && minusculas) return EnumColor.VERDE_CLARO;
                 else if (mayusculas && especiales && numeros) return EnumColor.VERDE_CLARO;
                 else if (minusculas && especiales && numeros) return EnumColor.VERDE_CLARO;
                 else return EnumColor.AMARILLO;
                 
            }
            else if (largo >= 8) return EnumColor.NARANJA;
            return EnumColor.ROJO;
        }


        public int CompareTo(Contrasenia otraContrasenia)
        {
            return this.Categoria.Nombre.CompareTo(otraContrasenia.Categoria.Nombre);

        }

        public override string ToString()
        {
            return this.Sitio + " | " + this.Usuario;
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
