using Negocio.Excepciones;
using Negocio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Persistencia.Memoria
{
    public class RepositorioUsuarioMemoria : IRepositorio<Usuario>
    {
        private static int autonumerado = 1;
        private Usuario usuario;
        public int Alta(Usuario entity)
        {
            usuario = entity;
            usuario.Id = autonumerado;
            autonumerado++;
            return usuario.Id;
        }

        public void Baja(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar(Usuario entity)
        {
            return usuario;
        }

        public void Existe(Usuario entity)
        {
            if (usuario != null) throw new ExcepcionElementoYaExiste("El usuario ya existe.");
        }

        public void Modificar(Usuario entity)
        {
            usuario.ClaveMaestra = entity.ClaveMaestra;
        }

        public IEnumerable<Usuario> ObtenerTodas()
        {
            throw new NotImplementedException();
        }

        public void TestClear()
        {
            usuario = null;
        }
    }
}
