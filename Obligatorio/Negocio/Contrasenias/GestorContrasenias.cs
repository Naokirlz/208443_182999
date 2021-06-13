using Negocio.DataBreaches;
using Negocio.Excepciones;
using Negocio.Persistencia;
using Negocio.Persistencia.EntityFramework;
using Negocio.Persistencia.Memoria;
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
            //this.repositorio = new RepositorioContraseniasMemoria();
            this.repositorio = new RepositorioContraseniasEntity();
        }
        
        public int Alta(Contrasenia unaContrasena)
        {
            ValidarCampos(unaContrasena);
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
        
        public IEnumerable<Contrasenia> ObtenerContraseniasVulnerables(IFuente fuente)
        {
            List<Contrasenia> contraseniasVulnerables = new List<Contrasenia>();
            IEnumerable<Contrasenia> todasLasContrasenias = this.ObtenerTodas();
            int cantidad = todasLasContrasenias.Count();

            for (int i = 0; i < cantidad; i++)
            {
                AgregarContraseniaSiEsVulnerable(contraseniasVulnerables, todasLasContrasenias.ElementAt(i), fuente);
            }

            return contraseniasVulnerables;
        }
        private void AgregarContraseniaSiEsVulnerable(List<Contrasenia> contrasenias, Contrasenia contrasenia, IFuente fuente)
        {
            int cantidadVecesEnFuente = BuscarContraseniaEnFuente(contrasenia, fuente);
            if (cantidadVecesEnFuente > 0)
            {
                contrasenia.CantidadVecesEncontradaVulnerable = cantidadVecesEnFuente;
                this.ModificarContrasenia(contrasenia);
                contrasenias.Add(contrasenia);
            }

        }

        private int BuscarContraseniaEnFuente(Contrasenia contrasenia, IFuente fuente)
        {
            string password = this.MostrarPassword(contrasenia);
            int cantidadDeVecesVulnerable = fuente.BuscarPasswordOContraseniaEnFuente(password);
            IFuente fuenteArchivo = new FuenteArchivo();
            cantidadDeVecesVulnerable += fuenteArchivo.BuscarPasswordOContraseniaEnFuente(password);
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
            //return repositorio.VerificarCantidadVecesPasswordRepetido(password);
            throw new NotImplementedException();
        }

    }
}
