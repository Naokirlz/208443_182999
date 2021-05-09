using System.Collections.Generic;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;

namespace Negocio
{
    public class Sesion
    {
        private static Sesion Instancia;
        public GestorCategorias GestorCategoria { get; set; }
        public GestorContrasenias GestorContrasenia { get; set; }
        public GestorTarjetaCredito GestorTarjetaCredito { get; set; }
        public List<IFuente> MisFuentes { get; set; }
        public string PasswordMaestro { get; set; }
        private bool Logueado { get; set; }
       
        private Sesion()
        {
            GestorCategoria = new GestorCategorias();
            GestorContrasenia = new GestorContrasenias();
            GestorTarjetaCredito = new GestorTarjetaCredito();
            MisFuentes = new List<IFuente>();
            PasswordMaestro = "";
            this.Logueado = false;
        }

        public static Sesion Singleton
        {
            get
            {
                if (Instancia == null) Instancia = new Sesion();
                return Instancia;
            }
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

        public void CambiarPassword(string nuevoPass)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            Validaciones.ValidarLargoTexto(nuevoPass, 25, 5, "nuevo password");
            this.PasswordMaestro = nuevoPass;
        }

        public int AltaCategoria(string v)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return this.GestorCategoria.Alta(v);
        }

        public void BajaCategoria(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            this.GestorCategoria.Baja(id);
        }

        public void ModificacionCategoria(int id, string nombreNuevo)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            this.GestorCategoria.ModificarCategoria(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorCategoria.BuscarCategoriaPorId(id);
        }

        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return this.GestorCategoria.ObtenerTodas();
        }

        public int AltaTarjetaCredito(TarjetaCredito nuevaTarjeta)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return this.GestorTarjetaCredito.Alta(nuevaTarjeta);
        }

        public void BajaTarjetaCredito(int bajaTarjeta)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            GestorTarjetaCredito.Baja(bajaTarjeta);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            GestorTarjetaCredito.ModificarTarjeta(modificada);
        }

        public TarjetaCredito BuscarTarjeta(int idBuscada)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorTarjetaCredito.Buscar(idBuscada);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodasLasTarjetas()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorTarjetaCredito.ObtenerTodas();
        }

        public int AltaContrasenia(Contrasenia unaContrasena)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            return GestorContrasenia.Alta(unaContrasena);
        }

        public void BajaContrasenia(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            GestorContrasenia.Baja(id);
        }

        public void ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado("Debe iniciar sesión para acceder a este método.");
            GestorContrasenia.ModificarContrasenia(aModificarContrasenia);
        }

        public Contrasenia BuscarContrasenia(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorContrasenia.Buscar(id);
        }

        public IEnumerable<Contrasenia> ListarContrasenias()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorContrasenia.ObtenerTodas();
        }

        public string VerificarFortaleza(Contrasenia nuevaContrasenia)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return nuevaContrasenia.Password.ColorPassword.ToString();
        }
       
        public string MostrarPassword(Contrasenia contrasenia)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorContrasenia.MostrarPassword(contrasenia);
        }

        public void LogOut()
        {
            this.Logueado = false;
        }

        private void InsertarDatosDeMuestra()
        {
            AltaCategoria("Estudio");
            AltaCategoria("Hogar");
            AltaCategoria("Familia");
            AltaCategoria("Trabajo");
            
        }

    }
}
