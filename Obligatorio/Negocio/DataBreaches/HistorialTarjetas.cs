using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio.DataBreaches
{
    public class HistorialTarjetas
    {
        [ForeignKey("Historial")]
        public int HistorialId { get; set; }

        public virtual Historial Historial { get; set; }

        public string NumeroTarjeta { get; set; }
    }
}
