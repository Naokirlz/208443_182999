using Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Categorias;

namespace Negocio.TarjetaCreditos
{
    public class GestorTarjetaCredito 
    {

        public RepositorioTarjetaCredito Repositorio;
        //necesito que el gestor de categorias me diga las categorias existentes
        //para comprobar que exista en el sistema la categoria de la tarjeta a agregar

        public GestorTarjetaCredito()
        {

            this.Repositorio = new RepositorioTarjetaCredito();

        }



        public TarjetaCredito Alta(TarjetaCredito nuevaTarjeta)
        {

            ControlAltaYModificar(nuevaTarjeta);
            return Repositorio.Alta(nuevaTarjeta);

        }


        public void Baja(TarjetaCredito bajaTarjeta)
        {
            Buscar(bajaTarjeta);
            Repositorio.Baja(bajaTarjeta);

        }


        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            Buscar(modificada);
            ControlAltaYModificar(modificada);
            Repositorio.Modificar(modificada);
        }


        public TarjetaCredito Buscar(TarjetaCredito buscada)
        {

            return Repositorio.BuscarPorId(buscada.IdTarjeta);
            //si no la encuentra tira excepcion

        }


        public List<TarjetaCredito> ObtenerTodas()
        {

            return Repositorio.Clon();

        }

        


        private void ControlAltaYModificar(TarjetaCredito nuevaTarjeta)
        {
            CategoriaExiste(nuevaTarjeta.Categoria);
            ControlLargoTexto(nuevaTarjeta.Nombre, 3, 25);
            NombreTarjetaRepetido(nuevaTarjeta);
            ControlLargoTexto(nuevaTarjeta.Tipo, 3, 25);
            ControlLargoTexto(nuevaTarjeta.Numero, 16, 16);
            NumeroTarjetaRepetido(nuevaTarjeta);
            ControlSoloNumeros(nuevaTarjeta.Numero);
            ControlLargoTexto(nuevaTarjeta.Codigo, 3, 3);
            ControlSoloNumeros(nuevaTarjeta.Codigo);
            ControlLargoTexto(nuevaTarjeta.Nota, -1, 250);
          

        }




        private bool CategoriaExiste(Categoria categoria)
        {
            //buscar categoria en lista de categorias existentes
            return true;

        }

        private void ControlLargoTexto(string texto, int minimo, int maximo)
        {

            if (texto.Length < minimo || texto.Length > maximo)
            {
                throw new ExcepcionLargoTexto();
            }

        }

        private void ControlSoloNumeros(string texto)
        {
            foreach (char digito in texto)
            {
                if (!EsNumero(digito))
                {

                    throw new ExcepcionNumeroNoValido();

                }

            }


        }

        private bool EsNumero(char digito)
        {

            if (Convert.ToInt32(digito) >= 48 && Convert.ToInt32(digito) <= 57)
            {
                return true;

            }

            return false;

        }



        private void NumeroTarjetaRepetido(TarjetaCredito tarjeta)
        {
            List<TarjetaCredito> tarjetas = Repositorio.Clon();
            foreach (TarjetaCredito item in tarjetas)
            {
                if (item.Numero.Equals(tarjeta.Numero) && tarjeta.IdTarjeta != item.IdTarjeta)
                        { throw new ExcepcionElementoYaExiste(); } 
            }
        }

        private void NombreTarjetaRepetido(TarjetaCredito tarjeta)
        {
            List<TarjetaCredito> tarjetas = Repositorio.Clon();
            foreach (TarjetaCredito item in tarjetas)
            {
                if (item.Nombre.ToLower().Equals(tarjeta.Nombre.ToLower()) 
                    && tarjeta.IdTarjeta != item.IdTarjeta) { 
                    throw new ExcepcionElementoYaExiste(); 
                }
            }
        }

       
    }
}
