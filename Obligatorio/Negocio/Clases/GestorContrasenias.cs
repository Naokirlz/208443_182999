using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class GestorContrasenias
    {
        public RepositorioContrasenias Repositorio;
        public GestorContrasenias() {
            this.Repositorio = new RepositorioContrasenias();
        }

        public Contrasenia Alta(Contrasenia unaContrasena)
        {
            //if (unaContrasena.Sitio == null ||
            //    unaContrasena.Usuario == null ||
            //    unaContrasena.Password == null ||
            //    unaContrasena.Categoria == null)
            //    throw new ExcepcionFaltaAtributo();

            //ValidarFecha(unaContrasena.FechaUltimaModificacion);
            //ValidarLargoTexto(unaContrasena.Notas, 250, 0);
            //ValidarLargoTexto(unaContrasena.Password, 25, 5);
            //ValidarLargoTexto(unaContrasena.Usuario, 25, 5);
            //ValidarLargoTexto(unaContrasena.Sitio, 25, 3);

            ValidarCampos(unaContrasena);

            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            return Repositorio.Alta(unaContrasena);
        }

        private void ValidarLargoTexto(string texto, int largoMax, int largoMin)
        {
            if (texto.Length > largoMax || texto.Length < largoMin) throw new ExcepcionLargoTexto();
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return Repositorio.ListarContrasenias();
        }

        private void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        }

        public Contrasenia ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            ValidarCampos(aModificarContrasenia);
            aModificarContrasenia.FechaUltimaModificacion = DateTime.Now;
            return Repositorio.ModificarContrasenia(aModificarContrasenia);
        }

        public Contrasenia Buscar(int id)
        {
            return Repositorio.Buscar(id);
        }

        private void ValidarCampos(Contrasenia aValidarContrasenia)
        {
            if (aValidarContrasenia.Sitio == null ||
                aValidarContrasenia.Usuario == null ||
                aValidarContrasenia.Password == null ||
                aValidarContrasenia.Categoria == null)
                throw new ExcepcionFaltaAtributo();

            ValidarFecha(aValidarContrasenia.FechaUltimaModificacion);
            ValidarLargoTexto(aValidarContrasenia.Sitio, 25, 3);
            ValidarLargoTexto(aValidarContrasenia.Usuario, 25, 5);
            ValidarLargoTexto(aValidarContrasenia.Password, 25, 5);
            ValidarLargoTexto(aValidarContrasenia.Notas, 250, 0);
        }

        public string VerificarFortaleza(Contrasenia nuevaContrasenia)
        {
            bool mayusculas = false;
            bool minusculas = false;
            bool numeros = false;
            bool especiales = false;
            string password = nuevaContrasenia.Password;
            int largo = password.Length;

            foreach(char caracter in password)
            {
                if (caracter >= 65 && caracter <= 90) mayusculas = true;
                else if (caracter >= 97 && caracter <= 122) minusculas = true;
                else if (caracter >= 48 && caracter <= 57) numeros = true;
                else if (caracter >= 32 && caracter <= 47) especiales = true;
                else if (caracter >= 58 && caracter <= 64) especiales = true;
                else if (caracter >= 91 && caracter <= 96) especiales = true;
                else if (caracter >= 123 && caracter <= 126) especiales = true;
            }

            if (largo > 14 && mayusculas && minusculas && numeros && especiales) return "VERDE OSCURO";
            if (largo > 14 && mayusculas && minusculas && !numeros && !especiales) return "VERDE CLARO";
            if (largo > 14 && mayusculas && !minusculas && !numeros && !especiales) return "AMARILLO";
            if (largo > 14 && !mayusculas && minusculas && !numeros && !especiales) return "AMARILLO";
            if (largo >= 8) return "NARANJA";
            return "ROJO";
        }

        public string GenerarPassword(int largo, bool mayuscula, bool minuscula, bool numero, bool especial)
        {
            string password = "";
            int largoOriginal = largo;

            if (mayuscula)
            {
                password += GenerarCaracter(true, false, false, false);
                largo--;
            }
            if (minuscula)
            {
                password += GenerarCaracter(false, true, true, true);
                largo--;
            }

            for (int caracter = 0; caracter < largo; caracter++) password += GenerarCaracter(mayuscula, minuscula, numero, especial);
            char[] passwordArreglo = password.ToCharArray();
            Random random = new Random();

            while (largoOriginal > 1)
            {
                int caracterRandom = random.Next(largoOriginal--);
                char temp = passwordArreglo[largoOriginal];
                passwordArreglo[largoOriginal] = passwordArreglo[caracterRandom];
                passwordArreglo[caracterRandom] = temp;
            }
            password = "";
            foreach (char c in passwordArreglo) password += c;
            return password;
        }

        private string GenerarCaracter(bool mayuscula, bool minuscula, bool numero, bool especial)
        {
            string caracter = "";
            var random = new Random();

            int codigo = 0;

            while (
                (codigo < 32 || (codigo < 97 && codigo > 123)) ||
                (codigo >= 97 && codigo <= 122 && !minuscula) ||
                (codigo >= 65 && codigo <= 90 && !mayuscula) ||
                (codigo >= 48 && codigo <= 57 && !numero) ||
                (codigo >= 32 && codigo <= 47 && !especial) ||
                (codigo >= 58 && codigo <= 64 && !especial) ||
                (codigo >= 91 && codigo <= 96 && !especial) ||
                (codigo >= 123 && codigo <= 126 && !especial)
                )
            {
                codigo = random.Next(126);
            }
                
            caracter += (char)codigo;
            return caracter;
        }
    }
}
