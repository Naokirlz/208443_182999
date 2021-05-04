using System;
using System.Collections.Generic;
using Negocio.Categorias;
using Negocio.Contrasenias;
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
       
        private Sesion()
        {
            GestorCategoria = new GestorCategorias();
            GestorContrasenia = new GestorContrasenias();
            GestorTarjetaCredito = new GestorTarjetaCredito();
            MisFuentes = new List<IFuente>();
        }

        public static Sesion Singleton
        {
            get
            {
                if (Instancia == null) Instancia = new Sesion();
                return Instancia;
            }

        }

        public bool Login(string password)
        {
            return password == "secreto";
        }

        public List<Contrasenia> ContraseniasVulnerables(IFuente fuente)
        {
            List<Contrasenia> contrasenias = new List<Contrasenia>();
            
            foreach (Contrasenia contrasenia in this.GestorContrasenia.ListarContrasenias())
            {
                AgregarContraseniaSiEsVulnerable(contrasenias, contrasenia, fuente);
            }
            return contrasenias;
        }
 
        public List<TarjetaCredito> TarjetasCreditoVulnerables(IFuente fuente)
        {
            List<TarjetaCredito> tarjetasVulnerables = new List<TarjetaCredito>();
            
            foreach (TarjetaCredito tarjeta in this.GestorTarjetaCredito.ObtenerTodas())
            {
                AgregarTarjetaSiEsVulnerable(tarjetasVulnerables, tarjeta, fuente);
            }
            return tarjetasVulnerables;
        }

        private void AgregarContraseniaSiEsVulnerable(List<Contrasenia> contrasenias, Contrasenia contrasenia, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarContraseniaEnFuente(contrasenia, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                contrasenia.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                contrasenia.Password = this.GestorContrasenia.MostrarPassword(contrasenia.Password);
                this.GestorContrasenia.ModificarContrasenia(contrasenia);
                contrasenias.Add(contrasenia);
            }

        }

        private int BuscarContraseniaEnFuente(Contrasenia item, IFuente fuente)
        {
            string desencriptado = this.GestorContrasenia.MostrarPassword(item.Password);
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


    }
}
