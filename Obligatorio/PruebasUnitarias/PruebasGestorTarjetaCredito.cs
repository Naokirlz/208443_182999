using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.TarjetaCreditos;
using Negocio.Categorias;
using Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasGestorTarjetaCredito
    {
        private GestorTarjetaCredito Gestor;
        private GestorCategorias GestorCategoria;
        TarjetaCredito TarjetaDePruebaUno;
        TarjetaCredito TarjetaDePruebaDos;

       [TestInitialize]
        public void InicializarPruebas()
        {

            Gestor = new GestorTarjetaCredito();
            GestorCategoria = new GestorCategorias();
            Gestor.LimpiarBD();
            Categoria c = new Categoria("Fake");
            GestorCategoria.Alta("Fake");
           
            TarjetaDePruebaUno = new TarjetaCredito()
            {
                Categoria = c,
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

            TarjetaDePruebaDos = new TarjetaCredito()
            {
                Categoria = c,
                Nombre = "OtraTarjeta",
                Tipo = "PruebaTipo",
                Numero = "5234123412341235",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

        }


        [TestCleanup]
        public void LimpiarPruebas()
        {
            Gestor = null;
            TarjetaDePruebaUno = null;
            TarjetaDePruebaDos = null;
        }


        [TestMethod]
        public void AltaTarjetaDeCredito()
        {
            int cantidadAntes = Gestor.ObtenerTodas().Count();
            Gestor.Alta(TarjetaDePruebaUno);
            int cantidadActual = Gestor.ObtenerTodas().Count();
            Assert.AreEqual(1, cantidadActual - cantidadAntes);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeDarAltaTarjetaDeCreditoNombreRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            TarjetaDePruebaDos.Nombre = TarjetaDePruebaUno.Nombre;
            Gestor.Alta(TarjetaDePruebaDos);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeDarAltaTarjetaDeCreditoNumeroRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            TarjetaDePruebaDos.Numero = TarjetaDePruebaUno.Numero;
            Gestor.Alta(TarjetaDePruebaDos);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoLargoNombreMenor3Caracteres()
        {
            TarjetaDePruebaUno.Nombre = "12";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoLargoNombreMayor25Caracteres()
        {
            TarjetaDePruebaUno.Nombre = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoLargoTipoMenor3Caracteres()
        {
            TarjetaDePruebaUno.Tipo = "12";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoLargoNombreTipo25Caracteres()
        {
            TarjetaDePruebaUno.Tipo = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoNumeroLargoDiferente16Caracteres()
        {
            TarjetaDePruebaUno.Numero = ArmarTextoDeLargoVariable(15);
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaUno.Numero = ArmarTextoDeLargoVariable(17);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoCodigoLargoDiferente3Caracteres()
        {
            TarjetaDePruebaUno.Codigo = ArmarTextoDeLargoVariable(2);
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaUno.Codigo = ArmarTextoDeLargoVariable(4);
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void NoSePuedeDarAltaTarjetaDeCreditoNumeroInvalido()
        {
            TarjetaDePruebaUno.Numero = "aaaaaaaaaaaaaaaa";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void NoSePuedeDarAltaTarjetaDeCreditoOtroNumeroInvalido()
        {
            TarjetaDePruebaUno.Numero = "!!!!!!!!!!!!!!!!";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        public void AltaTarjetaDeCreditoNumerovalido()
        {
            TarjetaDePruebaUno.Numero = "1234123412341234";
            int idPrueba = Gestor.Alta(TarjetaDePruebaUno);
            Assert.IsNotNull(idPrueba);

        }

        [TestMethod]
        public void AltaTarjetaDeCreditoCodigovalido()
        {
            TarjetaDePruebaUno.Codigo = "123";
            int idPrueba = Gestor.Alta(TarjetaDePruebaUno);
            Assert.IsNotNull(idPrueba);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void NoSePuedeDarAltaTarjetaDeCreditoCodigoInvalido()
        {
            TarjetaDePruebaUno.Codigo = "aaa";
            Gestor.Alta(TarjetaDePruebaUno);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void NoSePuedeDarAltaTarjetaDeCreditoNotaMayor250Caracteres()
        {
            TarjetaDePruebaUno.Nota = ArmarTextoDeLargoVariable(251);
            Gestor.Alta(TarjetaDePruebaUno);
        }

        [TestMethod]
        public void ModificarNombreTarjetaCredito()
        {
            int modificada = Gestor.Alta(TarjetaDePruebaUno);
            TarjetaDePruebaUno = Gestor.Buscar(modificada);
            TarjetaDePruebaUno.Nombre = "Nuevo Nombre";
            Gestor.ModificarTarjeta(TarjetaDePruebaUno);
            Assert.AreEqual("Nuevo Nombre", Gestor.Buscar(modificada).Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void NoSePuedeModificarNombreTarjetaCreditoNombreRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            int idTarjeta2 = Gestor.Alta(TarjetaDePruebaDos);

            TarjetaDePruebaDos = Gestor.Buscar(idTarjeta2);
            TarjetaDePruebaDos.Nombre = TarjetaDePruebaUno.Nombre;

            Gestor.ModificarTarjeta(TarjetaDePruebaDos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void ModificarNumeroTarjetaCreditoNumeroRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            int idTarjeta2 = Gestor.Alta(TarjetaDePruebaDos);

            TarjetaDePruebaDos = Gestor.Buscar(idTarjeta2);
            TarjetaDePruebaDos.Numero = TarjetaDePruebaUno.Numero;

            Gestor.ModificarTarjeta(TarjetaDePruebaDos);

        }

        [TestMethod]
        public void ListarTarjetasCredito()
        {

            Gestor.Alta(TarjetaDePruebaUno);
            IEnumerable<TarjetaCredito> tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(1, tarjetas.Count());

            Gestor.Alta(TarjetaDePruebaDos);
            tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(2, tarjetas.Count());

        }

        [TestMethod]
        public void ListarTarjetasCreditoOrdenadaPorNombreCategoria()
        {
            Categoria z = new Categoria("ZZZZZZ");
            GestorCategoria.Alta("ZZZZZZ");

            Categoria a = new Categoria("AAAAAA");
            GestorCategoria.Alta("AAAAAA");

            Categoria b = new Categoria("BBBBBB");
            GestorCategoria.Alta("BBBBBB");


            TarjetaDePruebaUno.Categoria = z;
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaDos.Categoria = a;
            Gestor.Alta(TarjetaDePruebaDos);

            TarjetaCredito tarjetaPrueba = new TarjetaCredito()
            {
                Categoria = b,
                Nombre = "bbbbbbb",
                Tipo = "PruebaTipo",
                Numero = "1234126412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

            Gestor.Alta(tarjetaPrueba);

            IEnumerable<TarjetaCredito> tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual("AAAAAA", tarjetas.ElementAt(0).Categoria.Nombre);
            Assert.AreEqual("BBBBBB", tarjetas.ElementAt(1).Categoria.Nombre);
            Assert.AreEqual("ZZZZZZ", tarjetas.ElementAt(2).Categoria.Nombre);
        }

        [TestMethod]

        public void EliminarTarjetaCredito()
        {
           int idTarjeta= Gestor.Alta(TarjetaDePruebaDos);
           int cantidadAntes = Gestor.ObtenerTodas().Count();
           Gestor.Baja(idTarjeta);
           int cantidadDespues = Gestor.ObtenerTodas().Count();
            
           Assert.AreEqual(1, cantidadAntes - cantidadDespues);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void EliminarTarjetaCreditoQuenNoExiste()
        {
            Gestor.Baja(20000);
        }


        [TestMethod]
        public void ElMetodoToStringDevuelveElNombre()
        {
            TarjetaCredito tarjeta = new TarjetaCredito()
            {
                Nombre = "Nombre",
            };
            Assert.AreEqual("Nombre", tarjeta.ToString());
        }

        private string ArmarTextoDeLargoVariable(int largo)
        {

            string retorno = "";
            for (int i = 0; i < largo; i++)
            {
                retorno += "a";

            }

            return retorno;

        }


    }
}
