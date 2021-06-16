using Negocio.Excepciones;
using Negocio.Usuarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia.EntityFramework
{
    public class RepositorioUsuarioEntity : IRepositorio<Usuario>
    {
        string contexto = "name=" + ConfigurationManager.AppSettings["DATABASE_CONTEXT"];
        public int Alta(Usuario entity)
        {
            using (Contexto context = new Contexto(contexto))
            {
                context.Usuarios.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public void Baja(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar(Usuario entity)
        {
            using (Contexto context = new Contexto(contexto))
            {
                Usuario usuario = context.Usuarios.FirstOrDefault();
                return usuario;
            }
        }

        public void Existe(Usuario entity)
        {
            using (Contexto context = new Contexto(contexto))
            {
                Usuario existe = context.Usuarios.FirstOrDefault();
                if (existe != null)
                    throw new ExcepcionElementoYaExiste("El usuario ya existe.");
            }
        }

        public void Modificar(Usuario entity)
        {
            using (Contexto context = new Contexto(contexto))
            {
                Usuario aModificar = context.Usuarios.FirstOrDefault();
                aModificar.ClaveMaestra = entity.ClaveMaestra;

                context.SaveChanges();
            }
        }

        public IEnumerable<Usuario> ObtenerTodas()
        {
            throw new NotImplementedException();
        }

        public void TestClear()
        {
            using (Contexto context = new Contexto(contexto))
            {
                context.Usuarios.RemoveRange(context.Usuarios);
                context.SaveChanges();
            }
        }
    }
}
