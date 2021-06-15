using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.DataBreaches;
using Negocio.Persistencia.EntityFramework;
using Negocio.Persistencia.Memoria;
using Negocio.TarjetaCreditos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia
{
    public class FabricaRepositorio
    {
        private string entorno_persistencia;
        public FabricaRepositorio()
        {
            entorno_persistencia = ConfigurationManager.AppSettings["ENTORNO_PERSISTENCIA"];
        }

        public IRepositorio<Categoria> CrearRepositorioCategorias()
        {
            IRepositorio<Categoria> repositorio;
            if (entorno_persistencia.Equals("Entity"))
            {
                repositorio = new RepositorioCategoriasEntity();
            }
            else
            {
                repositorio = new RepositorioCategoriasMemoria();
            }
            return repositorio;
        }

        internal IRepositorio<TarjetaCredito> CrearRepositorioTarjetaCredito()
        {
            IRepositorio<TarjetaCredito> repositorio;
            if (entorno_persistencia.Equals("Entity"))
            {
                repositorio = new RepositorioTarjetaCreditoEntity();
            }
            else
            {
                repositorio = new RepositorioTarjetaCreditoMemoria();
            }
            return repositorio;
        }

        internal IRepositorio<Historial> CrearRepositorioDataBreaches()
        {
            //No esta implementado repositorio en memoria para los data breaches
            return new RepositorioDataBreachesEntity();
        }

        public IRepositorio<Contrasenia> CrearRepositorioContrasenias()
        {
            IRepositorio<Contrasenia> repositorio;
            if (entorno_persistencia.Equals("Entity"))
            {
                repositorio = new RepositorioContraseniasEntity();
            }
            else
            {
                repositorio = new RepositorioContraseniasMemoria();
            }
            return repositorio;
        }
    }
}
