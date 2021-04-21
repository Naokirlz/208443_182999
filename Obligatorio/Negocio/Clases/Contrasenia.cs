using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;


namespace Negocio.Clases
{
    public class Contrasenia
    {
        public string Sitio
        {
            get => Sitio;
            set
            {
                if (value.Length < 3) throw new ExcepcionLargoTexto();
                if (value.Length > 25) throw new ExcepcionLargoTexto();
                Sitio = value;
            }
        }
        public string Usuario
        {
            get => Usuario;
            set
            {
                if (value.Length < 5) throw new ExcepcionLargoTexto();
                if (value.Length > 25) throw new ExcepcionLargoTexto();
                Usuario = value;
            }
        }
        public string Password
        {
            get => Password;
            set
            {
                if (value.Length < 5) throw new ExcepcionLargoTexto();
                if (value.Length > 25) throw new ExcepcionLargoTexto();
                Password = value;
            }
        }
        public string Notas
        {
            get => Notas;
            set
            {
                if (value.Length > 250) throw new ExcepcionLargoTexto();
                Notas = value;
            }
        }

        private Categoria categoriaPass;

        public Categoria GetCategoriaPass()
        {
            return categoriaPass;
        }

        public void SetCategoriaPass(Categoria value)
        {
            categoriaPass = value;
        }

        //{
        //    get => CategoriaPass;
        //    set => CategoriaPass = value;
        //}
        private DateTime fechaUltimaModificacion;

        public DateTime GetFechaUltimaModificacion()
        {
            return fechaUltimaModificacion;
        }

        public void SetFechaUltimaModificacion(DateTime value)
        {
            fechaUltimaModificacion = value;
        }
        //public DateTime FechaUltimaModificacion {
        //    get => FechaUltimaModificacion;
        //    set
        //    {
        //        if (value > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        //        FechaUltimaModificacion = value;
        //    }
        //}

        public Contrasenia() { }
    }
}
