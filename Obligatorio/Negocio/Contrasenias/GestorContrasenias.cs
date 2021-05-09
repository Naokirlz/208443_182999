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
            unaContrasena.Password.Clave = Encriptar(unaContrasena.Password.Clave);
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
            aModificarContrasenia.Password.Clave = Encriptar(aModificarContrasenia.Password.Clave);
        }
        
        public Contrasenia Buscar(int id)
        {
            return Repositorio.BuscarPorId(id);
        }
        
        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            return Repositorio.ObtenerTodas();
             
        }
      
        internal string MostrarPassword(string password)
        {
            return DesEncriptar(password);
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
            ValidarLargoTexto(aValidarContrasenia.Password.Clave, 25, 5);
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
                

    }
}
