using Negocio.DataBreaches;
using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia
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

                try
                {
                    context.SaveChanges();
                    return historial.HistorialId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public void Baja(Historial entity)
        {
            throw new NotImplementedException();
        }

        public Historial Buscar(Historial entity)
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
            throw new NotImplementedException();
        }

        public void Modificar(Historial entity)
        {
            throw new NotImplementedException();
        }
                

        public void TestClear()
        {
            throw new NotImplementedException();
        }
    }
}
