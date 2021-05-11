using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.TarjetaCreditos
{
    public class RepositorioTarjetaCredito
    {
        private static int autonumerado = 1;
        private List<TarjetaCredito> tarjetas;
        

        public RepositorioTarjetaCredito()
        {
            this.tarjetas = new List<TarjetaCredito>();
        }

        public int Alta(TarjetaCredito nuevaTarjeta)
        {
            VerificarNombreTarjetaRepetido(nuevaTarjeta);
            VerificarNumeroTarjetaRepetido(nuevaTarjeta);
            nuevaTarjeta.Id = autonumerado;
            autonumerado++;
            tarjetas.Add(nuevaTarjeta);
            return nuevaTarjeta.Id;
        }

        public void Baja(int id)
        {
            tarjetas.Remove(BuscarPorId(id));
        }

        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            TarjetaCredito anterior = BuscarPorId(modificada.Id);
            VerificarNombreTarjetaRepetido(modificada);
            VerificarNumeroTarjetaRepetido(modificada);

            anterior.Categoria = modificada.Categoria;
            anterior.Nombre = modificada.Nombre;
            anterior.Tipo = modificada.Tipo;
            anterior.Numero = modificada.Numero;
            anterior.Codigo = modificada.Codigo;
            anterior.Vencimiento = modificada.Vencimiento;
            anterior.Nota = modificada.Nota;
            anterior.Id = modificada.Id;
            anterior.CantidadVecesEncontradaVulnerable = modificada.CantidadVecesEncontradaVulnerable;
       }

        public TarjetaCredito BuscarPorId(int id) {

            foreach (TarjetaCredito item in tarjetas)
                if (item.Id == id) return item;
            throw new ExcepcionElementoNoExiste("La tarjeta buscada no existe.");
        }
                
        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            this.tarjetas.Sort();
            return this.tarjetas;

        }

        private void VerificarNumeroTarjetaRepetido(TarjetaCredito tarjeta)
        {
            foreach (TarjetaCredito item in tarjetas)
            {
                if (item.Numero.Equals(tarjeta.Numero) && tarjeta.Id != item.Id)
                { throw new ExcepcionElementoYaExiste("La tarjeta buscada ya existe."); }
            }
        }

        private void VerificarNombreTarjetaRepetido(TarjetaCredito tarjeta)
        {
            
            foreach (TarjetaCredito item in tarjetas)
            {
                if (item.Nombre.ToLower().Equals(tarjeta.Nombre.ToLower())
                    && tarjeta.Id != item.Id)
                {
                    throw new ExcepcionElementoYaExiste("La tarjeta buscada ya existe.");
                }
            }
        }
    }
}
