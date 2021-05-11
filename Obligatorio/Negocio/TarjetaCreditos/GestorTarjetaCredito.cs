﻿using System.Collections.Generic;
using System.Linq;
using Negocio.Utilidades;

namespace Negocio.TarjetaCreditos
{
    public class GestorTarjetaCredito 
    {
        private RepositorioTarjetaCredito repositorio;
      
        public GestorTarjetaCredito()
        {
            this.repositorio = new RepositorioTarjetaCredito();
        }

        public int Alta(TarjetaCredito unaTarjeta)
        {
            ValidarCampos(unaTarjeta);
            return repositorio.Alta(unaTarjeta);
        }

        public void Baja(int id)
        {
            repositorio.Baja(id);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            ValidarCampos(modificada);
            repositorio.ModificarTarjeta(modificada);
        }

        public TarjetaCredito Buscar(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }
        
        public IEnumerable<TarjetaCredito> ObtenerTarjetasVulnerables(IFuente fuente)
        {
            List<TarjetaCredito> tarjetasVulnerables = new List<TarjetaCredito>();
            IEnumerable<TarjetaCredito> todasLasTarjetas = this.ObtenerTodas();
            int cantidad = todasLasTarjetas.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarTarjetaSiEsVulnerable(tarjetasVulnerables, todasLasTarjetas.ElementAt(i), fuente);
            }

            return tarjetasVulnerables;
        }

        private void AgregarTarjetaSiEsVulnerable(List<TarjetaCredito> tarjetas, TarjetaCredito item, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarTarjetaCreditoEnFuente(item, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                item.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.ModificarTarjeta(item);
                tarjetas.Add(item);
            }

        }

        private int BuscarTarjetaCreditoEnFuente(TarjetaCredito item, IFuente fuente)
        {
            return fuente.BuscarPasswordOContraseniaEnFuente(item.Numero);
        }

        private void ValidarCampos(TarjetaCredito tarjeta)
        {
            Validaciones.ValidarLargoTexto(tarjeta.Nombre, 25, 3, "nombre");
            Validaciones.ValidarLargoTexto(tarjeta.Tipo, 25, 3, "tipo");
            Validaciones.ValidarLargoTexto(tarjeta.Numero, 16, 16, "número");
            Validaciones.ValidarSoloNumeros(tarjeta.Numero, "número");
            Validaciones.ValidarLargoTexto(tarjeta.Codigo, 3, 3, "código");
            Validaciones.ValidarSoloNumeros(tarjeta.Codigo, "código");
            if(tarjeta.Nota != null){
                Validaciones.ValidarLargoTexto(tarjeta.Nota, 250, -1, "nota");
            }
        }
       
    }
}
