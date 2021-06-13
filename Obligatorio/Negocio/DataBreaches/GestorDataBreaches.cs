﻿using Negocio.Contrasenias;
using Negocio.Persistencia;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Historial histo = new Historial();
            histo.HistorialId = historial;
            Historial buscado = Buscar(histo);

            return buscado.passwords;
        }

        public IEnumerable<HistorialTarjetas> DevolverTarjetasVulnerables(int historial)
        {
            Historial histo = new Historial();
            histo.HistorialId = historial;
            Historial buscado = Buscar(histo);

            return buscado.tarjetasVulnerables;
        }
    
        public int Alta(Historial historial)
        {
            return repositorio.Alta(historial);
        }

        public Historial Buscar(Historial entity)
        {
            return repositorio.Buscar(entity);

        }
        public IEnumerable<Historial> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }


    }
}
