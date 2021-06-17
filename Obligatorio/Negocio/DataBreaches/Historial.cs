using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Negocio.DataBreaches
{
    public class Historial
    {
        
        [Key]
        public int HistorialId { get; set; }

        [Required]
        public DateTime Fecha{ get; set; }

        public List <HistorialContrasenia> passwords { get; set; }
        public List <HistorialTarjetas> tarjetasVulnerables { get; set; }

        public Historial()
        {
            this.passwords = new List<HistorialContrasenia>();
            this.tarjetasVulnerables = new List<HistorialTarjetas>();
        }
    }
}
