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
      
        public GestorTarjetaCredito()
        {
            this.Repositorio = new RepositorioTarjetaCredito();
        }


        public int Alta(TarjetaCredito nuevaTarjeta)
        {
            ControlAltaYModificar(nuevaTarjeta);
            return Repositorio.Alta(nuevaTarjeta);
        }


        public void Baja(int idBajaTarjeta)
        {
            Buscar(idBajaTarjeta);
            Repositorio.Baja(idBajaTarjeta);
        }


        public void ModificarTarjeta(TarjetaCredito modificada)
        {
            Buscar(modificada.IdTarjeta);
            ControlAltaYModificar(modificada);
            Repositorio.ModificarTarjeta(modificada);
        }


        public TarjetaCredito Buscar(int buscada)
        {
            return Repositorio.BuscarPorId(buscada);
        }


        public IEnumerable<TarjetaCredito> ObtenerTodas()
        {
            return Repositorio.ObtenerTodas();
        }

        private void ControlAltaYModificar(TarjetaCredito tarjeta)
        {
            CategoriaExiste(tarjeta.Categoria);
            ControlLargoTexto(tarjeta.Nombre, 3, 25, "nombre");
            NombreTarjetaRepetido(tarjeta);
            ControlLargoTexto(tarjeta.Tipo, 3, 25, "tipo");
            ControlLargoTexto(tarjeta.Numero, 16, 16, "número");
            NumeroTarjetaRepetido(tarjeta);
            ControlSoloNumeros(tarjeta.Numero);
            ControlLargoTexto(tarjeta.Codigo, 3, 3, "código");
            ControlSoloNumeros(tarjeta.Codigo);
            ControlLargoTexto(tarjeta.Nota, -1, 250, "nota");
            
        }

        private bool CategoriaExiste(Categoria categoria)
        {
            //buscar categoria en lista de categorias existentes
            return true;

        }

        private void ControlLargoTexto(string texto, int minimo, int maximo, string campo)
        {
            texto = texto.Trim();
            if (texto.Length < minimo || texto.Length > maximo)
            {
                throw new ExcepcionLargoTexto("El campo " + campo + " debe tener entre " + minimo.ToString() + " y " + maximo.ToString() + " caracteres.");
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
            IEnumerable<TarjetaCredito> tarjetas = Repositorio.ObtenerTodas();
            foreach (TarjetaCredito item in tarjetas)
            {
                if (item.Numero.Equals(tarjeta.Numero) && tarjeta.IdTarjeta != item.IdTarjeta)
                        { throw new ExcepcionElementoYaExiste(); } 
            }
        }

        private void NombreTarjetaRepetido(TarjetaCredito tarjeta)
        {
            IEnumerable<TarjetaCredito> tarjetas = Repositorio.ObtenerTodas();
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
