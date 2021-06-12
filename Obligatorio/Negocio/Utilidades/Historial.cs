using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Utilidades
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


        public int Guardar()
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
                    return this.HistorialId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public Historial ObtenerHistorial(Historial entity)
        {
            using (Contexto context = new Contexto())
            {

                Historial existe = context.Historials.FirstOrDefault(t => t.HistorialId == entity.HistorialId);
                existe.passwords = context.HistorialContrasenia.Where(t => t.HistorialId == entity.HistorialId).ToList();
                existe.tarjetasVulnerables = context.HistorialTarjeta.Where(t => t.HistorialId == entity.HistorialId).ToList();

                if (existe != null) return existe;
                throw new ExcepcionElementoNoExiste("No existe Historial!");

            }
        }

        public IEnumerable<Historial> DevolverHistoriales()
        {
            using (Contexto context = new Contexto())
            {
                List<Historial> retorno;
                retorno = context.Historials.ToList();
                //retorno.Sort();
                return retorno;
            }
        }
    }
}
