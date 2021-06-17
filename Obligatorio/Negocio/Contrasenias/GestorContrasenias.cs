using Negocio.DataBreaches;
using Negocio.Excepciones;
using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.Contrasenias
{
    public class GestorContrasenias
    {
        private const int LARGO_MAXIMO_CLAVE = 25;
        private const int LARGO_MINIMO_CLAVE = 5;
        private const int LARGO_MAXIMO_SITIO = 25;
        private const int LARGO_MINIMO_SITIO = 3;
        private const int LARGO_MAXIMO_USUARIO = 25;
        private const int LARGO_MINIMO_USUARIO = 5;
        private const int LARGO_MAXIMO_NOTAS = 250;
        private const int LARGO_MINIMO_NOTAS = 0;
                
        private IRepositorio<Contrasenia> repositorio;
                
        public GestorContrasenias() 
        {
            FabricaRepositorio fabrica = new FabricaRepositorio();
            this.repositorio = fabrica.CrearRepositorioContrasenias();
        }
        
        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
            unaContrasena.FechaUltimaModificacion = DateTime.Now;
            return repositorio.Alta(unaContrasena);
        }

        public void Baja(int id)
        {
            Contrasenia eliminar = new Contrasenia()
            {
                ContraseniaId = id
            };
            repositorio.Baja(eliminar);
        }
        
        public void ModificarContrasenia(Contrasenia modificada)
        {
            ValidarCampos(modificada);
            repositorio.Modificar(modificada);
        }
      
        public Contrasenia Buscar(int id)
        {
            Contrasenia buscar = new Contrasenia()
            {
                ContraseniaId = id
            };
            return repositorio.Buscar(buscar);
        }
        
        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            return repositorio.ObtenerTodas();
        }

        public string MostrarPassword(Contrasenia password)
        {
            return password.Password.Clave;
        }
        
        public IEnumerable<Contrasenia> ObtenerContraseniasVulnerables(List<IFuente> fuentes)
        {
            List<Contrasenia> contraseniasVulnerables = new List<Contrasenia>();
            IEnumerable<Contrasenia> todasLasContrasenias = this.ObtenerTodas();
            int cantidad = todasLasContrasenias.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarContraseniaSiEsVulnerable(contraseniasVulnerables, todasLasContrasenias.ElementAt(i), fuentes);
            }

            return contraseniasVulnerables;
        }
        private void AgregarContraseniaSiEsVulnerable(List<Contrasenia> contrasenias, Contrasenia contrasenia, List<IFuente> fuentes)
        {
            int cantidadVecesEnFuente = BuscarContraseniaEnFuente(contrasenia, fuentes);
            if (cantidadVecesEnFuente > 0)
            {
                contrasenia.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.ModificarContrasenia(contrasenia);
                contrasenias.Add(contrasenia);
            }

        }

        private int BuscarContraseniaEnFuente(Contrasenia contrasenia, List<IFuente> fuentes)
        {
            string password = this.MostrarPassword(contrasenia);
            int cantidadDeVecesVulnerable = 0;
            foreach(IFuente fuente in fuentes)
            {
                cantidadDeVecesVulnerable += fuente.BuscarPasswordOContraseniaEnFuente(password);
            }
            return cantidadDeVecesVulnerable;
        }

        private void ValidarCampos(Contrasenia contrasenia)
        {
            if (contrasenia.Sitio == null ||
                contrasenia.Usuario == null ||
                contrasenia.Password == null ||
                contrasenia.Categoria == null)
                throw new ExcepcionFaltaAtributo("Debe completar los campos obligatorios.");

            Validaciones.ValidarFecha(contrasenia.FechaUltimaModificacion);
            Validaciones.ValidarLargoTexto(contrasenia.Sitio, LARGO_MAXIMO_SITIO, LARGO_MINIMO_SITIO, "sitio");
            Validaciones.ValidarLargoTexto(contrasenia.Usuario, LARGO_MAXIMO_USUARIO, LARGO_MINIMO_USUARIO, "usuario");
            Validaciones.ValidarPassword(contrasenia.Password.Clave, LARGO_MAXIMO_CLAVE, LARGO_MINIMO_CLAVE);
            if (contrasenia.Notas != null) Validaciones.ValidarLargoTexto(contrasenia.Notas, LARGO_MAXIMO_NOTAS, LARGO_MINIMO_NOTAS, "notas");
        }

        public List<Grupo> GenerarGrupos()
        {
            List<Grupo> retorno = new List<Grupo>();
            string[] grupos = { "Rojo", "Naranja", "Amarillo", "Verde_Claro", "Verde_Oscuro" };
            foreach (string grupo in grupos)
            {
                Grupo nuevo = new Grupo()
                {
                    Tipo = grupo
                };
                IEnumerable<Contrasenia> contrasenias = ObtenerTodas();
                foreach (Contrasenia contrasenia in contrasenias)
                {
                    string password = MostrarPassword(contrasenia);
                    if (contrasenia.Password.ColorPassword.ToString() == grupo.ToUpper())
                    {
                        nuevo.Cantidad = nuevo.Cantidad + 1;
                        nuevo.Contrasenias.Add(contrasenia);
                    }
                }
                retorno.Add(nuevo);
            }

            return retorno;
        }

        public void LimpiarBD()
        {
            repositorio.TestClear();
        }


        public string VerificarFortalezaPassword(string password)
        {
            Password pass = new Password(password);
            return pass.CalcularFortaleza().ToString();
        }

        public int VerificarCantidadVecesPasswordRepetido(string password)
        {
            List<Contrasenia> contrasenias = this.ObtenerTodas().ToList();
            int cantidad = 0;
            foreach(Contrasenia contrasenia in contrasenias)
            {
                if (contrasenia.Password.Clave.Equals(password)) cantidad++;
            }
            return cantidad;
        }

        public int VerificarPasswordFiltrado(string password, List<IFuente> fuentes)
        {
            int cantidad = 0;

            foreach(IFuente fuente in fuentes)
            {
                cantidad += fuente.BuscarPasswordOContraseniaEnFuente(password);
            }

            return cantidad;
        }
    }
}
