using Negocio.Contrasenias;
using Negocio.Persistencia;
using Negocio.Persistencia.EntityFramework;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Negocio.DataBreaches
{
    public class GestorDataBreaches
    {
        private IRepositorio<Historial> repositorio;

        public GestorDataBreaches()
        {
            this.repositorio = new RepositorioDataBreachesEntity();
        }


        public int ConsultarVulnerabilidades(IEnumerable<Contrasenia> ContraseniasVulnerables, IEnumerable<TarjetaCredito> TarjetasCreditoVulnerables)
        {
            Historial historial = new Historial();
            historial.Fecha = DateTime.Now;
            IEnumerable<Contrasenia> contraseniasVul = ContraseniasVulnerables;

            foreach (Contrasenia con in contraseniasVul)
            {
                HistorialContrasenia nuevo = new HistorialContrasenia();
                nuevo.ContraseniaId = con.ContraseniaId;
                historial.passwords.Add(nuevo);
            }

            IEnumerable<TarjetaCredito> tarjetasVul = TarjetasCreditoVulnerables;

            foreach (TarjetaCredito tarjeta in tarjetasVul)
            {
                HistorialTarjetas nuevo = new HistorialTarjetas();
                nuevo.NumeroTarjeta = tarjeta.Numero;
                historial.tarjetasVulnerables.Add(nuevo);
            }

            int registroHistorial = Alta(historial);
            return registroHistorial;
        }

        public IEnumerable<HistorialContrasenia> DevolverContraseniasVulnerables(int historial)
        {
            Historial buscado = Buscar(historial);
            return buscado.passwords;
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

        public void BajaDataBreachArchivos()
        {
            string rutaDirectorio = AppDomain.CurrentDomain.BaseDirectory + "\\Archivos";
            if (Directory.Exists(rutaDirectorio))
            {
                List<string> strFiles = Directory.GetFiles(rutaDirectorio, "*", SearchOption.AllDirectories).ToList();

                foreach (string fichero in strFiles)
                {
                    File.Delete(fichero);
                }
            }
        }
    }
}
