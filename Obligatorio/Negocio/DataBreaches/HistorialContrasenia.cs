using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio.DataBreaches
{
    public class HistorialContrasenia
    {

        [ForeignKey("Historial")]
        public int HistorialId { get; set; }

        public virtual Historial Historial { get; set; }

        public int ContraseniaId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

    }
}
