using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Negocio.TarjetaCreditos;
using Negocio.Categorias;
using Negocio.Excepciones;
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
        TarjetaCredito TarjetaDePruebaUno;
        TarjetaCredito TarjetaDePruebaDos;

       [TestInitialize]
        public void InicializarPruebas()
        {

            Gestor = new GestorTarjetaCredito();

            TarjetaDePruebaUno = new TarjetaCredito()
            {
                Categoria = new Categoria("Fake"),
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

            TarjetaDePruebaDos = new TarjetaCredito()
            {
                Categoria = new Categoria("Fake"),
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
            TarjetaDePruebaUno = Gestor.Alta(TarjetaDePruebaUno);
            Assert.IsNotNull(TarjetaDePruebaUno);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void AltaTarjetaDeCreditoNombreRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            TarjetaDePruebaDos.Nombre = TarjetaDePruebaUno.Nombre;
            Gestor.Alta(TarjetaDePruebaDos);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void AltaTarjetaDeCreditoNumeroRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            TarjetaDePruebaDos.Numero = TarjetaDePruebaUno.Numero;
            Gestor.Alta(TarjetaDePruebaDos);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreMenor3Caracteres()
        {
            TarjetaDePruebaUno.Nombre = "12";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreMayor25Caracteres()
        {
            TarjetaDePruebaUno.Nombre = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoTipoMenor3Caracteres()
        {
            TarjetaDePruebaUno.Tipo = "12";
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreTipo25Caracteres()
        {
            TarjetaDePruebaUno.Tipo = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoNumeroLargoDiferente16Caracteres()
        {
            TarjetaDePruebaUno.Numero = ArmarTextoDeLargoVariable(15);
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaUno.Numero = ArmarTextoDeLargoVariable(17);
            Gestor.Alta(TarjetaDePruebaUno);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoCodigoLargoDiferente3Caracteres()
        {
            TarjetaDePruebaUno.Codigo = ArmarTextoDeLargoVariable(2);
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaUno.Codigo = ArmarTextoDeLargoVariable(4);
            Gestor.Alta(TarjetaDePruebaUno);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void AltaTarjetaDeCreditoNumeroInvalido()
        {
            TarjetaDePruebaUno.Numero = "aaaaaaaaaaaaaaaa";
            Gestor.Alta(TarjetaDePruebaUno);


        }

        [TestMethod]
        public void AltaTarjetaDeCreditoNumerovalido()
        {
            TarjetaDePruebaUno.Numero = "1234123412341234";
            TarjetaCredito prueba = Gestor.Alta(TarjetaDePruebaUno);
            Assert.IsNotNull(prueba);


        }

        [TestMethod]
        public void AltaTarjetaDeCreditoCodigovalido()
        {
            TarjetaDePruebaUno.Codigo = "123";
            TarjetaCredito prueba = Gestor.Alta(TarjetaDePruebaUno);
            Assert.IsNotNull(prueba);

        }




        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void AltaTarjetaDeCreditoCodigoInvalido()
        {
            TarjetaDePruebaUno.Codigo = "aaa";
            Gestor.Alta(TarjetaDePruebaUno);


        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoNotaMayor250Caracteres()
        {
            TarjetaDePruebaUno.Nota = ArmarTextoDeLargoVariable(251);
            Gestor.Alta(TarjetaDePruebaUno);


        }

        [TestMethod]
        public void ModificarNombreTarjetaCredito()
        {
            TarjetaCredito modificada = Gestor.Alta(TarjetaDePruebaUno);
            modificada.Nombre = "Nuevo Nombre";
            Gestor.ModificarTarjeta(modificada);
            Assert.AreEqual("Nuevo Nombre", Gestor.Buscar(modificada).Nombre);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void ModificarNombreTarjetaCreditoNombreRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            Gestor.Alta(TarjetaDePruebaDos);

            TarjetaCredito modificada = Gestor.Alta(TarjetaDePruebaUno);
            modificada.Nombre = TarjetaDePruebaDos.Nombre;
            Gestor.ModificarTarjeta(modificada);


        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void ModificarNumeroTarjetaCreditoNumeroRepetido()
        {
            Gestor.Alta(TarjetaDePruebaUno);
            Gestor.Alta(TarjetaDePruebaDos);

            TarjetaCredito modificada = Gestor.Alta(TarjetaDePruebaUno);
            modificada.Numero = TarjetaDePruebaDos.Numero;
            Gestor.ModificarTarjeta(modificada);


        }

        [TestMethod]
        public void ListarTarjetasCredito()
        {

            Gestor.Alta(TarjetaDePruebaUno);
            List<TarjetaCredito> tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(1, tarjetas.Count);

            Gestor.Alta(TarjetaDePruebaDos);
            tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(2, tarjetas.Count);

        }

        [TestMethod]
        public void ListarTarjetasCreditoOrdenadaPorNombreCategoria()
        {
            TarjetaDePruebaUno.Categoria.Nombre = "ZZZZZZ";
            Gestor.Alta(TarjetaDePruebaUno);

            TarjetaDePruebaDos.Categoria.Nombre = "AAAAAA";
            Gestor.Alta(TarjetaDePruebaDos);

            TarjetaCredito tarjetaPrueba = new TarjetaCredito()
            {
                Categoria = new Categoria("BBBBBB"),
                Nombre = "bbbbbbb",
                Tipo = "PruebaTipo",
                Numero = "1234126412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

            Gestor.Alta(tarjetaPrueba);


            List<TarjetaCredito> tarjetas = Gestor.ObtenerTodas();

            Assert.AreEqual("AAAAAA", tarjetas[0].Categoria.Nombre);
            Assert.AreEqual("BBBBBB", tarjetas[1].Categoria.Nombre);
            Assert.AreEqual("ZZZZZZ", tarjetas[2].Categoria.Nombre);


        }

        [TestMethod]

        public void EliminarTarjetaCredito()
        {

            TarjetaCredito prueba = Gestor.Alta(TarjetaDePruebaDos);
            Assert.AreEqual(1, Gestor.ObtenerTodas().Count());
            Gestor.Baja(prueba);
            Assert.AreEqual(0, Gestor.ObtenerTodas().Count());



        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void EliminarTarjetaCreditoQuenNoExiste()
        {
            Gestor.Baja(TarjetaDePruebaDos);

        }


        [TestMethod]

        public void EliminarClonNoMoficaListaOriginal()
        {

            Gestor.Alta(TarjetaDePruebaUno);
            Gestor.Alta(TarjetaDePruebaDos);
            List<TarjetaCredito> clon = Gestor.ObtenerTodas();
            clon.Clear();

            Assert.AreNotEqual(0, Gestor.ObtenerTodas().Count);

        }

        [TestMethod]
        public void ElMetodoToStringDevuelveElNombre()
        {
            TarjetaCredito tarjeta = new TarjetaCredito()
            {
                Nombre = "Nombre",
            };
            string nombre = tarjeta.ToString();
            Assert.AreEqual("Nombre", nombre);
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
