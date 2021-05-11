using System;
using System.Collections.Generic;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Utilidades;
using Negocio.TarjetaCreditos;


namespace Negocio
{
    public class Sesion
    {
        private static Sesion Instancia;
        private GestorCategorias GestorCategoria { get; set; }
        private GestorContrasenias GestorContrasenia { get; set; }
        private GestorTarjetaCredito GestorTarjetaCredito { get; set; }
        public List<IFuente> MisFuentes { get; set; }
        private string PasswordMaestro { get; set; }
        private bool Logueado { get; set; }

        public static Sesion Singleton
        {
            get
            {
                if (Instancia == null) Instancia = new Sesion();
                return Instancia;
            }
        }

        private Sesion()
        {
            GestorCategoria = new GestorCategorias();
            GestorContrasenia = new GestorContrasenias();
            GestorTarjetaCredito = new GestorTarjetaCredito();
            MisFuentes = new List<IFuente>();
            PasswordMaestro = "";
            this.Logueado = false;
        }

      

        public void Login(string password)
        {
            if (password != PasswordMaestro || PasswordMaestro == "") 
                throw new ExcepcionAccesoDenegado("El usuario o contraseña no son coinciden.");
            this.Logueado = true;
           
        }

        public IEnumerable<Contrasenia> ContraseniasVulnerables(IFuente fuente)
        {
            return this.GestorContrasenia.ObtenerContraseniasVulnerables(fuente);
        }
 
        public IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables(IFuente fuente)
        {
            return this.GestorTarjetaCredito.ObtenerTarjetasVulnerables(fuente);
        }
        
        public void GuardarPrimerPassword(string primerPassword)
        {
            Validaciones.ValidarLargoTexto(primerPassword, 25, 5, "primer password");
            this.PasswordMaestro = primerPassword;
        }

        public void CambiarPassword(string nuevoPassword)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            Validaciones.ValidarLargoTexto(nuevoPassword, 25, 5, "nuevo password");
            this.PasswordMaestro = nuevoPassword;
        }

        public int AltaCategoria(string nombreCategoria)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return this.GestorCategoria.Alta(nombreCategoria);
        }

        public void BajaCategoria(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            this.GestorCategoria.Baja(id);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            this.GestorCategoria.ModificarCategoria(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return GestorCategoria.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return this.GestorCategoria.ObtenerTodas();
        }

        public int AltaTarjetaCredito(TarjetaCredito nuevaTarjeta)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            BuscarCategoriaPorId(nuevaTarjeta.Categoria.Id);
            return this.GestorTarjetaCredito.Alta(nuevaTarjeta);
        }

        public void BajaTarjetaCredito(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            GestorTarjetaCredito.Baja(id);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            GestorTarjetaCredito.ModificarTarjeta(modificada);
        }

        public TarjetaCredito BuscarTarjeta(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return GestorTarjetaCredito.Buscar(id);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return GestorTarjetaCredito.ObtenerTodas();
        }

        public int AltaContrasenia(Contrasenia unaContrasena)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            GestorCategoria.BuscarCategoriaPorId(unaContrasena.Categoria.Id);
            return GestorContrasenia.Alta(unaContrasena);
        }

        public void BajaContrasenia(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            GestorContrasenia.Baja(id);
        }

        public void ModificarContrasenia(Contrasenia modificada)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            GestorContrasenia.ModificarContrasenia(modificada);
        }

        public Contrasenia BuscarContrasenia(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return GestorContrasenia.Buscar(id);
        }

        public IEnumerable<Contrasenia> ObtenerTodasLasContrasenias()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return GestorContrasenia.ObtenerTodas();
        }

        //public string VerificarFortaleza(Contrasenia contrasenia)
        //{
        //    if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
        //    return contrasenia.Password.ColorPassword.ToString();
        //}
       
        public string MostrarPassword(Contrasenia contrasenia)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return GestorContrasenia.MostrarPassword(contrasenia);
        }

        public void LogOut()
        {
            this.Logueado = false;
        }

        public void VaciarDatosPrueba()
        {
            this.GestorContrasenia = new GestorContrasenias();
            this.GestorTarjetaCredito = new GestorTarjetaCredito();
            this.GestorCategoria = new GestorCategorias();
            this.MisFuentes = new List<IFuente>();
        }

        public void InsertarDatosDeMuestra()
        {
            int idestudio = AltaCategoria("Estudio");
            Categoria estudio = GestorCategoria.BuscarCategoriaPorId(idestudio);
            AltaCategoria("Hogar");
            AltaCategoria("Familia");
            AltaCategoria("Trabajo");

            TarjetaCredito nueva = new TarjetaCredito() { 
                Categoria = estudio,
                Codigo = 123.ToString(),
                Nombre = "Visa República",
                Numero = "1231231231231231",
                Tipo = "Visa",
                Vencimiento = DateTime.Now
            };
            AltaTarjetaCredito(nueva);
        }

    }
}
