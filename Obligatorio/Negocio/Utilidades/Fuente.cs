using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Negocio.Persistencia;

namespace Negocio.Utilidades
{
    
    public abstract class Fuente
    {

        public static int autonumerado = 2;

        public int Id { get; set; }
                
        public List<DataBreach> ttttttttt { get; set; }

        public abstract void CrearDatabreach(string texto);

        


    }
}
