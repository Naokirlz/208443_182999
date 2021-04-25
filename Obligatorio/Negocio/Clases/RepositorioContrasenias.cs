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
            return unaContrasenia;
        }

        public List<Contrasenia> ListarContrasenias()
        {
            return this.Contrasenias;
        }

        internal Contrasenia ModificarContrasenia(Contrasenia aModificarContrasenia)
        {
            Contrasenia anterior = BuscarPorId(aModificarContrasenia.Id);
            anterior.Sitio = aModificarContrasenia.Sitio;
            Contrasenia clonModificada = new Contrasenia() {
                Id = anterior.Id,
                Sitio = anterior.Sitio,
                Notas = anterior.Notas,
                Password = anterior.Password,
                Usuario = anterior.Usuario,
                Categoria = anterior.Categoria,
                FechaUltimaModificacion = anterior.FechaUltimaModificacion
            };
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
            Contrasenia clonBuscada = new Contrasenia()
            {
                Id = buscada.Id,
                Sitio = buscada.Sitio,
                Notas = buscada.Notas,
                Password = buscada.Password,
                Usuario = buscada.Usuario,
                Categoria = buscada.Categoria,
                FechaUltimaModificacion = buscada.FechaUltimaModificacion
            };
            return clonBuscada;
        }
    }
}