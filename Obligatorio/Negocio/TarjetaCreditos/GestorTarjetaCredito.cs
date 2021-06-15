using System.Collections.Generic;
using System.Linq;
using Negocio.DataBreaches;
using Negocio.Persistencia;
using Negocio.Persistencia.EntityFramework;
using Negocio.Persistencia.Memoria;

namespace Negocio.TarjetaCreditos
{
    public class GestorTarjetaCredito 
    {
        private const int LARGO_MAXIMO_NOMBRE = 25;
        private const int LARGO_MINIMO_NOMBRE = 3;
        private const int LARGO_MAXIO_TIPO = 25;
        private const int LARGO_MINIMO_TIPO = 3;
        private const int LARGONUMEROTARJETA = 16;
        private const int LARGO_CODIGO = 3;
                

        private IRepositorio<TarjetaCredito> repositorio;
      
        public GestorTarjetaCredito()
        {
            FabricaRepositorio fabrica = new FabricaRepositorio();
            this.repositorio = fabrica.CrearRepositorioTarjetaCredito();
        }

        public int Alta(TarjetaCredito unaTarjeta)
        {
            ValidarCampos(unaTarjeta);
            return repositorio.Alta(unaTarjeta);
        }

        public void Baja(int id)
        {
            TarjetaCredito borrar = new TarjetaCredito()
            {
                Id = id
            };
            repositorio.Baja(borrar);
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            ValidarCampos(modificada);
            repositorio.Modificar(modificada);
        }

        public TarjetaCredito Buscar(int id)
        {
            TarjetaCredito buscada = new TarjetaCredito()
            {
                Id = id
            };
            return repositorio.Buscar(buscada);
        }

        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }
        
        public IEnumerable<TarjetaCredito> ObtenerTarjetasVulnerables(List<IFuente> fuentes)
        {
            List<TarjetaCredito> tarjetasVulnerables = new List<TarjetaCredito>();
            IEnumerable<TarjetaCredito> todasLasTarjetas = this.ObtenerTodas();
            int cantidad = todasLasTarjetas.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarTarjetaSiEsVulnerable(tarjetasVulnerables, todasLasTarjetas.ElementAt(i), fuentes);
            }

            return tarjetasVulnerables;
        }

        private void AgregarTarjetaSiEsVulnerable(List<TarjetaCredito> tarjetas, TarjetaCredito item, List<IFuente> fuentes)
        {
            int cantidadVecesEnFuente = BuscarTarjetaCreditoEnFuente(item, fuentes);
            if (cantidadVecesEnFuente > 0)
            {
                item.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.ModificarTarjeta(item);
                tarjetas.Add(item);
            }

        }

        private int BuscarTarjetaCreditoEnFuente(TarjetaCredito item, List<IFuente> fuentes)
        {
            int cantidadDeVecesVulnerable = 0;
            foreach (IFuente fuente in fuentes)
            {
                cantidadDeVecesVulnerable += fuente.BuscarPasswordOContraseniaEnFuente(item.Numero);
            }
            return cantidadDeVecesVulnerable;
        }

        private void ValidarCampos(TarjetaCredito tarjeta)
        {
            Validaciones.ValidarLargoTexto(tarjeta.Nombre, LARGO_MAXIMO_NOMBRE, LARGO_MINIMO_NOMBRE, "nombre");
            Validaciones.ValidarLargoTexto(tarjeta.Tipo, LARGO_MAXIO_TIPO, LARGO_MINIMO_TIPO, "tipo");
            Validaciones.ValidarLargoTexto(tarjeta.Numero, LARGONUMEROTARJETA, LARGONUMEROTARJETA, "número");
            Validaciones.ValidarSoloNumeros(tarjeta.Numero, "número");
            Validaciones.ValidarLargoTexto(tarjeta.Codigo, LARGO_CODIGO, LARGO_CODIGO, "código");
            Validaciones.ValidarSoloNumeros(tarjeta.Codigo, "código");
            if(tarjeta.Nota != null){
                Validaciones.ValidarLargoTexto(tarjeta.Nota, 250, -1, "nota");
            }
        }
      
        public void LimpiarBD()
        {
            repositorio.TestClear();
        }


    }
}
