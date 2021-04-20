using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.Clases
{
    public class Contrasenia
    {
        public string Sitio { get; }
        public string Usuario { get; }
        public string Password { get; }

        public Contrasenia() { }
        public Contrasenia(string unSitio) : base()
        {
            if (unSitio.Length < 3) throw new ExcepcionLargoTexto();
            if (unSitio.Length > 25) throw new ExcepcionLargoTexto();
            this.Sitio = unSitio;
        }

        public Contrasenia(string unSitio, string unUsuario) : this(unSitio)
        {
            if (unUsuario.Length < 5) throw new ExcepcionLargoTexto();
            if (unUsuario.Length > 25) throw new ExcepcionLargoTexto();
            this.Usuario = unUsuario;
        }
        public Contrasenia(string unSitio, string unUsuario, string unPassword) : this(unSitio, unUsuario)
        {
            if (unPassword.Length < 5) throw new ExcepcionLargoTexto();
            if (unPassword.Length > 25) throw new ExcepcionLargoTexto();
            this.Password = unPassword;
        }
    }
}
