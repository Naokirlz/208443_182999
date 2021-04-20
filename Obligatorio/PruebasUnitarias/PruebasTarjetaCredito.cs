using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasTarjetaCredito
    {
        //private GestorCategorias Gestor = new GestorCategorias();
        [TestMethod]
        
        public void AltaTarjetaDeCredito()
        {
            TarjetaCredito nueva = new TarjetaCredito();

            Categoria categoria = new Categoria("Dummy");
            string nombreTarjeta = "PruebaNombre";
            string tipoTarjeta = "PruebaTipo";
            string numeroTarjeta = "1234-1234-1234-1234";
            int codigoTarjeta = 123;
            DateTime vencimientoTarjeta = DateTime.Now;
            string notaOpcionalTarjeta = "Nota Opcional";

            nueva.Categoria = categoria;
            nueva.Nombre = nombreTarjeta;
            nueva.Tipo = tipoTarjeta;
            nueva.Numero = numeroTarjeta;
            nueva.Codigo = codigoTarjeta;
            nueva.Vencimiento = vencimientoTarjeta;
            nueva.Nota = notaOpcionalTarjeta;



        }


    }
}
