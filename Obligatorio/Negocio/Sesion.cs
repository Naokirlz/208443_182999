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
        public IFuente FuenteLocal { get; set; }
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
            FuenteLocal = new FuenteLocal();
            passwordMaestro = "";
            this.logueado = false;
        }

      

        public void Login(string password)
        {
            if (password != passwordMaestro || passwordMaestro == "") 
                throw new ExcepcionAccesoDenegado("El usuario o contraseña no son coinciden.");
            this.logueado = true;
           
        }

        public IEnumerable<Contrasenia> ContraseniasVulnerables()
        {
            return this.gestorContrasenia.ObtenerContraseniasVulnerables(FuenteLocal);
        }
 
        public IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables()
        {
            return this.gestorTarjetaCredito.ObtenerTarjetasVulnerables(FuenteLocal);
        }
        
        public void GuardarPrimerPassword(string primerPassword)
        {
            Validaciones.ValidarPassword(primerPassword, 25, 5);
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
            this.gestorContrasenia.LimpiarBD();
            this.FuenteLocal = new FuenteLocal();
        }

        public int ConsultarVulnerabilidades()
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;

            IEnumerable<Contrasenia> contraseniasVul = ContraseniasVulnerables();

            foreach(Contrasenia con in contraseniasVul)
            {
                HistorialContrasenia nuevo = new HistorialContrasenia();
                nuevo.ContraseniaId = con.ContraseniaId;
                historial.passwords.Add(nuevo);
            }

            IEnumerable<TarjetaCredito> tarjetasVul = TarjetasCreditoVulnerables();

            foreach (TarjetaCredito tarjeta in tarjetasVul)
            {
                HistorialTarjetas nuevo = new HistorialTarjetas();
                nuevo.NumeroTarjeta = tarjeta.Numero;
                historial.tarjetasVulnerables.Add(nuevo);
            }

            int registroHistorial = historial.Guardar();

            return registroHistorial;
        }

        public IEnumerable<HistorialContrasenia> DevolverContraseniasVulnerables(int historial)
        {
            Historial histo = new Historial();
            histo.HistorialId = historial;
            Historial buscado = histo.ObtenerHistorial(histo);

            return buscado.passwords;
        }

        public IEnumerable<HistorialTarjetas> DevolverTarjetasVulnerables(int historial)
        {
            Historial histo = new Historial();
            histo.HistorialId = historial;
            Historial buscado = histo.ObtenerHistorial(histo);

            return buscado.tarjetasVulnerables;
        }

        public IEnumerable<Historial> DevolverHistoriales()
        {
            Historial historial = new Historial();
            return historial.DevolverHistoriales();
        }
    }
}
