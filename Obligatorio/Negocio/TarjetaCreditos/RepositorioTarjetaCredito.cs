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


        public TarjetaCredito Alta(TarjetaCredito nuevaTarjeta)
        {
            nuevaTarjeta.IdTarjeta = autonumerado;
            autonumerado++;
            Tarjetas.Add(nuevaTarjeta);
            return nuevaTarjeta;

        }

        public void Baja(TarjetaCredito bajaTarjeta)
        {
            Tarjetas.Remove(bajaTarjeta);
            
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


        //ver otra solucion sin clon porque roba tiempo hacer el clon
        public List<TarjetaCredito> RetornarListaRepositorioClonada()
        {
            List<TarjetaCredito> clonTarjetas = new List<TarjetaCredito>();

            foreach (TarjetaCredito item in Tarjetas)
            {
                clonTarjetas.Add(ClonarTarjeta(item));

            }
            clonTarjetas.Sort();

            return clonTarjetas;

        }


        private TarjetaCredito ClonarTarjeta(TarjetaCredito original) {


            TarjetaCredito clon = new TarjetaCredito()
            {
                Categoria = original.Categoria,
                Nombre = original.Nombre,
                Tipo = original.Tipo,
                Numero = original.Numero,
                Codigo = original.Codigo,
                Vencimiento = original.Vencimiento,
                Nota = original.Nota,
                IdTarjeta = original.IdTarjeta,
                CantidadVecesEncontradaVulnerable = original.CantidadVecesEncontradaVulnerable
            };

            return clon;

        }




    }
}
