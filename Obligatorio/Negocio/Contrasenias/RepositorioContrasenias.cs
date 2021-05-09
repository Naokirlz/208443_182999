using Negocio.Excepciones;
using System;
using System.Collections.Generic;

using System.Text;

namespace Negocio.Contrasenias
{
    public class RepositorioContrasenias
    {
        private List<Contrasenia> Contrasenias { get; set; }
        private static int autonumerado = 1;
        

        public RepositorioContrasenias()
        {
            this.Contrasenias = new List<Contrasenia>();
        }

        public int Alta(Contrasenia unaContrasenia)
        {
            unaContrasenia.Id = autonumerado;
            ContraseniaNoExiste(unaContrasenia);
            this.Contrasenias.Add(ClonarContrasenia(unaContrasenia));
            autonumerado++;
            return unaContrasenia.Id;
        }

        public void Baja(int id)
        {
            Contrasenias.Remove(BuscarContraeniaOriginal(id));
        }

        public void ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            Contrasenia anterior = BuscarContraeniaOriginal(aModificarContrasenia.Id);
            anterior.Sitio = aModificarContrasenia.Sitio;
            anterior.Usuario = aModificarContrasenia.Usuario;
                        
            if (!anterior.Password.Equals(aModificarContrasenia.Password))
            {
                anterior.FechaUltimaModificacion = DateTime.Now.AddSeconds(1);
            }
            
            anterior.Categoria = aModificarContrasenia.Categoria;
            anterior.Notas = aModificarContrasenia.Notas;
            Contrasenia clonModificada = ClonarContrasenia(anterior);
            
        }

        public IEnumerable<Contrasenia> ObtenerTodas()
        {
            List<Contrasenia> retorno = this.Contrasenias;
            retorno.Sort();
            return retorno;
        }

        public Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return ClonarContrasenia(item);

            throw new ExcepcionElementoNoExiste();
        }

        private Contrasenia BuscarContraeniaOriginal(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return item;

            throw new ExcepcionElementoNoExiste();
        }

        private void ContraseniaNoExiste(Contrasenia unaContrasenia)
        {
            foreach (var contrasenia in this.Contrasenias)
            {
                if (contrasenia.Sitio.Equals(unaContrasenia.Sitio) &&
                    contrasenia.Usuario.Equals(unaContrasenia.Usuario))
                    throw new ExcepcionElementoYaExiste();
            }

        }

        private Contrasenia ClonarContrasenia(Contrasenia unaContrasenia)
        {
            Contrasenia clonada = new Contrasenia()
            {
                Id = unaContrasenia.Id,
                Sitio = unaContrasenia.Sitio,
                Notas = unaContrasenia.Notas,
                Password = unaContrasenia.Password,
                Usuario = unaContrasenia.Usuario,
                Categoria = unaContrasenia.Categoria,
                FechaUltimaModificacion = unaContrasenia.FechaUltimaModificacion,
                CantidadVecesEncontradaVulnerable = unaContrasenia.CantidadVecesEncontradaVulnerable
            };
            return clonada;
        }

        

    }
}