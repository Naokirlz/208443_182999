using Negocio.Excepciones;
using System;
using System.Collections.Generic;

namespace Negocio.Clases
{
    public class RepositorioContrasenias
    {
        private List<Contrasenia> Contrasenias { get; set; }
        private static int IdContrasenia = 1;

        public RepositorioContrasenias()
        {
            this.Contrasenias = new List<Contrasenia>();
        }

        public Contrasenia Alta(Contrasenia unaContrasenia)
        {
            unaContrasenia.Id = IdContrasenia;
            IdContrasenia++;
            this.Contrasenias.Add(unaContrasenia);
            Contrasenia clonada = ClonarContrasenia(unaContrasenia);
            return clonada;
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return this.Contrasenias;
        }

        internal Contrasenia ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            Contrasenia anterior = BuscarPorId(aModificarContrasenia.Id);
            anterior.Sitio = aModificarContrasenia.Sitio;
            anterior.Usuario = aModificarContrasenia.Usuario;
            anterior.Password = aModificarContrasenia.Password;
            anterior.Categoria = aModificarContrasenia.Categoria;
            anterior.Notas = aModificarContrasenia.Notas;
            Contrasenia clonModificada = ClonarContrasenia(anterior);
            return clonModificada;
        }

        private Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in Contrasenias)
            {
                if (item.Id == id) return item;
            }
            throw new ExcepcionElementoNoExiste();
        }

        internal Contrasenia Buscar(int id)
        {
            Contrasenia buscada = BuscarPorId(id);
            Contrasenia clonBuscada = ClonarContrasenia(buscada);
            return clonBuscada;
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
                FechaUltimaModificacion = unaContrasenia.FechaUltimaModificacion
            };
            return clonada;
        }
    }
}