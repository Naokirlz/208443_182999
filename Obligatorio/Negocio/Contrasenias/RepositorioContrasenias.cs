using Negocio.Utilidades;
using System;
using System.Collections.Generic;

namespace Negocio.Contrasenias
{
    public class RepositorioContrasenias
    {
        private static int autonumerado = 1;
        private List<Contrasenia> contrasenias;
                
        public RepositorioContrasenias()
        {
            this.contrasenias = new List<Contrasenia>();
        }

        public int Alta(Contrasenia unaContrasenia)
        {
            VerificarSiExisteContrasenia(unaContrasenia);
            unaContrasenia.Id = autonumerado;
            unaContrasenia.FechaUltimaModificacion = DateTime.Now;
            this.contrasenias.Add(unaContrasenia);
            autonumerado++;
            return unaContrasenia.Id;
        }

        public void Baja(int id)
        {
            contrasenias.Remove(BuscarPorId(id));
        }

        public void ModificarContrasenia(Contrasenia modificarContrasenia)
        {
            Contrasenia anterior = BuscarPorId(modificarContrasenia.Id);
            anterior.Sitio = modificarContrasenia.Sitio;
            anterior.Usuario = modificarContrasenia.Usuario;
                        
            if (!anterior.Password.Equals(modificarContrasenia.Password))
            {
                anterior.Password = modificarContrasenia.Password;
                anterior.FechaUltimaModificacion = DateTime.Now;
            }
            
            anterior.Categoria = modificarContrasenia.Categoria;
            anterior.Notas = modificarContrasenia.Notas;
                        
        }

        public Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in contrasenias)
                if (item.Id == id) return item;
            throw new ExcepcionElementoNoExiste("La contraseña buscada no existe.");
        }

        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            this.contrasenias.Sort();
            return this.contrasenias;
        }
   
        private void VerificarSiExisteContrasenia(Contrasenia unaContrasenia)
        {
            foreach (var contrasenia in this.contrasenias)
            {
                if (contrasenia.Sitio.ToUpper().Equals(unaContrasenia.Sitio.ToUpper()) &&
                    contrasenia.Usuario.ToUpper().Equals(unaContrasenia.Usuario.ToUpper()))
                    throw new ExcepcionElementoYaExiste("La contraseña buscada ya existe.");
            }
        }
    }
}