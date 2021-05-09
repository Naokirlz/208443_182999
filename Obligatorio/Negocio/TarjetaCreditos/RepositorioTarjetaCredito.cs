using Negocio.Excepciones;
using System.Collections.Generic;

namespace Negocio.TarjetaCreditos
{
    public class RepositorioTarjetaCredito
    {
        private List<TarjetaCredito> Tarjetas { get; set; }
        private static int autonumerado = 1;

        public RepositorioTarjetaCredito()
        {
            this.Tarjetas = new List<TarjetaCredito>();
        }

        public int Alta(TarjetaCredito nuevaTarjeta)
        {
            NombreTarjetaRepetido(nuevaTarjeta);
            NumeroTarjetaRepetido(nuevaTarjeta);
            nuevaTarjeta.Id = autonumerado;
            autonumerado++;
            Tarjetas.Add(nuevaTarjeta);
            return nuevaTarjeta.Id;
        }

        public void Baja(int id)
        {
            Tarjetas.Remove(BuscarPorId(id));
        }

        public void ModificarTarjeta(TarjetaCredito modificarTarjeta)
        {
            TarjetaCredito anterior = BuscarPorId(modificarTarjeta.Id);
            NombreTarjetaRepetido(modificarTarjeta);
            NumeroTarjetaRepetido(modificarTarjeta);

            anterior.Categoria = modificarTarjeta.Categoria;
            anterior.Nombre = modificarTarjeta.Nombre;
            anterior.Tipo = modificarTarjeta.Tipo;
            anterior.Numero = modificarTarjeta.Numero;
            anterior.Codigo = modificarTarjeta.Codigo;
            anterior.Vencimiento = modificarTarjeta.Vencimiento;
            anterior.Nota = modificarTarjeta.Nota;
            anterior.Id = modificarTarjeta.Id;
            anterior.CantidadVecesEncontradaVulnerable = modificarTarjeta.CantidadVecesEncontradaVulnerable;
       }

        public TarjetaCredito BuscarPorId(int id) {

            foreach (TarjetaCredito item in Tarjetas)
                if (item.Id == id) return item;
            throw new ExcepcionElementoNoExiste();
        }
                
        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            this.Tarjetas.Sort();
            return this.Tarjetas;

        }

        private void NumeroTarjetaRepetido(TarjetaCredito tarjeta)
        {
            foreach (TarjetaCredito item in Tarjetas)
            {
                if (item.Numero.Equals(tarjeta.Numero) && tarjeta.Id != item.Id)
                { throw new ExcepcionElementoYaExiste(); }
            }
        }

        private void NombreTarjetaRepetido(TarjetaCredito tarjeta)
        {
            
            foreach (TarjetaCredito item in Tarjetas)
            {
                if (item.Nombre.ToLower().Equals(tarjeta.Nombre.ToLower())
                    && tarjeta.Id != item.Id)
                {
                    throw new ExcepcionElementoYaExiste();
                }
            }
        }



    }
}
