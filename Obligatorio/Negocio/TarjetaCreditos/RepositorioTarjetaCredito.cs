using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            nuevaTarjeta.IdTarjeta = autonumerado;
            autonumerado++;
            Tarjetas.Add(nuevaTarjeta);
            return nuevaTarjeta.IdTarjeta;

        }

        public void Baja(int bajaTarjeta)
        {
            Tarjetas.Remove(BuscarPorId(bajaTarjeta));
            
        }

        public void ModificarTarjeta(TarjetaCredito modificarTarjeta)
        {
            TarjetaCredito anterior = BuscarPorId(modificarTarjeta.IdTarjeta);

            anterior.Categoria = modificarTarjeta.Categoria;
            anterior.Nombre = modificarTarjeta.Nombre;
            anterior.Tipo = modificarTarjeta.Tipo;
            anterior.Numero = modificarTarjeta.Numero;
            anterior.Codigo = modificarTarjeta.Codigo;
            anterior.Vencimiento = modificarTarjeta.Vencimiento;
            anterior.Nota = modificarTarjeta.Nota;
            anterior.IdTarjeta = modificarTarjeta.IdTarjeta;
            anterior.CantidadVecesEncontradaVulnerable = modificarTarjeta.CantidadVecesEncontradaVulnerable;

        }

        public TarjetaCredito BuscarPorId(int id) {

            foreach (TarjetaCredito item in Tarjetas)
            {
                 if (item.IdTarjeta == id) return item;

            }
             throw new ExcepcionElementoNoExiste();

        }
                
        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            this.Tarjetas.Sort();
            return this.Tarjetas;

        }



    }
}
