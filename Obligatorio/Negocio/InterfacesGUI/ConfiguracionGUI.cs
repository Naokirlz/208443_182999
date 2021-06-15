using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesGUI
{
    public class ConfiguracionGUI : IConfiguracion
    {
        private Sesion sesion;
        public ConfiguracionGUI()
        {
            sesion = Sesion.ObtenerInstancia();
        }
    }
}
