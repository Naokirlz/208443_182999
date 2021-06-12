using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class HistorialContrasenia
    {

        [ForeignKey("Historial")]
        public DateTime Fecha { get; set; }

        public virtual Historial Historial { get; set; }

        public int ContraseniaId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

    }
}
