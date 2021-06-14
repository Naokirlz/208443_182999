using Negocio.DataBreaches;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.Persistencia.EntityFramework
{
    public class RepositorioDataBreachesEntity:IRepositorio<Historial>
    {
      
        public int Alta(Historial historial)
        {
            using (Contexto context = new Contexto())
            {
                context.Historials.Add(historial);

                foreach (HistorialContrasenia pas in historial.passwords)
                {
                    pas.Clave = context.Contrasenias.FirstOrDefault(c => c.ContraseniaId == pas.ContraseniaId).Password.Clave;
                    context.HistorialContrasenia.Add(pas);
                }
                foreach (HistorialTarjetas tar in historial.tarjetasVulnerables)
                {
                    context.HistorialTarjeta.Add(tar);
                }
                context.SaveChanges();
                return historial.HistorialId;
               
             
            }

        }

        public void Baja(Historial entity)
        {
            using (Contexto context = new Contexto())
            {
                Historial aEliminar = context.Historials.FirstOrDefault(c => c.HistorialId == entity.HistorialId);

                if (aEliminar != null)
                {
                    context.Historials.Remove(aEliminar);
                    context.SaveChanges();
                }
                else throw new ExcepcionElementoNoExiste("Error: Historial No Existe !!!");
            }
        }

        public Historial Buscar(Historial entity)
        {
            using (Contexto context = new Contexto())
            {
                Existe(entity);
                Historial existe = context.Historials.FirstOrDefault(t => t.HistorialId == entity.HistorialId);
                existe.passwords = context.HistorialContrasenia.Where(t => t.HistorialId == entity.HistorialId).ToList();
                existe.tarjetasVulnerables = context.HistorialTarjeta.Where(t => t.HistorialId == entity.HistorialId).ToList();
                return existe;
                
            }
        }


        public IEnumerable<Historial> ObtenerTodas()
        {
            using (Contexto context = new Contexto())
            {
                List<Historial> retorno;
                retorno = context.Historials.ToList();
                //retorno.Sort();
                return retorno;
            }
        }
        public void Existe(Historial entity)
        {
            using (Contexto context = new Contexto())
            {
                Historial existe = context.Historials.FirstOrDefault(t => t.HistorialId == entity.HistorialId);
                if (existe == null)
                    throw new ExcepcionElementoNoExiste("No existe Historial!");
            }
        }

        public void Modificar(Historial entity)
        {
            throw new InvalidOperationException();
        }
 
        public void TestClear()
        {
            throw new InvalidOperationException();
        }
    }
}
