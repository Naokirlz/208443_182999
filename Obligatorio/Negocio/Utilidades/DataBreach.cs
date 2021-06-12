using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class DataBreach
    {

        [Key, ForeignKey("Fuente")]
        public int FuenteId { get; set; }

        public virtual Fuente Fuente { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        public string Texto { get; set; }

    }
}
