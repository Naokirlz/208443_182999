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
        public string Sitio { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Notas {get; set; }
        public Categoria Categoria { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int Id { get; }
        private static int Cantidad = 1;

        //public string Sitio
        //{
        //    get => Sitio;
        //    set
        //    {
        //        setSitio(value);
        //    }
        //}
        //private void setSitio(string valor)
        //{
        //    if (valor.Length < 3) throw new ExcepcionLargoTexto();
        //    if (valor.Length > 25) throw new ExcepcionLargoTexto();
        //    this.Sitio = valor;
        //}
        //public string Usuario
        //{
        //    get => Usuario;
        //    set
        //    {
        //        if (value.Length < 5) throw new ExcepcionLargoTexto();
        //        if (value.Length > 25) throw new ExcepcionLargoTexto();
        //        Usuario = value;
        //    }
        //}
        //public string Password
        //{
        //    get => Password;
        //    set
        //    {
        //        if (value.Length < 5) throw new ExcepcionLargoTexto();
        //        if (value.Length > 25) throw new ExcepcionLargoTexto();
        //        Password = value;
        //    }
        //}
        ////private string Notas;

        ////public string GetNotas()
        ////{
        ////    return Notas;
        ////}

        ////public void SetNotas(string value)
        ////{
        ////    Notas = value;
        ////}

        //public string Notas
        //{
        //    get => Notas;
        //    set
        //    {
        //        if (value.Length > 250) throw new ExcepcionLargoTexto();
        //        Notas = value;
        //    }
        //}

        //private Categoria categoriaPass;

        //public Categoria GetCategoriaPass()
        //{
        //    return categoriaPass;
        //}

        //public void SetCategoriaPass(Categoria value)
        //{
        //    categoriaPass = value;
        //}

        ////{
        ////    get => CategoriaPass;
        ////    set => CategoriaPass = value;
        ////}
        //private DateTime fechaUltimaModificacion;

        //public DateTime GetFechaUltimaModificacion()
        //{
        //    return fechaUltimaModificacion;
        //}

        //public void SetFechaUltimaModificacion(DateTime value)
        //{
        //    if (value > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        //    fechaUltimaModificacion = value;
        //}
        ////public DateTime FechaUltimaModificacion {
        ////    get => FechaUltimaModificacion;
        ////    set
        ////    {
        ////        if (value > DateTime.Now) throw new ExcepcionFechaIncorrecta();
        ////        FechaUltimaModificacion = value;
        ////    }
        ////}

        public Contrasenia() {
            this.Id = Cantidad;
            Cantidad++;
        }
    }
}
