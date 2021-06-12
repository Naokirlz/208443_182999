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
        public string[] Breaches { get; set; }
                
        //public virtual List<DataBreach> List { get; set; }
        

        public abstract void CrearDatabreach(string databreach);
    }
}
