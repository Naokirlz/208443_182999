using Negocio.Contrasenias;
using Negocio.Persistencia;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;

namespace Negocio.DataBreaches
{
    public class GestorDataBreaches
    {
        private IRepositorio<Historial> repositorio;
        private List<IFuente> fuentes;
        private FabricaFuentes fabricaFuentes;

        public GestorDataBreaches()
        {
            FabricaRepositorio fabricaRepositorio = new FabricaRepositorio();
            this.repositorio = fabricaRepositorio.CrearRepositorioDataBreaches();
            fabricaFuentes = new FabricaFuentes();
            this.fuentes = fabricaFuentes.FabricarFuentes();
        }

        public int ConsultarVulnerabilidades(IEnumerable<Contrasenia> ContraseniasVulnerables, IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables)
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            IEnumerable<Contrasenia> contraseniasVul = ContraseniasVulnerables;
            AgregarContraseniasVulnerables(historial, contraseniasVul);

            IEnumerable<TarjetaCredito> tarjetasVul = TarjetasCreditoVulnerables;
            AgregarTarjetasVulnerables(historial,tarjetasVul);

            int registroHistorial = Alta(historial);
            return registroHistorial;
        }
        private void AgregarTarjetasVulnerables(Historial historial, IEnumerable<TarjetaCredito> tarjetasVul)
        {
            foreach (TarjetaCredito tarjeta in tarjetasVul)
            {
                HistorialTarjetas nuevo = new HistorialTarjetas();
                nuevo.NumeroTarjeta = tarjeta.Numero;
                historial.tarjetasVulnerables.Add(nuevo);
            }
        }
        private void AgregarContraseniasVulnerables(Historial historial, IEnumerable<Contrasenia> contraseniasVul)
        {
            foreach (Contrasenia con in contraseniasVul)
            {
                HistorialContrasenia nuevo = new HistorialContrasenia();
                nuevo.ContraseniaId = con.ContraseniaId;
                historial.passwords.Add(nuevo);
            }
        }
        public IEnumerable<HistorialContrasenia> DevolverContraseniasVulnerables(int historial)
        {
            Historial buscado = Buscar(historial);
            return buscado.passwords;
        }

        public void CargarDataBreach(IFuente fuente, string cadena)
        {
            fabricaFuentes.CrearDataBreach(fuente, cadena);
        }

        public IEnumerable<HistorialTarjetas> DevolverTarjetasVulnerables(int historial)
        {
            Historial buscado = Buscar(historial);
            return buscado.tarjetasVulnerables;
        }
    
        public int Alta(Historial historial)
        {
            return repositorio.Alta(historial);
        }
        
        public void Baja(int id)
        {
            Historial aEliminar = new Historial();
            aEliminar.HistorialId = id;
            repositorio.Baja(aEliminar);
        }

        public Historial Buscar(int id)
        {
            Historial buscado = new Historial();
            buscado.HistorialId = id;
            return repositorio.Buscar(buscado);
        }
        public IEnumerable<Historial> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }

        public void LimpiarBD()
        {
            repositorio.TestClear();
        }

        public List<IFuente> ObtenerFuentes()
        {
            return this.fuentes;
        }
        public void LimpiarFuentes()
        {
            fabricaFuentes.LimpiarFuentes();
        }
    }
}
