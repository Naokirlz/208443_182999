using Negocio.Excepciones;
using System;
using System.Collections.Generic;

namespace Negocio.Contrasenias
{
    public class RepositorioContrasenias
    {
        private static int autonumerado = 1;
        private List<Contrasenia> Contrasenias { get; set; }
                
        public RepositorioContrasenias()
        {
            this.Contrasenias = new List<Contrasenia>();
        }

        public int Alta(Contrasenia unaContrasenia)
        {
            ContraseniaNoExiste(unaContrasenia);
            unaContrasenia.Id = autonumerado;
            unaContrasenia.FechaUltimaModificacion = DateTime.Now;
            this.Contrasenias.Add(unaContrasenia);
            autonumerado++;
            return unaContrasenia.Id;
        }

        public void Baja(int id)
        {
            Contrasenias.Remove(BuscarContraeniaOriginal(id));
        }

        public void ModificarContrasenia(Contrasenia modificarContrasenia)
        {
            Contrasenia anterior = BuscarContraeniaOriginal(modificarContrasenia.Id);
            anterior.Sitio = modificarContrasenia.Sitio;
            anterior.Usuario = modificarContrasenia.Usuario;
                        
            if (!anterior.Password.Equals(modificarContrasenia.Password))
            {
                anterior.Password = modificarContrasenia.Password;
                anterior.FechaUltimaModificacion = DateTime.Now.AddSeconds(1);
            }
            
            anterior.Categoria = modificarContrasenia.Categoria;
            anterior.Notas = modificarContrasenia.Notas;
                        
        }

        public Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return item;
            throw new ExcepcionElementoNoExiste("La contraseña buscada no existe.");
        }

        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            this.Contrasenias.Sort();
            return this.Contrasenias;
        }
 
        private Contrasenia BuscarContraeniaOriginal(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return item;

            throw new ExcepcionElementoNoExiste("La contraseña buscada no existe.");
        }

        private void ContraseniaNoExiste(Contrasenia unaContrasenia)
        {
            foreach (var contrasenia in this.Contrasenias)
            {
                if (contrasenia.Sitio.ToUpper().Equals(unaContrasenia.Sitio.ToUpper()) &&
                    contrasenia.Usuario.ToUpper().Equals(unaContrasenia.Usuario.ToUpper()))
                    throw new ExcepcionElementoYaExiste("La contraseña buscada ya existe.");
            }
        }
    }
}