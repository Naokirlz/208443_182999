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

       

        private Sesion()
        {

            GestorCategoria = new GestorCategorias();
            GestorContrasenia = new GestorContrasenias();
            GestorTarjetaCredito = new GestorTarjetaCredito();

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

        
    }
}
