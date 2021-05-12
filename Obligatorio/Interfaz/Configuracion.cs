using Negocio;
using Negocio.Categorias;
using Negocio.Contrasenias;
using Negocio.TarjetaCreditos;
using Negocio.Utilidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Configuracion : UserControl
    {
        private Sesion Sesion = Sesion.ObtenerInstancia();

        public IFuente FuenteLocal { get; private set; }

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
                Password = new Password("AA ss1223AASasd[[3 faas da"),
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

            Sesion.AltaContrasenia(contrasenia1);
            Sesion.AltaContrasenia(contrasenia2);
            Sesion.AltaContrasenia(contrasenia3);
            Sesion.AltaContrasenia(contrasenia4);
            Sesion.AltaContrasenia(contrasenia5);
            Sesion.AltaContrasenia(contrasenia6);
        }
        private void CargarVulnerabilidades()
        {
            bool encontre = false;
            foreach (IFuente fuente in Sesion.MisFuentes)
            {
                string tipoFuente = fuente.GetType().ToString();
                if (tipoFuente == "Negocio.FuenteLocal")
                {
                    this.FuenteLocal = fuente;
                    encontre = true;
                }
            }

            if (!encontre)
            {
                this.FuenteLocal = new FuenteLocal();
                this.Sesion.MisFuentes.Add(this.FuenteLocal);
            }

            FuenteLocal.AgregarPasswordOContraseniaVulnerable("aaaaa");
            FuenteLocal.AgregarPasswordOContraseniaVulnerable("secreTo");
            FuenteLocal.AgregarPasswordOContraseniaVulnerable("1231231231231231");
            FuenteLocal.AgregarPasswordOContraseniaVulnerable("8558954744542212");

        }

        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            Sesion.VaciarDatosPrueba();
            this.btnCargarDatosPrueba.Enabled = true;
            Alerta("Datos borrados con éxito.", AlertaToast.enmTipo.Exito);
        }
    }
}
