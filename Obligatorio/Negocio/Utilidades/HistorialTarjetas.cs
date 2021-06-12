using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class HistorialTarjetas
    {
        [ForeignKey("Historial")]
        public int HistorialId { get; set; }

        public virtual Historial Historial { get; set; }

        public string NumeroTarjeta { get; set; }
    }
}
