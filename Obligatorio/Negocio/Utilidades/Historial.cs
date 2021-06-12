using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
{
    public class Historial
    {
        
        [Key]
        [Required]
        public DateTime Fecha{ get; set; }

        public List <HistorialContrasenia> passwords { get; set; }
        public List <HistorialTarjetas> tarjetasVulnerables { get; set; }



        public Historial()
        {

            this.passwords = new List<HistorialContrasenia>();
            this.tarjetasVulnerables = new List<HistorialTarjetas>();

        }


        public DateTime Guardar()
        {
            using (Contexto context = new Contexto())
            {
                
                context.Historials.Add(this);

                foreach (HistorialContrasenia pas in passwords)
                {
                    pas.Clave =  context.Contrasenias.FirstOrDefault(c => c.ContraseniaId == pas.ContraseniaId).Password.Clave;
                    context.HistorialContrasenia.Add(pas);
                }
                foreach (HistorialTarjetas tar in tarjetasVulnerables)
                {
                    context.HistorialTarjeta.Add(tar);
                }

                try
                {
                    context.SaveChanges();
                    return this.Fecha;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
       
    }
}
