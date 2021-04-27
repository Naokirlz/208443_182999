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
            foreach (var contrasenia in this.Contrasenias)
            {
                if (contrasenia.Sitio.Equals(unaContrasenia.Sitio) &&
                    contrasenia.Usuario.Equals(unaContrasenia.Usuario))
                    throw new ExcepcionElementoYaExiste();
            }
            unaContrasenia.Id = IdContrasenia;
            IdContrasenia++;
            unaContrasenia.Password = Encriptar(unaContrasenia.Password);
            Contrasenia clonada = ClonarContrasenia(unaContrasenia);
            this.Contrasenias.Add(clonada);
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
            anterior.Usuario = aModificarContrasenia.Usuario;
            anterior.Password = Encriptar(aModificarContrasenia.Password);
            anterior.Categoria = aModificarContrasenia.Categoria;
            anterior.Notas = aModificarContrasenia.Notas;
            Contrasenia clonModificada = ClonarContrasenia(anterior);
            return clonModificada;
        }

        private Contrasenia BuscarPorId(int id)
        {
            foreach (Contrasenia item in Contrasenias)
                if (item.Id == id) return item;

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

        private string Encriptar(string texto)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(texto);
            string codificado;
            codificado = Convert.ToBase64String(byt);
            return codificado;
        }

        private string DesEncriptar(string texto)
        {
            byte[] b = Convert.FromBase64String(texto);
            string original;
            original = System.Text.Encoding.UTF8.GetString(b);
            return original;
        }

        internal string MostrarPassword(string password)
        {
            return DesEncriptar(password);
        }

        internal void Baja(int id)
        {
            Contrasenias.Remove(BuscarPorId(id));
        }
    }
}