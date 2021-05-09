using System;
using System.Collections;
using System.Collections.Generic;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.Excepciones;
using Negocio.TarjetaCreditos;
using System.Linq;

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
            if (password != PasswordMaestro || PasswordMaestro == "") throw new ExcepcionAccesoDenegado("El usuario o contraseña no son coinciden.");
            this.Logueado = true;
        }

        public IEnumerable<Contrasenia> ContraseniasVulnerables(IFuente fuente)
        {
            
            List<Contrasenia> contrasenias = new List<Contrasenia>();
            IEnumerable<Contrasenia> todasLasContrasenias = this.GestorContrasenia.ObtenerTodas();
            int cantidad = todasLasContrasenias.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarContraseniaSiEsVulnerable(contrasenias, todasLasContrasenias.ElementAt(i), fuente);
            }
            return contrasenias;
        }
 
        public IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables(IFuente fuente)
        {
            List<TarjetaCredito> tarjetasVulnerables = new List<TarjetaCredito>();
            IEnumerable<TarjetaCredito> todasLasTarjetas = this.GestorTarjetaCredito.ObtenerTodas();
            int cantidad = todasLasTarjetas.Count();

            for (int i=0; i<cantidad; i++)
            {
                AgregarTarjetaSiEsVulnerable(tarjetasVulnerables, todasLasTarjetas.ElementAt(i), fuente);
            }

            return tarjetasVulnerables; 
            
            
        }

        private void AgregarContraseniaSiEsVulnerable(List<Contrasenia> contrasenias, Contrasenia contrasenia, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarContraseniaEnFuente(contrasenia, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                contrasenia.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                contrasenia.Password.Clave = this.GestorContrasenia.MostrarPassword(contrasenia.Password.Clave);
                this.GestorContrasenia.ModificarContrasenia(contrasenia);
                contrasenias.Add(contrasenia);
            }

        }

        public void GuardarPrimerPassword(string primerPassword)
        {
            ControlLargoTexto(primerPassword, 5, 25);
            this.PasswordMaestro = primerPassword;
        }

        public void CambiarPassword(string v)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            ControlLargoTexto(v, 5, 25);
            this.PasswordMaestro = v;
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
            this.GestorCategoria.Modificacion(id, nombreNuevo);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorCategoria.BuscarCategoriaPorId(id);
        }


        public IEnumerable<Categoria> ObtenerTodasLasCategorias()
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return this.GestorCategoria.ObtenerTodasLasCategorias();
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

       
        public string MostrarPassword(string password)
        {
            if (!this.Logueado) throw new ExcepcionAccesoDenegado();
            return GestorContrasenia.MostrarPassword(password);

        }

        public void LogOut()
        {
            this.Logueado = false;
        }

        private int BuscarContraseniaEnFuente(Contrasenia item, IFuente fuente)
        {
            string desencriptado = this.GestorContrasenia.MostrarPassword(item.Password.Clave);
            return fuente.BuscarPasswordOContraseniaEnFuente(desencriptado);

        }

        private void AgregarTarjetaSiEsVulnerable(List<TarjetaCredito> tarjetas, TarjetaCredito item, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarTarjetaCreditoEnFuente(item, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                item.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.GestorTarjetaCredito.ModificarTarjeta(item);
                tarjetas.Add(item);
            }

        }

        private int BuscarTarjetaCreditoEnFuente(TarjetaCredito item, IFuente fuente)
        {
            return fuente.BuscarPasswordOContraseniaEnFuente(item.Numero);
        }

        private void ControlLargoTexto(string texto, int minimo, int maximo)
        {
            texto = texto.Trim();
            if (texto.Length < minimo || texto.Length > maximo)
            {
                throw new ExcepcionLargoTexto("El largo de texto debe ser entre " + minimo.ToString() + " y " + maximo.ToString() + " caracteres.");
            }

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
