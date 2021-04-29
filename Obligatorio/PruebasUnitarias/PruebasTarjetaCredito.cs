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
    public class PruebasTarjetaCredito
    {
        private GestorTarjetaCredito Gestor = new GestorTarjetaCredito();
        
            TarjetaCredito nuevoTarjeta = new TarjetaCredito()
            {
                Categoria = new Categoria("Fake"),
                Nombre = "PruebaNombre",
                Tipo = "PruebaTipo",
                Numero = "1234123412341234",
                Codigo = "123",
                Vencimiento = DateTime.Now,
                Nota = "Nota Opcional"
            };

        TarjetaCredito otraTarjeta = new TarjetaCredito()
        {
            Categoria = new Categoria("Fake"),
            Nombre = "OtraTarjeta",
            Tipo = "PruebaTipo",
            Numero = "5234123412341235",
            Codigo = "123",
            Vencimiento = DateTime.Now,
            Nota = "Nota Opcional"
        };


        [TestMethod]
        public void AltaTarjetaDeCredito()
        {
        
            nuevoTarjeta = Gestor.Alta(nuevoTarjeta);
            Assert.IsNotNull(nuevoTarjeta);
           }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void AltaTarjetaDeCreditoNombreRepetido()
        {
           Gestor.Alta(nuevoTarjeta);
           otraTarjeta.Nombre = nuevoTarjeta.Nombre;
           Gestor.Alta(otraTarjeta);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void AltaTarjetaDeCreditoNumeroRepetido()
        {
            Gestor.Alta(nuevoTarjeta);
            otraTarjeta.Numero = nuevoTarjeta.Numero;
            Gestor.Alta(otraTarjeta);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreMenor3Caracteres()
        {
            nuevoTarjeta.Nombre = "12";
            Gestor.Alta(nuevoTarjeta);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreMayor25Caracteres()
        {
            nuevoTarjeta.Nombre = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(nuevoTarjeta);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoTipoMenor3Caracteres()
        {
            nuevoTarjeta.Tipo = "12";
            Gestor.Alta(nuevoTarjeta);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoLargoNombreTipo25Caracteres()
        {
            nuevoTarjeta.Tipo = ArmarTextoDeLargoVariable(26);
            Gestor.Alta(nuevoTarjeta);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoNumeroLargoDiferente16Caracteres()
        {
            nuevoTarjeta.Numero = ArmarTextoDeLargoVariable(15);
            Gestor.Alta(nuevoTarjeta);

            nuevoTarjeta.Numero = ArmarTextoDeLargoVariable(17);
            Gestor.Alta(nuevoTarjeta);

        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoCodigoLargoDiferente3Caracteres()
        {
            nuevoTarjeta.Codigo = ArmarTextoDeLargoVariable(2);
            Gestor.Alta(nuevoTarjeta);

            nuevoTarjeta.Codigo = ArmarTextoDeLargoVariable(4);
            Gestor.Alta(nuevoTarjeta);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void AltaTarjetaDeCreditoNumeroInvalido()
        {
            nuevoTarjeta.Numero = "aaaaaaaaaaaaaaaa";
            Gestor.Alta(nuevoTarjeta);


        }

        [TestMethod]
        public void AltaTarjetaDeCreditoNumerovalido()
        {
            nuevoTarjeta.Numero = "1234123412341234";
            TarjetaCredito prueba = Gestor.Alta(nuevoTarjeta);
            Assert.IsNotNull(prueba);


        }

        [TestMethod]
        public void AltaTarjetaDeCreditoCodigovalido()
        {
            nuevoTarjeta.Codigo = "123";
            TarjetaCredito prueba = Gestor.Alta(nuevoTarjeta);
            Assert.IsNotNull(prueba);

        }




        [TestMethod]
        [ExpectedException(typeof(ExcepcionNumeroNoValido))]
        public void AltaTarjetaDeCreditoCodigoInvalido()
        {
            nuevoTarjeta.Codigo = "aaa";
            Gestor.Alta(nuevoTarjeta);


        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoTexto))]
        public void AltaTarjetaDeCreditoNotaMayor250Caracteres()
        {
            nuevoTarjeta.Nota = ArmarTextoDeLargoVariable(251);
            Gestor.Alta(nuevoTarjeta);
                      

        }

        [TestMethod]
        public void ModificarNombreTarjetaCredito()
        {
            TarjetaCredito modificada = Gestor.Alta(nuevoTarjeta);
            modificada.Nombre = "Nuevo Nombre";
            Gestor.ModificarTarjeta(modificada);
            Assert.AreEqual("Nuevo Nombre", Gestor.Buscar(modificada).Nombre);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void ModificarNombreTarjetaCreditoNombreRepetido()
        {
            Gestor.Alta(nuevoTarjeta);
            Gestor.Alta(otraTarjeta);

            TarjetaCredito modificada = Gestor.Alta(nuevoTarjeta);
            modificada.Nombre = otraTarjeta.Nombre;
            Gestor.ModificarTarjeta(modificada);
         

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoYaExiste))]
        public void ModificarNumeroTarjetaCreditoNumeroRepetido()
        {
            Gestor.Alta(nuevoTarjeta);
            Gestor.Alta(otraTarjeta);

            TarjetaCredito modificada = Gestor.Alta(nuevoTarjeta);
            modificada.Numero = otraTarjeta.Numero;
            Gestor.ModificarTarjeta(modificada);


        }

        [TestMethod]
        public void ListarTarjetasCredito()
        {

            Gestor.Alta(nuevoTarjeta);
            List<TarjetaCredito> tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(1, tarjetas.Count);

            Gestor.Alta(otraTarjeta);
            tarjetas = Gestor.ObtenerTodas();
            Assert.AreEqual(2, tarjetas.Count);

        }

        [TestMethod]
        public void ListarTarjetasCreditoOrdenadaPorNombreCategoria()
        {
            nuevoTarjeta.Categoria.Nombre = "ZZZZZZ";
            Gestor.Alta(nuevoTarjeta);
            
            otraTarjeta.Categoria.Nombre = "AAAAAA";
            Gestor.Alta(otraTarjeta);

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

            TarjetaCredito prueba = Gestor.Alta(otraTarjeta);
            Assert.AreEqual(1, Gestor.ObtenerTodas().Count());
            Gestor.Baja(prueba);
            Assert.AreEqual(0, Gestor.ObtenerTodas().Count());
            


        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExiste))]
        public void EliminarTarjetaCreditoQuenNoExiste()
        {
           Gestor.Baja(otraTarjeta);
       
        }


        [TestMethod]
        
        public void EliminarClonNoMoficaListaOriginal()
        {

            Gestor.Alta(nuevoTarjeta);
            Gestor.Alta(otraTarjeta);
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
