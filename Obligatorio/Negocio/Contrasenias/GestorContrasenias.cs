using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contrasenias
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
            string password = Repositorio.MostrarPassword(nuevaContrasenia.Password);
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
            //documentacion de Random
            //El valor de inicialización predeterminado se deriva del reloj del sistema y tiene una resolución finita. Como resultado, diferentes Random objetos que se crean en estrecha sucesión mediante una llamada al constructor predeterminado tendrán valores de inicialización predeterminados idénticos y, por consiguiente, generarán conjuntos idénticos de números aleatorios.
            var random = new Random();
            

            if (mayuscula)
            {
                password += GenerarCaracter(true, false, false, false, random);
                largo--;
            }
            if (minuscula)
            {
                password += GenerarCaracter(false, true, false, false, random);
                largo--;
            }
            if (numero)
            {
                password += GenerarCaracter(false, false, true, false, random);
                largo--;
            }
            if (especial)
            {
                password += GenerarCaracter(false, false, false, true, random);
                largo--;
            }

            string caracterUltimo = "";

            for (int caracter = 0; caracter < largo; caracter++)
            {
                string nuevoCaracter = GenerarCaracter(mayuscula, minuscula, numero, especial, random);
                if (nuevoCaracter != caracterUltimo)
                {
                    password += GenerarCaracter(mayuscula, minuscula, numero, especial, random);
                    caracterUltimo = nuevoCaracter;
                }
                else
                {
                    caracter--;
                }

            }
            char[] passwordArreglo = password.ToCharArray();
            //Random random = new Random();

            bool dosIguales = false;
            password = "";

            do
            {
                while (largoOriginal > 1)
                {
                    int caracterRandom = random.Next(largoOriginal--);
                    char temp = passwordArreglo[largoOriginal];
                    passwordArreglo[largoOriginal] = passwordArreglo[caracterRandom];
                    passwordArreglo[caracterRandom] = temp;
                }
                foreach (char c in passwordArreglo) password += c;
                char caracterAnterior = new char();

                foreach (char c in password)
                {
                    if (c == caracterAnterior) dosIguales = true;
                    caracterAnterior = c;
                }
            }
            while (dosIguales);

            return password;
        }

        private string GenerarCaracter(bool mayuscula, bool minuscula, bool numero, bool especial, Random random)
        {
            string caracter = "";
            //var random = new Random();

            int codigo = random.Next(126);

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

        public string MostrarPassword(string password)
        {
            return Repositorio.MostrarPassword(password);
        }

        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }
    }
}
