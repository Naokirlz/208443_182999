using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Contrasenia> retorno = new List<Contrasenia>();
            
            foreach (Contrasenia item in this.GestorContrasenia.ListarContrasenias())
            {
                string desencriptado = this.GestorContrasenia.MostrarPassword(item.Password);
                int cantidadVecesEnFuente = fuente.BuscarPasswordOContraseniaEnFuente(desencriptado);

                if (cantidadVecesEnFuente > 0)
                {
                    item.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                    this.GestorContrasenia.ModificarContrasenia(item);
                    retorno.Add(item);
                }
            }
            return retorno;
        }

        public List<TarjetaCredito> TarjetasCreditoVulnerables(IFuente fuente)
        {
            List<TarjetaCredito> retorno = new List<TarjetaCredito>();
            
            foreach (TarjetaCredito item in this.GestorTarjetaCredito.ObtenerTodas())
            {
                int cantidadVecesEnFuente = fuente.BuscarPasswordOContraseniaEnFuente(item.Numero);
                if (cantidadVecesEnFuente > 0)
                {
                    item.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                    this.GestorTarjetaCredito.ModificarTarjeta(item);
                    retorno.Add(item);
                }
            }
            return retorno;
        }


    }
}
