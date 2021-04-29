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




        public List<string> ContraseniasVulnerables(IFuente fuente)
        {
            List<string> retorno = new List<string>();
            foreach (Contrasenia item in this.GestorContrasenia.ListarContrasenias())
            {
                if (fuente.Buscar(item.Password))
                {
                    retorno.Add(item.Password);
                }
            }
            return retorno;
        }

        public List<string> TarjetasCreditoVulnerables(IFuente fuente)
        {
            List<string> retorno = new List<string>();
            foreach (TarjetaCredito item in this.GestorTarjetaCredito.ObtenerTodas())
            {
                if (fuente.Buscar(item.Numero))
                {
                    retorno.Add(item.Numero);
                }
            }
            return retorno;
        }

    }
}
