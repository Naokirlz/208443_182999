using Negocio.TarjetaCreditos;
using Negocio.Utilidades;
using System.Collections.Generic;

namespace Negocio.Persistencia
{
    public class RepositorioTarjetaCreditoMemoria:IRepositorio<TarjetaCredito>
    {
        private static int autonumerado = 1;
        private List<TarjetaCredito> tarjetas;
        

        public RepositorioTarjetaCreditoMemoria()
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

        public void Baja(TarjetaCredito bajaTarjeta)
        {
            tarjetas.Remove(Buscar(bajaTarjeta));
        }

        public void Modificar(TarjetaCredito modificada)
        {
            TarjetaCredito anterior = Buscar(modificada);
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

        public TarjetaCredito Buscar(TarjetaCredito buscada) {

            foreach (TarjetaCredito item in tarjetas)
                if (item.Id == buscada.Id) return item;
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

        public void Existe(TarjetaCredito entity)
        {
            throw new System.NotImplementedException();
        }

        public void TestClear()
        {
            throw new System.NotImplementedException();
        }
    }
}
