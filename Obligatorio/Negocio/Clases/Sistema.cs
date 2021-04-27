using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class Sistema
    {
        private static Sistema Sesion;

        public GestorCategorias GestorCategoria { get; set; }
        public GestorContrasenias GestorContrasenia { get; set; }
        public GestorTarjetaCredito GestorTarjetaCredito { get; set; }

       

        private Sistema()
        {

            GestorCategoria = new GestorCategorias();
            GestorContrasenia = new GestorContrasenias();
            GestorTarjetaCredito = new GestorTarjetaCredito();

        }


        public static Sistema Singleton
        {
            get
            {
                if (Sesion == null) Sesion = new Sistema();
                return Sesion;
            }

        }

        public bool Login(string password)
        {
            return password == "secreto";
        }

        
    }
}
