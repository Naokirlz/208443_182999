using System.Collections.Generic;

namespace Negocio.Persistencia
{
    public interface IRepositorio<T>
    {
        T Buscar(T entity);
        IEnumerable<T> ObtenerTodas();
        int Alta(T entity);
        void Baja(T entity);
        void Modificar(T entity);
        void Existe(T entity);
        void TestClear();
    }
}
