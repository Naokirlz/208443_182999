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
        private static Sesion instancia;
        private GestorCategorias gestorCategoria;
        private GestorContrasenias gestorContrasenia;
        private GestorTarjetaCredito gestorTarjetaCredito;
        public List<IFuente> MisFuentes { get; set; }
        private string passwordMaestro;
        private bool logueado;

        public static Sesion ObtenerInstancia()
        {
            if (instancia == null) instancia = new Sesion();
            return instancia;
        }

        private Sesion()
        {
            gestorCategoria = new GestorCategorias();
            gestorContrasenia = new GestorContrasenias();
            gestorTarjetaCredito = new GestorTarjetaCredito();
            MisFuentes = new List<IFuente>();
            passwordMaestro = "";
            this.logueado = false;
        }

      

        public void Login(string password)
        {
            if (password != passwordMaestro || passwordMaestro == "") 
                throw new ExcepcionAccesoDenegado("El usuario o contraseña no son coinciden.");
            this.logueado = true;
           
        }

        public IEnumerable<Contrasenia> ContraseniasVulnerables(IFuente fuente)
        {
            return this.gestorContrasenia.ObtenerContraseniasVulnerables(fuente);
        }
 
        public IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables(IFuente fuente)
        {
            return this.gestorTarjetaCredito.ObtenerTarjetasVulnerables(fuente);
        }
        
        public void GuardarPrimerPassword(string primerPassword)
        {
            Validaciones.ValidarLargoTexto(primerPassword, 25, 5, "primer password");
            this.passwordMaestro = primerPassword;
        }

        public void CambiarPassword(string nuevoPassword)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado();
            Validaciones.ValidarLargoTexto(nuevoPassword, 25, 5, "nuevo password");
            this.passwordMaestro = nuevoPassword;
        }

        public int AltaCategoria(string nombreCategoria)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return this.gestorCategoria.Alta(nombreCategoria);
        }

        public void BajaCategoria(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            this.gestorCategoria.Baja(id);
        }

        public void ModificarCategoria(int id, string nombreNuevo)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            this.gestorCategoria.ModificarCategoria(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return gestorCategoria.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return this.gestorCategoria.ObtenerTodas();
        }

        public int AltaTarjetaCredito(TarjetaCredito nuevaTarjeta)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            BuscarCategoriaPorId(nuevaTarjeta.Categoria.Id);
            return this.gestorTarjetaCredito.Alta(nuevaTarjeta);
        }

        public void BajaTarjetaCredito(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            gestorTarjetaCredito.Baja(id);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            gestorTarjetaCredito.ModificarTarjeta(modificada);
        }

        public TarjetaCredito BuscarTarjeta(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return gestorTarjetaCredito.Buscar(id);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas()
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe estar logueado para realizar esta acción.");
            return gestorTarjetaCredito.ObtenerTodas();
        }

        public int AltaContrasenia(Contrasenia unaContrasena)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            gestorCategoria.BuscarCategoriaPorId(unaContrasena.Categoria.Id);
            return gestorContrasenia.Alta(unaContrasena);
        }

        public void BajaContrasenia(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            gestorContrasenia.Baja(id);
        }

        public void ModificarContrasenia(Contrasenia modificada)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            gestorContrasenia.ModificarContrasenia(modificada);
        }

        public Contrasenia BuscarContrasenia(int id)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return gestorContrasenia.Buscar(id);
        }

        public IEnumerable<Contrasenia> ObtenerTodasLasContrasenias()
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return gestorContrasenia.ObtenerTodas();
        }
       
        public string MostrarPassword(Contrasenia contrasenia)
        {
            if (!this.logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return gestorContrasenia.MostrarPassword(contrasenia);
        }

        public void LogOut()
        {
            this.logueado = false;
        }

        /* 
         * Método que se realiza para limpiar los datos de las pruebas unitarias
         * de sesión, debido a que la sesión es Singleton, no se limpian los datos
         * vacindo las listas.
         */
        public void VaciarDatosPrueba()
        {
            this.gestorContrasenia = new GestorContrasenias();
            this.gestorTarjetaCredito = new GestorTarjetaCredito();
            this.gestorCategoria = new GestorCategorias();
            this.MisFuentes = new List<IFuente>();
        }

        public void InsertarDatosDeMuestra()
        {
            int idestudio = AltaCategoria("Estudio");
            Categoria estudio = gestorCategoria.BuscarCategoriaPorId(idestudio);
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
