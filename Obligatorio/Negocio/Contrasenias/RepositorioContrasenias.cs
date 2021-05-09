using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Negocio.Contrasenias
{
    public class RepositorioContrasenias
    {
        private List<Contrasenia> Contrasenias { get; set; }
        private static int autonumerado = 1;
        private string LlaveEncriptacion = "lL4v3Par43nc1pT4r";

        public RepositorioContrasenias()
        {
            this.Contrasenias = new List<Contrasenia>();
        }

        public Contrasenia Alta(Contrasenia unaContrasenia)
        {
            foreach (var contrasenia in this.Contrasenias)
            {
                if (contrasenia.Sitio.Equals(unaContrasenia.Sitio) &&
                    contrasenia.Usuario.Equals(unaContrasenia.Usuario))
                    throw new ExcepcionElementoYaExiste();
            }
            unaContrasenia.Id = autonumerado;
            autonumerado++;
            unaContrasenia.Password = Encriptar(unaContrasenia.Password);
            Contrasenia clonada = ClonarContrasenia(unaContrasenia);
            this.Contrasenias.Add(clonada);
            return unaContrasenia;
        }

        internal void Baja(int id)
        {
            Contrasenias.Remove(BuscarPorId(id));
        }

        

        internal Contrasenia ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            Contrasenia anterior = BuscarPorId(aModificarContrasenia.Id);
            anterior.Sitio = aModificarContrasenia.Sitio;
            anterior.Usuario = aModificarContrasenia.Usuario;
            anterior.Password = Encriptar(aModificarContrasenia.Password);
            anterior.Categoria = aModificarContrasenia.Categoria;
            anterior.Notas = aModificarContrasenia.Notas;
            Contrasenia clonModificada = ClonarContrasenia(anterior);
            return clonModificada;
        }


        public List<Contrasenia> ListarContrasenias()
        {
            return this.Contrasenias;
        }


        private Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return item;

            throw new ExcepcionElementoNoExiste("La contraseña buscada no existe.");
        }


        internal Contrasenia Buscar(int id)
        {
            Contrasenia buscada = BuscarPorId(id);
            Contrasenia clonBuscada = ClonarContrasenia(buscada);
            return clonBuscada;
        }

        private Contrasenia ClonarContrasenia(Contrasenia unaContrasenia)
        {
            Contrasenia clonada = new Contrasenia()
            {
                Id = unaContrasenia.Id,
                Sitio = unaContrasenia.Sitio,
                Notas = unaContrasenia.Notas,
                Password = unaContrasenia.Password,
                Usuario = unaContrasenia.Usuario,
                Categoria = unaContrasenia.Categoria,
                FechaUltimaModificacion = unaContrasenia.FechaUltimaModificacion,
                CantidadVecesEncontradaVulnerable = unaContrasenia.CantidadVecesEncontradaVulnerable
            };
            return clonada;
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