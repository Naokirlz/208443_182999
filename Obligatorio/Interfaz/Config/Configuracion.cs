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
using Interfaz.Alertas;
using System.Configuration;
using Negocio.InterfacesGUI;

namespace Interfaz.Config
{
    public partial class Configuracion : UserControl
    {
        private IConfiguracion sesion = new ConfiguracionGUI();

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
                string contexto = ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
                if(contexto.Equals("ContextoProd"))
                {
                    sesion.CambiarContextoDeBaseDeDatos("ContextoTest");
                    btnCargarDatosPrueba.Text = "Cambiar a Produccion";
                }
                else
                {
                    sesion.CambiarContextoDeBaseDeDatos("ContextoProd");
                    btnCargarDatosPrueba.Text = "Cambiar a Test";
                }
                //InsertarDatosDeMuestra();
            }
            catch (ExcepcionElementoYaExiste excepcion)
            {
                Alerta("Primero elimine los datos.", AlertaToast.enmTipo.Error);
            }
        }

        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            VentanaConfirmarBool confirmacion = new VentanaConfirmarBool("Realmente desea eliminar los datos?");
            confirmacion.Show();
            bool respuesta = confirmacion.Respuesta;
            confirmacion.Close();
            if (respuesta)
            {
                sesion.VaciarDatosPrueba();
                Alerta("Datos borrados con éxito.", AlertaToast.enmTipo.Exito);
            }
        }

        private void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            VentanaConfirmarBool confirmacion = new VentanaConfirmarBool("Realmente desea eliminar los datos?");
            confirmacion.Show();
            bool respuesta = confirmacion.Respuesta;
            confirmacion.Close();
            if (respuesta)
            {
                try
                {
                    if (chkArchivos.Checked)
                    {
                        sesion.BajaDataBreachArchivos();
                        chkArchivos.Checked = false;
                    }
                    if (chkHistorial.Checked)
                    {
                        List<Historial> historiales = sesion.ObtenerTodasLosHistoriales().ToList();
                        foreach (Historial historial in historiales)
                        {
                            sesion.BajaHistorial(historial.HistorialId);
                            chkHistorial.Checked = false;
                        }
                    }
                    if (chkFuenteLocal.Checked)
                    {
                        sesion.BajaDataBreachLocal();
                        chkFuenteLocal.Checked = false;
                    }
                    if (chkTarjetas.Checked)
                    {
                        List<TarjetaCredito> tarjetas = sesion.ObtenerTodasLasTarjetas().ToList();
                        foreach (TarjetaCredito tarjeta in tarjetas)
                        {
                            sesion.BajaTarjetaCredito(tarjeta.Id);
                        }
                        chkTarjetas.Checked = false;
                    }
                    if (chkContrasenias.Checked)
                    {
                        List<Contrasenia> contrasenias = sesion.ObtenerTodasLasContrasenias().ToList();
                        foreach (Contrasenia contrasenia in contrasenias)
                        {
                            sesion.BajaContrasenia(contrasenia.ContraseniaId);
                        }
                        chkContrasenias.Checked = false;
                    }
                    if (chkCategorias.Checked)
                    {
                        List<Categoria> categorias = sesion.ObtenerTodasLasCategorias().ToList();
                        foreach (Categoria categoria in categorias)
                        {
                            sesion.BajaCategoria(categoria.Id);
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
        }
    }
}
