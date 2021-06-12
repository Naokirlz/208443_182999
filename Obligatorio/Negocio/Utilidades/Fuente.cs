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
    [Table("DataBreaches")]
    public abstract class Fuente
    {
        [Required]
        public string[] Breaches;
        [Required]
        [Key]
        public int Id;
        public string FuenteType;
        
        public abstract void CrearDatabreach(string databreach);
    }
}
