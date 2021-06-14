using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
using Negocio.Excepciones;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Negocio.DataBreaches;

namespace Interfaz
{
    public partial class Configuracion : UserControl
    {
        private Sesion Sesion = Sesion.ObtenerInstancia();

        public Configuracion()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string passwordInicial = this.txtPassword.Text;
            string passwordRepetido = this.txtRepetirPassword.Text;
            try
            {
                if (passwordInicial != passwordRepetido)
                {
                    Alerta("Los passwords deben coincidir.", AlertaToast.enmTipo.Error);
                    return;
                }
                Sesion sesion = Sesion.ObtenerInstancia();
                sesion.CambiarPassword(passwordRepetido);
                this.txtPassword.Text = "";
                this.txtRepetirPassword.Text = "";
                Alerta("Los cambios fueron configurados con éxito", AlertaToast.enmTipo.Exito);
            }
            catch (ExcepcionLargoTexto errorLargoTexto)
            {
                Alerta(errorLargoTexto.Message, AlertaToast.enmTipo.Error);
            }
        }

        private void Alerta(string mensaje, AlertaToast.enmTipo tipo)
        {
            AlertaToast alerta = new AlertaToast();
            alerta.MostrarAlerta(mensaje, tipo);
        }

        private void btnCargarDatosPrueba_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarDatosDeMuestra();
            }
            catch (ExcepcionElementoYaExiste excepcion)
            {
                Alerta("Primero elimine los datos.", AlertaToast.enmTipo.Error);
            }
        }

        private void InsertarDatosDeMuestra()
        {
            CargarCategorias();
            CargarTarjetas();
            CargarContrasenias();
            CargarVulnerabilidades();
            this.btnCargarDatosPrueba.Enabled = false;
            Alerta("Datos cargados con éxito.", AlertaToast.enmTipo.Exito);
        }

        private void CargarCategorias()
        {
            Sesion.AltaCategoria("Estudio");
            Sesion.AltaCategoria("Hogar");
            Sesion.AltaCategoria("Familia");
            Sesion.AltaCategoria("Trabajo");
        }
        private void CargarTarjetas()
        {
            TarjetaCredito nueva = new TarjetaCredito()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[1],
                Codigo = 123.ToString(),
                Nombre = "Visa República",
                Numero = "1231231231231231",
                Tipo = "Visa",
                Vencimiento = DateTime.Now
            };
            TarjetaCredito nueva1 = new TarjetaCredito()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[0],
                Codigo = 123.ToString(),
                Nombre = "Visa Maestro",
                Numero = "4540556322541185",
                Tipo = "Visa",
                Vencimiento = DateTime.Now
            };
            TarjetaCredito nueva2 = new TarjetaCredito()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[2],
                Codigo = 123.ToString(),
                Nombre = "Oca",
                Numero = "8558954744542212",
                Tipo = "Oca",
                Vencimiento = DateTime.Now
            };
            Sesion.AltaTarjetaCredito(nueva);
            Sesion.AltaTarjetaCredito(nueva1);
            Sesion.AltaTarjetaCredito(nueva2);
        }
        private void CargarContrasenias()
        {
            Contrasenia contrasenia1 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[1],
                Password=new Password("passwordSS"),
                Sitio="netflix.com",
                Usuario="falonso"
            };
            Contrasenia contrasenia2 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[0],
                Password = new Password("AA ss1223AASas[[3 faa da"),
                Sitio = "canvas.com",
                Usuario = "usucanvas"
            };
            Contrasenia contrasenia3 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[1],
                Password = new Password("aaaaa"),
                Sitio = "Aplicación Banco",
                Usuario = "falonso@gmail.com"
            };
            Contrasenia contrasenia4 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[3],
                Password = new Password("sda asd asd a"),
                Sitio = "facebook.com",
                Usuario = "cpalma@gmail.com"
            };
            Contrasenia contrasenia5 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[0],
                Password = new Password("secreTo"),
                Sitio = "amazon.com",
                Usuario = "usuarioAmazon"
            };
            Contrasenia contrasenia6 = new Contrasenia()
            {
                Categoria = Sesion.ObtenerTodasLasCategorias().ToList()[2],
                Password = new Password("passwordSS"),
                Sitio = "Spotify",
                Usuario = "palmaCristian"
            };

            int id1 = Sesion.AltaContrasenia(contrasenia1);
            int id2 = Sesion.AltaContrasenia(contrasenia2);
            int id3 = Sesion.AltaContrasenia(contrasenia3);
            int id4 = Sesion.AltaContrasenia(contrasenia4);
            int id5 = Sesion.AltaContrasenia(contrasenia5);
            int id6 = Sesion.AltaContrasenia(contrasenia6);
            Sesion.BuscarContrasenia(id1).FechaUltimaModificacion = DateTime.Now.AddDays(-8);
            Sesion.BuscarContrasenia(id2).FechaUltimaModificacion = DateTime.Now.AddDays(-10);
            Sesion.BuscarContrasenia(id3).FechaUltimaModificacion = DateTime.Now.AddDays(-30);
            Sesion.BuscarContrasenia(id4).FechaUltimaModificacion = DateTime.Now.AddDays(-1);
            Sesion.BuscarContrasenia(id5).FechaUltimaModificacion = DateTime.Now.AddDays(-15);
            Sesion.BuscarContrasenia(id6).FechaUltimaModificacion = DateTime.Now.AddDays(-7);
        }
        private void CargarVulnerabilidades()
        {
            Sesion.CargarDataBreachLocal("aaaaa\nsecreTo\n1231231231231231\n8558954744542212");

        }

        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            VentanaConfirmarBool confirmacion = new VentanaConfirmarBool("Realmente desea eliminar los datos?");
            confirmacion.Show();
            if (confirmacion.Respuesta)
            {
                Sesion.VaciarDatosPrueba();
                this.btnCargarDatosPrueba.Enabled = true;
                Alerta("Datos borrados con éxito.", AlertaToast.enmTipo.Exito);
            }
            confirmacion.Close();
        }

        private void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            VentanaConfirmarBool confirmacion = new VentanaConfirmarBool("Realmente desea eliminar los datos?");
            confirmacion.Show();
            if (confirmacion.Respuesta)
            {
                try
                {
                    if (chkArchivos.Checked)
                    {
                        Sesion.BajaDataBreachArchivos();
                        chkArchivos.Checked = false;
                    }
                    if (chkHistorial.Checked)
                    {
                        List<Historial> historiales = Sesion.ObtenerTodasLosHistoriales().ToList();
                        foreach (Historial historial in historiales)
                        {
                            Sesion.BajaHistorial(historial.HistorialId);
                            chkHistorial.Checked = false;
                        }
                    }
                    if (chkFuenteLocal.Checked)
                    {
                        Sesion.BajaDataBreachLocal();
                        chkFuenteLocal.Checked = false;
                    }
                    if (chkTarjetas.Checked)
                    {
                        List<TarjetaCredito> tarjetas = Sesion.ObtenerTodasLasTarjetas().ToList();
                        foreach (TarjetaCredito tarjeta in tarjetas)
                        {
                            Sesion.BajaTarjetaCredito(tarjeta.Id);
                        }
                        chkTarjetas.Checked = false;
                    }
                    if (chkContrasenias.Checked)
                    {
                        List<Contrasenia> contrasenias = Sesion.ObtenerTodasLasContrasenias().ToList();
                        foreach (Contrasenia contrasenia in contrasenias)
                        {
                            Sesion.BajaContrasenia(contrasenia.ContraseniaId);
                        }
                        chkContrasenias.Checked = false;
                    }
                    if (chkCategorias.Checked)
                    {
                        List<Categoria> categorias = Sesion.ObtenerTodasLasCategorias().ToList();
                        foreach (Categoria categoria in categorias)
                        {
                            Sesion.BajaCategoria(categoria.Id);
                        }
                        chkCategorias.Checked = false;
                    }

                    //no hace un rollback, lo que elimina antes del error ya no aparece mas
                    Alerta("Datos eliminados con satisfactoriamente.", AlertaToast.enmTipo.Exito);
                }
                catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    Alerta("Error de base de datos al intentar borrar los datos.\n" + ex.Message, AlertaToast.enmTipo.Error);
                }
            }
            confirmacion.Close();
        }
    }
}
