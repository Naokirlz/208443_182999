using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Negocio.Contrasenias
{
    public class GestorContrasenias
    {
        public RepositorioContrasenias Repositorio;
        private string LlaveEncriptacion = "lL4v3Par43nc1pT4r";
        public GestorContrasenias() {
            this.Repositorio = new RepositorioContrasenias();
        }

        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
            unaContrasena.Password = Encriptar(unaContrasena.Password);
            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            return Repositorio.Alta(unaContrasena);
        }

        public void Baja(int id)
        {
            Repositorio.Baja(id);
        }

        public void ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            ValidarCampos(aModificarContrasenia);
            Repositorio.ModificarContrasenia(aModificarContrasenia);
            aModificarContrasenia.Password = Encriptar(aModificarContrasenia.Password);
        }

        private bool CambioPassword(Contrasenia aModificarContrasenia)
        {
            string anterior = Buscar(aModificarContrasenia.Id).Password;
            anterior = DesEncriptar(anterior);
            return aModificarContrasenia.Password.Equals(anterior);

        }

        public Contrasenia Buscar(int id)
        {
            return Repositorio.BuscarPorId(id);
        }


        public List<Contrasenia> ListarContrasenias()
        {
            List<Contrasenia> retorno = Repositorio.ListarContrasenias();
            retorno.Sort();
            return retorno;
        }
                
        public string GenerarPassword(int largo, bool mayuscula, bool minuscula, bool numero, bool especial)
        {
            string password = "";

            //documentacion de Random
            //El valor de inicialización predeterminado se deriva del reloj del sistema y tiene una resolución finita. Como resultado, diferentes Random objetos que se crean en estrecha sucesión mediante una llamada al constructor predeterminado tendrán valores de inicialización predeterminados idénticos y, por consiguiente, generarán conjuntos idénticos de números aleatorios.
            var random = new Random();
            int largoOriginal = largo;

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

            int largoAShuffle = largoOriginal;
            password = "";
            while (largoAShuffle > 1)
            {
                int caracterRandom = random.Next(largoAShuffle--);
                char temp = passwordArreglo[largoAShuffle];
                passwordArreglo[largoAShuffle] = passwordArreglo[caracterRandom];
                passwordArreglo[caracterRandom] = temp;
            }
            foreach (char c in passwordArreglo) password += c;

            return password;
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

        private void ValidarLargoTexto(string texto, int largoMax, int largoMin)
        {
            if (texto.Length > largoMax || texto.Length < largoMin) throw new ExcepcionLargoTexto();
        }
       
        private void ValidarFecha(DateTime unaFecha)
        {
            if (unaFecha > DateTime.Now) throw new ExcepcionFechaIncorrecta();
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

        private string Encriptar(string texto)
        {

            //byte[] byt = System.Text.Encoding.UTF8.GetBytes(texto);
            //string codificado;
            //codificado = Convert.ToBase64String(byt);
            //return codificado;
            byte[] llaveArreglo;
            byte[] ArregloACifrar = UTF8Encoding.UTF8.GetBytes(texto);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            llaveArreglo = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.LlaveEncriptacion));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = llaveArreglo;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(ArregloACifrar,
            0, ArregloACifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        private string DesEncriptar(string texto)
        {
            //byte[] b = Convert.FromBase64String(texto);
            //string original;
            //original = System.Text.Encoding.UTF8.GetString(b);
            //return original;

            byte[] llaveArreglo;
            //convierte el texto en una secuencia de bytes
            byte[] ArrayADescifrar =
            Convert.FromBase64String(texto);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            llaveArreglo = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(this.LlaveEncriptacion));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = llaveArreglo;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(ArrayADescifrar,
            0, ArrayADescifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        internal string MostrarPassword(string password)
        {
            return DesEncriptar(password);
        }


    }
}
